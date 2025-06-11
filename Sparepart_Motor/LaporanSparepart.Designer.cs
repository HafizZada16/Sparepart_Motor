namespace Sparepart_Motor
{
    partial class LaporanSparepart
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
            this.reportViewerSparepart = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerSparepart
            // 
            this.reportViewerSparepart.Location = new System.Drawing.Point(12, 12);
            this.reportViewerSparepart.Name = "reportViewerSparepart";
            this.reportViewerSparepart.Size = new System.Drawing.Size(776, 426);
            this.reportViewerSparepart.TabIndex = 0;
            this.reportViewerSparepart.Load += new System.EventHandler(this.LaporanSparepart_Load);
            // 
            // LaporanSparepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerSparepart);
            this.Name = "LaporanSparepart";
            this.Text = "LaporanSparepart";
            this.Load += new System.EventHandler(this.LaporanSparepart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerSparepart;
    }
}