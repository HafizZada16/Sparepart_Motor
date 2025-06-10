namespace Sparepart_Motor
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId_Transaksi = new System.Windows.Forms.TextBox();
            this.txtId_Pengguna = new System.Windows.Forms.TextBox();
            this.txtTotal_Harga = new System.Windows.Forms.TextBox();
            this.bttnTambah = new System.Windows.Forms.Button();
            this.bttnHapus = new System.Windows.Forms.Button();
            this.bttnUbah = new System.Windows.Forms.Button();
            this.bttnRefresh = new System.Windows.Forms.Button();
            this.dgvSparepart = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.dtpTanggalTransaksi = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSparepart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtpTanggalTransaksi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Transaksi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Pengguna, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTotal_Harga, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(103, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 176);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id_Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id_Pengguna";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tanggal_Transaksi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total_Harga";
            // 
            // txtId_Transaksi
            // 
            this.txtId_Transaksi.Location = new System.Drawing.Point(168, 3);
            this.txtId_Transaksi.Name = "txtId_Transaksi";
            this.txtId_Transaksi.Size = new System.Drawing.Size(160, 22);
            this.txtId_Transaksi.TabIndex = 4;
            this.txtId_Transaksi.TextChanged += new System.EventHandler(this.txtId_Transaksi_TextChanged);
            // 
            // txtId_Pengguna
            // 
            this.txtId_Pengguna.Location = new System.Drawing.Point(168, 47);
            this.txtId_Pengguna.Name = "txtId_Pengguna";
            this.txtId_Pengguna.Size = new System.Drawing.Size(160, 22);
            this.txtId_Pengguna.TabIndex = 5;
            // 
            // txtTotal_Harga
            // 
            this.txtTotal_Harga.Location = new System.Drawing.Point(168, 135);
            this.txtTotal_Harga.Name = "txtTotal_Harga";
            this.txtTotal_Harga.Size = new System.Drawing.Size(160, 22);
            this.txtTotal_Harga.TabIndex = 7;
            // 
            // bttnTambah
            // 
            this.bttnTambah.Location = new System.Drawing.Point(504, 24);
            this.bttnTambah.Name = "bttnTambah";
            this.bttnTambah.Size = new System.Drawing.Size(120, 42);
            this.bttnTambah.TabIndex = 1;
            this.bttnTambah.Text = "Tambah";
            this.bttnTambah.UseVisualStyleBackColor = true;
            this.bttnTambah.Click += new System.EventHandler(this.BtnTambah);
            // 
            // bttnHapus
            // 
            this.bttnHapus.Location = new System.Drawing.Point(504, 78);
            this.bttnHapus.Name = "bttnHapus";
            this.bttnHapus.Size = new System.Drawing.Size(120, 42);
            this.bttnHapus.TabIndex = 2;
            this.bttnHapus.Text = "Hapus";
            this.bttnHapus.UseVisualStyleBackColor = true;
            this.bttnHapus.Click += new System.EventHandler(this.BtnHapus);
            // 
            // bttnUbah
            // 
            this.bttnUbah.Location = new System.Drawing.Point(504, 132);
            this.bttnUbah.Name = "bttnUbah";
            this.bttnUbah.Size = new System.Drawing.Size(120, 42);
            this.bttnUbah.TabIndex = 3;
            this.bttnUbah.Text = "Ubah";
            this.bttnUbah.UseVisualStyleBackColor = true;
            this.bttnUbah.Click += new System.EventHandler(this.BtnUbah);
            // 
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(504, 190);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(120, 42);
            this.bttnRefresh.TabIndex = 4;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.BtnRefresh);
            // 
            // dgvSparepart
            // 
            this.dgvSparepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSparepart.Location = new System.Drawing.Point(12, 247);
            this.dgvSparepart.Name = "dgvSparepart";
            this.dgvSparepart.RowHeadersWidth = 51;
            this.dgvSparepart.RowTemplate.Height = 24;
            this.dgvSparepart.Size = new System.Drawing.Size(776, 182);
            this.dgvSparepart.TabIndex = 5;
            this.dgvSparepart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSparepart_CellContentClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(663, 106);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 39);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // dtpTanggalTransaksi
            // 
            this.dtpTanggalTransaksi.Location = new System.Drawing.Point(168, 91);
            this.dtpTanggalTransaksi.Name = "dtpTanggalTransaksi";
            this.dtpTanggalTransaksi.Size = new System.Drawing.Size(160, 22);
            this.dtpTanggalTransaksi.TabIndex = 7;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvSparepart);
            this.Controls.Add(this.bttnRefresh);
            this.Controls.Add(this.bttnUbah);
            this.Controls.Add(this.bttnHapus);
            this.Controls.Add(this.bttnTambah);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form3";
            this.Text = "Transaksi";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSparepart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId_Transaksi;
        private System.Windows.Forms.TextBox txtId_Pengguna;
        private System.Windows.Forms.TextBox txtTotal_Harga;
        private System.Windows.Forms.Button bttnTambah;
        private System.Windows.Forms.Button bttnHapus;
        private System.Windows.Forms.Button bttnUbah;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.DataGridView dgvSparepart;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DateTimePicker dtpTanggalTransaksi;
    }
}