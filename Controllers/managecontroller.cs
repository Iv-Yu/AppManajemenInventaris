using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using crudaplikasi.Models;

namespace crudaplikasi.Controllers
{
    public class managecontroller
    {
        private AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();

        public void LoadAutoComplete(TextBox txtNama, TextBox txtNamaBarang)
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
                        autoCollection.Add(reader.GetString("nama"));

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

        public DataTable GetAllProduk()
        {
            var dt = new DataTable();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT * FROM produk";
                    var adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
            return dt;
        }

        public DataTable GetLogPengambilan()
        {
            var dt = new DataTable();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.id_pengambilan, pr.nama AS nama_produk, p.pengambil, p.jumlah, p.tanggal_ambil
                                     FROM pengambilan p
                                     JOIN produk pr ON p.id_produk = pr.id
                                     ORDER BY p.tanggal_ambil DESC";
                    var adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan log pengambilan: " + ex.Message);
            }
            return dt;
        }

        public string TambahProduk(string nama, string kuantitas, string pemasok)
        {
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(kuantitas) || string.IsNullOrWhiteSpace(pemasok))
                return "Semua kolom wajib diisi.";

            if (!decimal.TryParse(kuantitas, out decimal qty))
                return "Jumlah tidak valid.";

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO produk (nama, kuantitas, pemasok) VALUES (@nama, @kuantitas, @pemasok)";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@kuantitas", qty);
                    cmd.Parameters.AddWithValue("@pemasok", pemasok);
                    cmd.ExecuteNonQuery();
                }
                return "Data berhasil ditambahkan!";
            }
            catch (Exception ex)
            {
                return "Gagal tambah data: " + ex.Message;
            }
        }

        public string UbahProduk(string id, string nama, string kuantitas, string pemasok)
        {
            if (!decimal.TryParse(kuantitas, out decimal qty))
                return "Jumlah tidak valid.";

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE produk SET nama=@nama, kuantitas=@kuantitas, pemasok=@pemasok WHERE id=@id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@kuantitas", qty);
                    cmd.Parameters.AddWithValue("@pemasok", pemasok);
                    cmd.ExecuteNonQuery();
                }
                return "Data berhasil diubah!";
            }
            catch (Exception ex)
            {
                return "Gagal ubah data: " + ex.Message;
            }
        }

        public string HapusProduk(string id)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM produk WHERE id=@id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                return "Data berhasil dihapus!";
            }
            catch (Exception ex)
            {
                return "Gagal hapus data: " + ex.Message;
            }
        }

        public string AmbilBarang(string namaBarang, string pengambil, string jumlah)
        {
            if (!decimal.TryParse(jumlah, out decimal jumlahAmbil))
                return "Jumlah pengambilan tidak valid.";

            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();
                    var cekQuery = "SELECT id, kuantitas FROM produk WHERE nama = @nama";
                    var cmdCek = new MySqlCommand(cekQuery, conn);
                    cmdCek.Parameters.AddWithValue("@nama", namaBarang);
                    var reader = cmdCek.ExecuteReader();

                    if (!reader.Read())
                        return "Produk tidak ditemukan.";

                    string idProduk = reader["id"].ToString();
                    decimal stokSaatIni = Convert.ToDecimal(reader["kuantitas"]);
                    reader.Close();

                    if (stokSaatIni < jumlahAmbil)
                        return "Stok tidak mencukupi.";

                    string updateQuery = "UPDATE produk SET kuantitas = kuantitas - @jumlahAmbil WHERE nama = @nama";
                    var cmdUpdate = new MySqlCommand(updateQuery, conn);
                    cmdUpdate.Parameters.AddWithValue("@jumlahAmbil", jumlahAmbil);
                    cmdUpdate.Parameters.AddWithValue("@nama", namaBarang);
                    cmdUpdate.ExecuteNonQuery();

                    string insertQuery = "INSERT INTO pengambilan (id_produk, pengambil, jumlah, tanggal_ambil) VALUES (@id, @pengambil, @qty, @waktu)";
                    var cmdInsert = new MySqlCommand(insertQuery, conn);
                    cmdInsert.Parameters.AddWithValue("@id", idProduk);
                    cmdInsert.Parameters.AddWithValue("@pengambil", pengambil);
                    cmdInsert.Parameters.AddWithValue("@qty", jumlahAmbil);
                    cmdInsert.Parameters.AddWithValue("@waktu", DateTime.Now);
                    cmdInsert.ExecuteNonQuery();
                }

                return "Barang berhasil diambil dan dicatat.";
            }
            catch (Exception ex)
            {
                return "Gagal mengambil barang: " + ex.Message;
            }
        }
    }
}
