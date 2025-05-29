using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace crudaplikasi
{
    public partial class ManajemenInventaris : Form
    {
        private AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();

        public ManajemenInventaris()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Load += ManajemenInventaris_Load;
        }

        private void ManajemenInventaris_Load(object sender, EventArgs e)
        {
            LoadAutoCompleteNamaBarang();
            TampilkanData();
            TampilkanLogPengambilan();
        }

        private void LoadAutoCompleteNamaBarang()
        {
            try
            {
                autoCollection.Clear();
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DISTINCT nama FROM produk";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        autoCollection.Add(reader.GetString("nama"));
                    }

                    txtNama.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNama.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNama.AutoCompleteCustomSource = autoCollection;

                    txtNamaBarang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNamaBarang.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNamaBarang.AutoCompleteCustomSource = autoCollection;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data autocomplete: " + ex.Message);
            }
        }

        private void TampilkanData()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM produk";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void TampilkanLogPengambilan()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        p.id_pengambilan,
                        pr.nama AS nama_barang,
                        p.pengambil,
                        p.jumlah,
                        p.tanggal_ambil
                    FROM pengambilan p
                    JOIN produk pr ON p.id_produk = pr.id
                    ORDER BY p.tanggal_ambil DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan log pengambilan: " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtKuantitas.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi.");
                return;
            }

            if (!decimal.TryParse(txtKuantitas.Text, out decimal qty))
            {
                MessageBox.Show("Jumlah tidak valid.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO produk (id, nama, kuantitas) VALUES (@id, @nama, @kuantitas)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@kuantitas", qty);
                    cmd.ExecuteNonQuery();

                    SimpanLog("Tambah", txtID.Text, txtNama.Text, qty);
                }

                MessageBox.Show("Data berhasil ditambahkan!");
                TampilkanData();
                TampilkanLogPengambilan();
                ResetForm();
                LoadAutoCompleteNamaBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah data: " + ex.Message);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Pilih data yang akan diubah.");
                return;
            }

            if (!decimal.TryParse(txtKuantitas.Text, out decimal qty))
            {
                MessageBox.Show("Jumlah tidak valid.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE produk SET nama=@nama, kuantitas=@kuantitas WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@kuantitas", qty);
                    cmd.ExecuteNonQuery();

                    SimpanLog("Ubah", txtID.Text, txtNama.Text, qty);
                }

                MessageBox.Show("Data berhasil diubah!");
                TampilkanData();
                TampilkanLogPengambilan();
                ResetForm();
                LoadAutoCompleteNamaBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ubah data: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM produk WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil dihapus!");
                TampilkanData();
                TampilkanLogPengambilan();
                ResetForm();
                LoadAutoCompleteNamaBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus data: " + ex.Message);
            }
        }

        private void btnAmbil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtPengambil.Text) ||
                !decimal.TryParse(txtJumlah.Text, out decimal jumlahAmbil))
            {
                MessageBox.Show("Isi semua kolom pengambilan.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string queryCek = "SELECT id, kuantitas FROM produk WHERE nama = @nama";
                    MySqlCommand cmdCek = new MySqlCommand(queryCek, conn);
                    cmdCek.Parameters.AddWithValue("@nama", txtNamaBarang.Text);
                    var reader = cmdCek.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Produk tidak ditemukan.");
                        return;
                    }

                    string idProduk = reader["id"].ToString();
                    decimal stokSaatIni = Convert.ToDecimal(reader["kuantitas"]);
                    reader.Close();

                    if (stokSaatIni < jumlahAmbil)
                    {
                        MessageBox.Show("Stok tidak mencukupi.");
                        return;
                    }

                    string queryUpdate = "UPDATE produk SET kuantitas = kuantitas - @jumlahAmbil WHERE nama = @nama";
                    MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@jumlahAmbil", jumlahAmbil);
                    cmdUpdate.Parameters.AddWithValue("@nama", txtNamaBarang.Text);
                    cmdUpdate.ExecuteNonQuery();

                    string queryInsert = "INSERT INTO pengambilan (id_produk, pengambil, jumlah, tanggal_ambil) VALUES (@id, @pengambil, @jumlah, @waktu)";
                    MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@id", idProduk);
                    cmdInsert.Parameters.AddWithValue("@pengambil", txtPengambil.Text);
                    cmdInsert.Parameters.AddWithValue("@jumlah", jumlahAmbil);
                    cmdInsert.Parameters.AddWithValue("@waktu", DateTime.Now);
                    cmdInsert.ExecuteNonQuery();

                    SimpanLog("Ambil", idProduk, txtNamaBarang.Text, jumlahAmbil);
                }

                MessageBox.Show("Barang berhasil diambil dan dicatat.");
                TampilkanData();
                TampilkanLogPengambilan();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil barang: " + ex.Message);
            }
        }

        private void SimpanLog(string aksi, string idProduk, string namaProduk, decimal kuantitas)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO log_aktivitas (aksi, id_produk, nama_produk, kuantitas) VALUES (@aksi, @id, @nama, @kuantitas)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@aksi", aksi);
                    cmd.Parameters.AddWithValue("@id", idProduk);
                    cmd.Parameters.AddWithValue("@nama", namaProduk);
                    cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan log: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtID.Clear();
            txtNama.Clear();
            txtKuantitas.Clear();
            txtNamaBarang.Clear();
            txtPengambil.Clear();
            txtJumlah.Clear();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var row = dataGridView1.CurrentRow;
                txtID.Text = row.Cells["id"].Value?.ToString();
                txtNama.Text = row.Cells["nama"].Value?.ToString();
                txtKuantitas.Text = row.Cells["kuantitas"].Value?.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
