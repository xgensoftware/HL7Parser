namespace HL7Explorer
{
    partial class frmHL7DataFileList
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
            this.lstFileData = new System.Windows.Forms.ListBox();
            this.bgwParse = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lstFileData
            // 
            this.lstFileData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileData.FormattingEnabled = true;
            this.lstFileData.Location = new System.Drawing.Point(0, 24);
            this.lstFileData.Name = "lstFileData";
            this.lstFileData.Size = new System.Drawing.Size(530, 216);
            this.lstFileData.TabIndex = 1;
            // 
            // frmHL7DataFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(530, 240);
            this.Controls.Add(this.lstFileData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHL7DataFileList";
            this.Load += new System.EventHandler(this.frmHL7DataFileList_Load);
            this.Controls.SetChildIndex(this.lstFileData, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFileData;
        private System.ComponentModel.BackgroundWorker bgwParse;
    }
}
