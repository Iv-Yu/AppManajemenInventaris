using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace crudaplikasi
{
    public partial class ManajemenInventaris : Form
    {
        public ManajemenInventaris()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ManajemenProdukToko_Load(object sender, EventArgs e)
        {
            TampilkanData();
            LoadAutoCompleteNamaBarang(); // 🔽 Tambahan untuk Autocomplete
        }

        private void LoadAutoCompleteNamaBarang()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT DISTINCT nama FROM produk";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        autoCollection.Add(reader.GetString("nama"));
                    }

                    txtNama.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNama.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNama.AutoCompleteCustomSource = autoCollection;
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtKuantitas.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi.");
                return;
            }

            if (!decimal.TryParse(txtKuantitas.Text, out decimal harga))
            {
                MessageBox.Show("Harga tidak valid.");
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
                    cmd.Parameters.AddWithValue("@kuantitas", harga);
                    cmd.ExecuteNonQuery();

                    SimpanLog("Tambah", txtID.Text, txtNama.Text, harga);
                }

                MessageBox.Show("Data berhasil ditambahkan!");
                TampilkanData();
                ResetForm();
                LoadAutoCompleteNamaBarang(); // refresh autocomplete
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

            if (!decimal.TryParse(txtKuantitas.Text, out decimal harga))
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
                    cmd.Parameters.AddWithValue("@kuantitas", harga);
                    cmd.ExecuteNonQuery();

                    SimpanLog("Ubah", txtID.Text, txtNama.Text, harga);
                }

                MessageBox.Show("Data berhasil diubah!");
                TampilkanData();
                ResetForm();
                LoadAutoCompleteNamaBarang(); // refresh autocomplete
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

            var konfirmasi = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (konfirmasi != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string namaProduk = txtNama.Text;
                    decimal.TryParse(txtKuantitas.Text, out decimal qty);

                    string query = "DELETE FROM produk WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.ExecuteNonQuery();

                    SimpanLog("Hapus", txtID.Text, namaProduk, qty);
                }

                MessageBox.Show("Data berhasil dihapus!");
                TampilkanData();
                ResetForm();
                LoadAutoCompleteNamaBarang(); // refresh autocomplete
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus data: " + ex.Message);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
