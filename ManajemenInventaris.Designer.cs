﻿namespace crudaplikasi
{
    partial class ManajemenInventaris
    {
        private System.ComponentModel.IContainer components = null;

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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pemasok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kuantitas";
            // 
            // txtID
            // 
            this.txtPemasok.Location = new System.Drawing.Point(94, 19);
            this.txtPemasok.Name = "txtPemasok";
            this.txtPemasok.Size = new System.Drawing.Size(253, 20);
            this.txtPemasok.TabIndex = 3;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(94, 49);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(253, 20);
            this.txtNama.TabIndex = 4;
            // 
            // txtKuantitas
            // 
            this.txtKuantitas.Location = new System.Drawing.Point(94, 80);
            this.txtKuantitas.Name = "txtKuantitas";
            this.txtKuantitas.Size = new System.Drawing.Size(253, 20);
            this.txtKuantitas.TabIndex = 5;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(353, 17);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(87, 26);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(353, 48);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(87, 24);
            this.btnUbah.TabIndex = 7;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(353, 78);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(87, 22);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(444, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 26);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(21, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(514, 365);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(585, 120);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(514, 365);
            this.dataGridView2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nama Barang";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Jumlah";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Pengambil";
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(710, 19);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(269, 20);
            this.txtNamaBarang.TabIndex = 15;
            // 
            // txtPengambil
            // 
            this.txtPengambil.Location = new System.Drawing.Point(710, 49);
            this.txtPengambil.Name = "txtPengambil";
            this.txtPengambil.Size = new System.Drawing.Size(269, 20);
            this.txtPengambil.TabIndex = 16;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(710, 80);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(269, 20);
            this.txtJumlah.TabIndex = 17;
            // 
            // btnAmbil
            // 
            this.btnAmbil.Location = new System.Drawing.Point(1005, 17);
            this.btnAmbil.Name = "btnAmbil";
            this.btnAmbil.Size = new System.Drawing.Size(94, 33);
            this.btnAmbil.TabIndex = 18;
            this.btnAmbil.Text = "Ambil";
            this.btnAmbil.UseVisualStyleBackColor = true;
            this.btnAmbil.Click += new System.EventHandler(this.btnAmbil_Click);
            // 
            // ManajemenInventaris
            // 
            this.ClientSize = new System.Drawing.Size(1120, 515);
            this.Controls.Add(this.btnAmbil);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.txtPengambil);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtKuantitas);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtPemasok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManajemenInventaris";
            this.Text = "Manajemen Inventaris";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPemasok;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtKuantitas;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.TextBox txtPengambil;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.Button btnAmbil;
    }
}
