namespace Sparepart_Motor
{
    partial class Form2
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
            this.txtId_Barang = new System.Windows.Forms.TextBox();
            this.txtNama_Barang = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.bttnTambah = new System.Windows.Forms.Button();
            this.bttnHapus = new System.Windows.Forms.Button();
            this.bttnUbah = new System.Windows.Forms.Button();
            this.bttnRefresh = new System.Windows.Forms.Button();
            this.dgvSparepart = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.txtId_Barang, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNama_Barang, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHarga, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(120, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id_Barang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Harga";
            // 
            // txtId_Barang
            // 
            this.txtId_Barang.Location = new System.Drawing.Point(164, 3);
            this.txtId_Barang.Name = "txtId_Barang";
            this.txtId_Barang.Size = new System.Drawing.Size(156, 22);
            this.txtId_Barang.TabIndex = 3;
            // 
            // txtNama_Barang
            // 
            this.txtNama_Barang.Location = new System.Drawing.Point(164, 40);
            this.txtNama_Barang.Name = "txtNama_Barang";
            this.txtNama_Barang.Size = new System.Drawing.Size(156, 22);
            this.txtNama_Barang.TabIndex = 4;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(164, 73);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(156, 22);
            this.txtHarga.TabIndex = 5;
            // 
            // bttnTambah
            // 
            this.bttnTambah.Location = new System.Drawing.Point(558, 36);
            this.bttnTambah.Name = "bttnTambah";
            this.bttnTambah.Size = new System.Drawing.Size(114, 48);
            this.bttnTambah.TabIndex = 1;
            this.bttnTambah.Text = "Tambah";
            this.bttnTambah.UseVisualStyleBackColor = true;
            this.bttnTambah.Click += new System.EventHandler(this.BtnTambah);
            // 
            // bttnHapus
            // 
            this.bttnHapus.Location = new System.Drawing.Point(558, 90);
            this.bttnHapus.Name = "bttnHapus";
            this.bttnHapus.Size = new System.Drawing.Size(114, 48);
            this.bttnHapus.TabIndex = 2;
            this.bttnHapus.Text = "Hapus";
            this.bttnHapus.UseVisualStyleBackColor = true;
            this.bttnHapus.Click += new System.EventHandler(this.BtnHapus);
            // 
            // bttnUbah
            // 
            this.bttnUbah.Location = new System.Drawing.Point(558, 144);
            this.bttnUbah.Name = "bttnUbah";
            this.bttnUbah.Size = new System.Drawing.Size(114, 48);
            this.bttnUbah.TabIndex = 3;
            this.bttnUbah.Text = "Ubah";
            this.bttnUbah.UseVisualStyleBackColor = true;
            this.bttnUbah.Click += new System.EventHandler(this.BtnUbah);
            // 
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(558, 198);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(114, 48);
            this.bttnRefresh.TabIndex = 4;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.BtnRefresh);
            // 
            // dgvSparepart
            // 
            this.dgvSparepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSparepart.Location = new System.Drawing.Point(20, 263);
            this.dgvSparepart.Name = "dgvSparepart";
            this.dgvSparepart.RowHeadersWidth = 51;
            this.dgvSparepart.RowTemplate.Height = 24;
            this.dgvSparepart.Size = new System.Drawing.Size(754, 175);
            this.dgvSparepart.TabIndex = 5;
            this.dgvSparepart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSparepart_CellContentClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(690, 122);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(84, 35);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(690, 177);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(84, 33);
            this.btnAnalyze.TabIndex = 7;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvSparepart);
            this.Controls.Add(this.bttnRefresh);
            this.Controls.Add(this.bttnUbah);
            this.Controls.Add(this.bttnHapus);
            this.Controls.Add(this.bttnTambah);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Sparepart";
            this.Load += new System.EventHandler(this.Form2_Load);
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
        private System.Windows.Forms.TextBox txtId_Barang;
        private System.Windows.Forms.TextBox txtNama_Barang;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Button bttnTambah;
        private System.Windows.Forms.Button bttnHapus;
        private System.Windows.Forms.Button bttnUbah;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.DataGridView dgvSparepart;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
    }
}