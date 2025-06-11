namespace Sparepart_Motor
{
    partial class LaporanTransaksi
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
            this.reportViewerTransaksi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerTransaksi
            // 
            this.reportViewerTransaksi.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanTransaksi.rdlc";
            this.reportViewerTransaksi.Location = new System.Drawing.Point(12, 21);
            this.reportViewerTransaksi.Name = "reportViewerTransaksi";
            this.reportViewerTransaksi.Size = new System.Drawing.Size(776, 395);
            this.reportViewerTransaksi.TabIndex = 0;
            this.reportViewerTransaksi.Load += new System.EventHandler(this.LaporanTransaksi_Load);
            // 
            // LaporanTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerTransaksi);
            this.Name = "LaporanTransaksi";
            this.Text = "LaporanTransaksi";
            this.Load += new System.EventHandler(this.LaporanTransaksi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTransaksi;
    }
}