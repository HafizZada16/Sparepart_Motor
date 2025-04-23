namespace Sparepart_Motor
{
    partial class Form1
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
            this.txt3 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.Label();
            this.txtId_Pengguna = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelepon = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Controls.Add(this.txt3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtId_Pengguna, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNama, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTelepon, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAlamat, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt5, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 247);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt3
            // 
            this.txt3.AutoSize = true;
            this.txt3.Location = new System.Drawing.Point(3, 98);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(41, 16);
            this.txt3.TabIndex = 1;
            this.txt3.Text = "Email";
            // 
            // txt1
            // 
            this.txt1.AutoSize = true;
            this.txt1.Location = new System.Drawing.Point(3, 0);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(87, 16);
            this.txt1.TabIndex = 0;
            this.txt1.Text = "Id_Pengguna";
            // 
            // txt2
            // 
            this.txt2.AutoSize = true;
            this.txt2.Location = new System.Drawing.Point(3, 49);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(44, 16);
            this.txt2.TabIndex = 1;
            this.txt2.Text = "Nama";
            // 
            // txt4
            // 
            this.txt4.AutoSize = true;
            this.txt4.Location = new System.Drawing.Point(3, 147);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(58, 16);
            this.txt4.TabIndex = 2;
            this.txt4.Text = "Telepon";
            // 
            // txtId_Pengguna
            // 
            this.txtId_Pengguna.Location = new System.Drawing.Point(166, 3);
            this.txtId_Pengguna.Name = "txtId_Pengguna";
            this.txtId_Pengguna.Size = new System.Drawing.Size(157, 22);
            this.txtId_Pengguna.TabIndex = 3;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(166, 52);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(157, 22);
            this.txtNama.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(166, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(157, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // txtTelepon
            // 
            this.txtTelepon.Location = new System.Drawing.Point(166, 150);
            this.txtTelepon.Name = "txtTelepon";
            this.txtTelepon.Size = new System.Drawing.Size(157, 22);
            this.txtTelepon.TabIndex = 6;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(166, 199);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(157, 22);
            this.txtAlamat.TabIndex = 7;
            // 
            // txt5
            // 
            this.txt5.AutoSize = true;
            this.txt5.Location = new System.Drawing.Point(3, 196);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(49, 16);
            this.txt5.TabIndex = 8;
            this.txt5.Text = "Alamat";
            // 
            // bttnTambah
            // 
            this.bttnTambah.Location = new System.Drawing.Point(543, 31);
            this.bttnTambah.Name = "bttnTambah";
            this.bttnTambah.Size = new System.Drawing.Size(109, 43);
            this.bttnTambah.TabIndex = 1;
            this.bttnTambah.Text = "Tambah";
            this.bttnTambah.UseVisualStyleBackColor = true;
            this.bttnTambah.Click += new System.EventHandler(this.BtnTambah);
            // 
            // bttnHapus
            // 
            this.bttnHapus.Location = new System.Drawing.Point(543, 90);
            this.bttnHapus.Name = "bttnHapus";
            this.bttnHapus.Size = new System.Drawing.Size(109, 43);
            this.bttnHapus.TabIndex = 2;
            this.bttnHapus.Text = "Hapus";
            this.bttnHapus.UseVisualStyleBackColor = true;
            this.bttnHapus.Click += new System.EventHandler(this.BtnHapus);
            // 
            // bttnUbah
            // 
            this.bttnUbah.Location = new System.Drawing.Point(543, 149);
            this.bttnUbah.Name = "bttnUbah";
            this.bttnUbah.Size = new System.Drawing.Size(109, 43);
            this.bttnUbah.TabIndex = 3;
            this.bttnUbah.Text = "Ubah";
            this.bttnUbah.UseVisualStyleBackColor = true;
            this.bttnUbah.Click += new System.EventHandler(this.BtnUbah);
            // 
            // bttnRefresh
            // 
            this.bttnRefresh.Location = new System.Drawing.Point(543, 207);
            this.bttnRefresh.Name = "bttnRefresh";
            this.bttnRefresh.Size = new System.Drawing.Size(109, 43);
            this.bttnRefresh.TabIndex = 4;
            this.bttnRefresh.Text = "Refresh";
            this.bttnRefresh.UseVisualStyleBackColor = true;
            this.bttnRefresh.Click += new System.EventHandler(this.BtnRefresh);
            // 
            // dgvSparepart
            // 
            this.dgvSparepart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSparepart.Location = new System.Drawing.Point(59, 305);
            this.dgvSparepart.Name = "dgvSparepart";
            this.dgvSparepart.RowHeadersWidth = 51;
            this.dgvSparepart.RowTemplate.Height = 24;
            this.dgvSparepart.Size = new System.Drawing.Size(729, 236);
            this.dgvSparepart.TabIndex = 5;
            this.dgvSparepart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSparepart_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 563);
            this.Controls.Add(this.dgvSparepart);
            this.Controls.Add(this.bttnRefresh);
            this.Controls.Add(this.bttnUbah);
            this.Controls.Add(this.bttnHapus);
            this.Controls.Add(this.bttnTambah);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Pengguna";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSparepart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.TextBox txtId_Pengguna;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txt2;
        private System.Windows.Forms.Label txt3;
        private System.Windows.Forms.Label txt4;
        private System.Windows.Forms.Label txt5;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelepon;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Button bttnTambah;
        private System.Windows.Forms.Button bttnHapus;
        private System.Windows.Forms.Button bttnUbah;
        private System.Windows.Forms.Button bttnRefresh;
        private System.Windows.Forms.DataGridView dgvSparepart;

        
    }
}

