namespace HL7Explorer
{
    partial class frmDatabaseView
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
            this.gridSegment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridSegment)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSegment
            // 
            this.gridSegment.AllowUserToAddRows = false;
            this.gridSegment.AllowUserToDeleteRows = false;
            this.gridSegment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSegment.Location = new System.Drawing.Point(0, 0);
            this.gridSegment.Name = "gridSegment";
            this.gridSegment.ReadOnly = true;
            this.gridSegment.Size = new System.Drawing.Size(723, 446);
            this.gridSegment.TabIndex = 0;
            // 
            // frmDatabaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 446);
            this.Controls.Add(this.gridSegment);
            this.Name = "frmDatabaseView";
            this.Text = "frmDatabaseView";
            this.Load += new System.EventHandler(this.frmDatabaseView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSegment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSegment;
    }
}