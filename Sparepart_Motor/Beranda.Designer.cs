namespace Sparepart_Motor
{
    partial class Beranda
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
            this.btnPengguna = new System.Windows.Forms.Button();
            this.btnSparepart = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPengguna
            // 
            this.btnPengguna.Location = new System.Drawing.Point(343, 96);
            this.btnPengguna.Name = "btnPengguna";
            this.btnPengguna.Size = new System.Drawing.Size(110, 41);
            this.btnPengguna.TabIndex = 0;
            this.btnPengguna.Text = "Pengguna";
            this.btnPengguna.UseVisualStyleBackColor = true;
            this.btnPengguna.Click += new System.EventHandler(this.btnBukaForm1_Click);
            // 
            // btnSparepart
            // 
            this.btnSparepart.Location = new System.Drawing.Point(343, 156);
            this.btnSparepart.Name = "btnSparepart";
            this.btnSparepart.Size = new System.Drawing.Size(110, 41);
            this.btnSparepart.TabIndex = 1;
            this.btnSparepart.Text = "Sparepart";
            this.btnSparepart.UseVisualStyleBackColor = true;
            this.btnSparepart.Click += new System.EventHandler(this.btnBukaForm2_Click);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(343, 218);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(110, 41);
            this.btnTransaksi.TabIndex = 2;
            this.btnTransaksi.Text = "Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Detail";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Beranda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.btnSparepart);
            this.Controls.Add(this.btnPengguna);
            this.Name = "Beranda";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button btnPengguna;
        private System.Windows.Forms.Button btnSparepart;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button button1;
    }
}