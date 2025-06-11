namespace Sparepart_Motor
{
    partial class LaporanDetail
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
            this.reportViewerDetail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerDetail
            // 
            this.reportViewerDetail.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanDetail.rdlc";
            this.reportViewerDetail.Location = new System.Drawing.Point(12, 24);
            this.reportViewerDetail.Name = "reportViewerDetail";
            this.reportViewerDetail.Size = new System.Drawing.Size(776, 393);
            this.reportViewerDetail.TabIndex = 0;
            // 
            // LaporanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerDetail);
            this.Name = "LaporanDetail";
            this.Text = "LaporanDetail";
            this.Load += new System.EventHandler(this.LaporanDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDetail;
    }
}