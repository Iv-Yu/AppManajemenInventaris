using crudaplikasi.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace crudaplikasi
{
    public partial class ManajemenInventaris : Form
    {
        private AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();
        private TextBox txtID = new TextBox();
        private managecontroller controller;

        public ManajemenInventaris()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Load += ManajemenInventaris_Load;
            txtID.Visible = false;
            this.Controls.Add(txtID);
            controller = new managecontroller();
        }

        private void ManajemenInventaris_Load(object sender, EventArgs e)
        {
            controller.LoadAutoComplete(txtNama, txtNamaBarang);
            dataGridView1.DataSource = controller.GetAllProduk();
            dataGridView2.DataSource = controller.GetLogPengambilan();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            var result = controller.TambahProduk(txtNama.Text, txtKuantitas.Text, txtPemasok.Text);
            MessageBox.Show(result);
            dataGridView1.DataSource = controller.GetAllProduk();
            dataGridView2.DataSource = controller.GetLogPengambilan();
            ResetForm();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            var result = controller.UbahProduk(txtID.Text, txtNama.Text, txtKuantitas.Text, txtPemasok.Text);
            MessageBox.Show(result);
            dataGridView1.DataSource = controller.GetAllProduk();
            dataGridView2.DataSource = controller.GetLogPengambilan();
            ResetForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            var result = controller.HapusProduk(txtID.Text);
            MessageBox.Show(result);
            dataGridView1.DataSource = controller.GetAllProduk();
            dataGridView2.DataSource = controller.GetLogPengambilan();
            ResetForm();
        }

        private void btnAmbil_Click(object sender, EventArgs e)
        {
            var result = controller.AmbilBarang(txtNamaBarang.Text, txtPengambil.Text, txtJumlah.Text);
            MessageBox.Show(result);
            dataGridView1.DataSource = controller.GetAllProduk();
            dataGridView2.DataSource = controller.GetLogPengambilan();
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtID.Clear();
            txtPemasok.Clear();
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
                txtPemasok.Text = row.Cells["pemasok"].Value?.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
