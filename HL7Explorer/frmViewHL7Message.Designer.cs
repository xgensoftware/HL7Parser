namespace HL7Explorer
{
    partial class frmViewHL7Message
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewHL7Message));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtRawHL7Message = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoadHL7DatFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDBCompare = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvSegments = new System.Windows.Forms.TreeView();
            this.grdSegmentFields = new System.Windows.Forms.DataGridView();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsRepeating = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bgwParser = new System.ComponentModel.BackgroundWorker();
            this.bgwDBCompare = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSegmentFields)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // txtRawHL7Message
            // 
            this.txtRawHL7Message.AllowDrop = true;
            this.txtRawHL7Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRawHL7Message.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRawHL7Message.Location = new System.Drawing.Point(0, 0);
            this.txtRawHL7Message.Multiline = true;
            this.txtRawHL7Message.Name = "txtRawHL7Message";
            this.txtRawHL7Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRawHL7Message.Size = new System.Drawing.Size(1184, 216);
            this.txtRawHL7Message.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripSeparator1,
            this.toolStripButtonLoadHL7DatFile,
            this.toolStripSeparator2,
            this.toolStripButtonDBCompare});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
            this.toolStripButtonLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(126, 22);
            this.toolStripButtonLoad.Text = "Load HL7 Message";
            this.toolStripButtonLoad.ToolTipText = "Load a single HL7 Message file";
            this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLoadHL7DatFile
            // 
            this.toolStripButtonLoadHL7DatFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadHL7DatFile.Image")));
            this.toolStripButtonLoadHL7DatFile.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButtonLoadHL7DatFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadHL7DatFile.Name = "toolStripButtonLoadHL7DatFile";
            this.toolStripButtonLoadHL7DatFile.Size = new System.Drawing.Size(154, 22);
            this.toolStripButtonLoadHL7DatFile.Text = "Load Multi Message File";
            this.toolStripButtonLoadHL7DatFile.ToolTipText = "Load a file with multiple HL7 messages";
            this.toolStripButtonLoadHL7DatFile.Click += new System.EventHandler(this.toolStripButtonLoadHL7DatFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDBCompare
            // 
            this.toolStripButtonDBCompare.Enabled = false;
            this.toolStripButtonDBCompare.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDBCompare.Image")));
            this.toolStripButtonDBCompare.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButtonDBCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDBCompare.Name = "toolStripButtonDBCompare";
            this.toolStripButtonDBCompare.Size = new System.Drawing.Size(94, 22);
            this.toolStripButtonDBCompare.Text = "DB Compare";
            this.toolStripButtonDBCompare.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRawHL7Message);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1184, 663);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvSegments);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1MinSize = 175;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdSegmentFields);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel2MinSize = 400;
            this.splitContainer2.Size = new System.Drawing.Size(1184, 441);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvSegments
            // 
            this.tvSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSegments.ImageIndex = 0;
            this.tvSegments.ImageList = this.imageList1;
            this.tvSegments.Location = new System.Drawing.Point(0, 0);
            this.tvSegments.Name = "tvSegments";
            this.tvSegments.SelectedImageIndex = 0;
            this.tvSegments.Size = new System.Drawing.Size(175, 441);
            this.tvSegments.TabIndex = 0;
            // 
            // grdSegmentFields
            // 
            this.grdSegmentFields.AllowUserToAddRows = false;
            this.grdSegmentFields.AllowUserToDeleteRows = false;
            this.grdSegmentFields.AllowUserToResizeRows = false;
            this.grdSegmentFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSegmentFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequence,
            this.colVersion,
            this.colName,
            this.colValue,
            this.colIsRequired,
            this.colIsRepeating});
            this.grdSegmentFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSegmentFields.Location = new System.Drawing.Point(0, 0);
            this.grdSegmentFields.Name = "grdSegmentFields";
            this.grdSegmentFields.ReadOnly = true;
            this.grdSegmentFields.Size = new System.Drawing.Size(1005, 441);
            this.grdSegmentFields.TabIndex = 0;
            // 
            // colSequence
            // 
            this.colSequence.DataPropertyName = "Sequence";
            this.colSequence.HeaderText = "Sequence";
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Width = 75;
            // 
            // colVersion
            // 
            this.colVersion.DataPropertyName = "Version";
            this.colVersion.HeaderText = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            this.colVersion.Width = 75;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // colValue
            // 
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 300;
            // 
            // colIsRequired
            // 
            this.colIsRequired.DataPropertyName = "IsRequired";
            this.colIsRequired.HeaderText = "Required";
            this.colIsRequired.Name = "colIsRequired";
            this.colIsRequired.ReadOnly = true;
            // 
            // colIsRepeating
            // 
            this.colIsRepeating.DataPropertyName = "IsRepeating";
            this.colIsRepeating.HeaderText = "Repeating";
            this.colIsRepeating.Name = "colIsRepeating";
            this.colIsRepeating.ReadOnly = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder-icon.png");
            this.imageList1.Images.SetKeyName(1, "data-chooser-icon.png");
            this.imageList1.Images.SetKeyName(2, "column-single-icon.png");
            // 
            // frmViewHL7Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 712);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "frmViewHL7Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewHL7Message";
            this.Load += new System.EventHandler(this.frmViewHL7Message_Load);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSegmentFields)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRawHL7Message;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvSegments;
        private System.Windows.Forms.DataGridView grdSegmentFields;
        private System.ComponentModel.BackgroundWorker bgwParser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDBCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRequired;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRepeating;
        private System.ComponentModel.BackgroundWorker bgwDBCompare;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadHL7DatFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imageList1;
    }
}