﻿namespace Sparepart_Motor
{
    partial class LaporanPengguna
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
            this.reportViewerPengguna = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPengguna
            // 
            this.reportViewerPengguna.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanPengguna.rdlc";
            this.reportViewerPengguna.Location = new System.Drawing.Point(50, 31);
            this.reportViewerPengguna.Name = "reportViewerPengguna";
            this.reportViewerPengguna.Size = new System.Drawing.Size(706, 386);
            this.reportViewerPengguna.TabIndex = 0;
            this.reportViewerPengguna.Load += new System.EventHandler(this.LaporanPengguna_Load);
            // 
            // LaporanPengguna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPengguna);
            this.Name = "LaporanPengguna";
            this.Text = "LaporanPengguna";
            this.Load += new System.EventHandler(this.LaporanPengguna_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPengguna;
    }
}