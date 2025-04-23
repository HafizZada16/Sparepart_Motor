namespace Sparepart_Motor
{
    partial class Form4
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtId_Detail = new System.Windows.Forms.TextBox();
            this.txtId_Transaksi = new System.Windows.Forms.TextBox();
            this.txtId_Barang = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.txtHarga_Satuan = new System.Windows.Forms.TextBox();
            this.bttnTambah = new System.Windows.Forms.Button();
            this.bttnHapus = new System.Windows.Forms.Button();
            this.bttnUbah = new System.Windows.Forms.Button();
            this.bttnRefresh = new System.Windows.Forms.Button();
            this.dgvSparepart = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSparepart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Transaksi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJumlah, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHarga_Satuan, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Detail, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Barang, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(65, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 199);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id_Detail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id_Transaksi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Id_Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jumlah";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Harga_Satuan";
            // 
            // txtId_Detail
            // 
            this.txtId_Detail.Location = new System.Drawing.Point(202, 3);
            this.txtId_Detail.Name = "txtId_Detail";
            this.txtId_Detail.Size = new System.Drawing.Size(194, 22);
            this.txtId_Detail.TabIndex = 5;
            // 
            // txtId_Transaksi
            // 
            this.txtId_Transaksi.Location = new System.Drawing.Point(202, 42);
            this.txtId_Transaksi.Name = "txtId_Transaksi";
            this.txtId_Transaksi.Size = new System.Drawing.Size(194, 22);
            this.txtId_Transaksi.TabIndex = 6;
            // 
            // txtId_Barang
            // 
            this.txtId_Barang.Location = new System.Drawing.Point(202, 81);
            this.txtId_Barang.Name = "txtId_Barang";
            this.txtId_Barang.Size = new System.Drawing.Size(194, 22);
            this.txtId_Barang.TabIndex = 7;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(202, 120);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(194, 22);
            this.txtJumlah.TabIndex = 8;
            // 
            // txtHarga_Satuan
            // 
            this.txtHarga_Satuan.Location = new System.Drawing.Point(202, 159);
            this.txtHarga_Satuan.Name = "txtHarga_Satuan";
            this.txtHarga_Satuan.Size = new System.Drawing.Size(194, 22);
            this.txtHarga_Satuan.TabIndex = 9;
            // 
            // bttnTambah
            // 
            this.bttnTambah.Location = new System.Drawing.Point(576, 40);
            this.bttnTambah.Name = "bttnTambah";
            this.bttnTambah.Size = new System.Drawing.Size(122, 40);
            this.bttnTambah.TabIndex = 1;
            this.bttnTambah.Text = "Tambah";
            this.bttnTambah.UseVisualStyleBackColor = true;
            this.bttnTambah.Click += new System.EventHandler(this.BtnTambah);
            // 
            // bttnHapus
            // 
            this.bttnHapus.Location = new System.Drawing.Point(576, 101);
            this.bttnHapus.Name = "bttnHapus";
            this.bttnHapus.Size = new System.Drawing.Size(122, 36);
            this.bttnHapus.TabIndex = 2;
            this.bttnHapus.Text = "Hapus";
            this.bttnHapus.UseVisualStyleBackColor = true;
            this.bttnHapus.Click += new System.EventHandler(this.BtnHapus);
            // 
            // bttnUbah
            // 
            this.bttnUbah.Location = new System.Drawing.Point(576, 160);
            this.bttnUbah.Name = "bttnUbah";
            this.bttnUbah.Size = new System.Drawing.Size(122, 36);
            this.bttnUbah.TabIndex = 3;
            this.bttnUbah.Text = "Ubah";
            this.bttnUbah.UseVisualStyleBackColor = true;
            this.bttnUbah.Click += new System.EventHandler(this.BtnUbah);
            // 
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(576, 220);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(122, 36);
            this.bttnRefresh.TabIndex = 4;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.BtnRefresh);
            this.dgvSparepart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSparepart_CellContentClick);
            // 
            // dgvSparepart
            // 
            this.dgvSparepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSparepart.Location = new System.Drawing.Point(12, 268);
            this.dgvSparepart.Name = "dgvSparepart";
            this.dgvSparepart.RowHeadersWidth = 51;
            this.dgvSparepart.RowTemplate.Height = 24;
            this.dgvSparepart.Size = new System.Drawing.Size(776, 170);
            this.dgvSparepart.TabIndex = 5;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSparepart);
            this.Controls.Add(this.bttnRefresh);
            this.Controls.Add(this.bttnUbah);
            this.Controls.Add(this.bttnHapus);
            this.Controls.Add(this.bttnTambah);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSparepart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtId_Transaksi;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.TextBox txtHarga_Satuan;
        private System.Windows.Forms.TextBox txtId_Detail;
        private System.Windows.Forms.TextBox txtId_Barang;
        private System.Windows.Forms.Button bttnTambah;
        private System.Windows.Forms.Button bttnHapus;
        private System.Windows.Forms.Button bttnUbah;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.DataGridView dgvSparepart;
    }
}