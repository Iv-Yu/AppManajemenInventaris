using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace crudaplikasi
{
    partial class ManajemenInventaris
    {
        private IContainer components = null;
        private bool isDarkMode = true;
        private Button btnToggleMode;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManajemenInventaris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPemasok = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtKuantitas = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamaBarang = new System.Windows.Forms.TextBox();
            this.txtPengambil = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.btnAmbil = new System.Windows.Forms.Button();
            this.btnToggleMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pemasok";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Barang";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kuantitas";
            // 
            // txtPemasok
            // 
            this.txtPemasok.Location = new System.Drawing.Point(100, 18);
            this.txtPemasok.Name = "txtPemasok";
            this.txtPemasok.Size = new System.Drawing.Size(230, 20);
            this.txtPemasok.TabIndex = 3;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(100, 48);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(230, 20);
            this.txtNama.TabIndex = 4;
            // 
            // txtKuantitas
            // 
            this.txtKuantitas.Location = new System.Drawing.Point(100, 78);
            this.txtKuantitas.Name = "txtKuantitas";
            this.txtKuantitas.Size = new System.Drawing.Size(230, 20);
            this.txtKuantitas.TabIndex = 5;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(350, 18);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(80, 25);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(350, 48);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(80, 25);
            this.btnUbah.TabIndex = 7;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(350, 78);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(80, 25);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(440, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 25);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(20, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 360);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Location = new System.Drawing.Point(570, 120);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(530, 360);
            this.dataGridView2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(580, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nama Barang";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(580, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Jumlah";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(580, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pengambil";
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(690, 18);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(220, 20);
            this.txtNamaBarang.TabIndex = 16;
            // 
            // txtPengambil
            // 
            this.txtPengambil.Location = new System.Drawing.Point(690, 48);
            this.txtPengambil.Name = "txtPengambil";
            this.txtPengambil.Size = new System.Drawing.Size(220, 20);
            this.txtPengambil.TabIndex = 17;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(690, 78);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(220, 20);
            this.txtJumlah.TabIndex = 18;
            // 
            // btnAmbil
            // 
            this.btnAmbil.Location = new System.Drawing.Point(939, 18);
            this.btnAmbil.Name = "btnAmbil";
            this.btnAmbil.Size = new System.Drawing.Size(80, 35);
            this.btnAmbil.TabIndex = 19;
            this.btnAmbil.Text = "Ambil";
            this.btnAmbil.Click += new System.EventHandler(this.btnAmbil_Click);
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Location = new System.Drawing.Point(939, 75);
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(80, 25);
            this.btnToggleMode.TabIndex = 10;
            this.btnToggleMode.Text = "Dark/Light";
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
            // 
            // ManajemenInventaris
            // 
            this.ClientSize = new System.Drawing.Size(1120, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPemasok);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtKuantitas);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnToggleMode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.txtPengambil);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.btnAmbil);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "ManajemenInventaris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manajemen Inventaris PT. Jenggala Lintas Nusantara";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            ToggleTheme();
            this.Resize += new EventHandler(this.Form_Resize);
            Form_Resize(this, EventArgs.Empty);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.ClientSize.Width / 2 - 50;
            dataGridView2.Width = this.ClientSize.Width / 2 - 50;
            dataGridView2.Left = dataGridView1.Right + 30;
            dataGridView1.Height = dataGridView2.Height = this.ClientSize.Height - dataGridView1.Top - 30;
        }

        private void ToggleTheme()
        {
            isDarkMode = !isDarkMode;
            Color backColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
            Color foreColor = isDarkMode ? Color.White : Color.Black;
            Color controlBack = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
            Color gridBack = isDarkMode ? Color.FromArgb(45, 45, 45) : Color.White;
            Color gridCellBack = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.White;
            Color gridHeaderBack = isDarkMode ? Color.FromArgb(70, 70, 70) : Color.LightGray;

            this.BackColor = backColor;
            this.ForeColor = foreColor;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl) { lbl.ForeColor = foreColor; lbl.BackColor = Color.Transparent; }
                else if (ctrl is TextBox tb)
                {
                    tb.BackColor = controlBack;
                    tb.ForeColor = foreColor;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = isDarkMode ? Color.FromArgb(70, 70, 70) : Color.LightGray;
                    btn.ForeColor = foreColor;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

            foreach (DataGridView dgv in new[] { dataGridView1, dataGridView2 })
            {
                dgv.BackgroundColor = gridBack;
                dgv.DefaultCellStyle.BackColor = gridCellBack;
                dgv.DefaultCellStyle.ForeColor = foreColor;
                dgv.DefaultCellStyle.SelectionBackColor = isDarkMode ? Color.DarkSlateBlue : Color.LightBlue;
                dgv.DefaultCellStyle.SelectionForeColor = foreColor;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = gridHeaderBack;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
            }
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPemasok;
        private TextBox txtNama;
        private TextBox txtKuantitas;
        private Button btnTambah;
        private Button btnUbah;
        private Button btnHapus;
        private Button btnReset;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNamaBarang;
        private TextBox txtPengambil;
        private TextBox txtJumlah;
        private Button btnAmbil;
    }
}
