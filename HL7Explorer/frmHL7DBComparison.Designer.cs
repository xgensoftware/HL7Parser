namespace HL7Explorer
{
    partial class frmHL7DBComparison
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDBTables = new System.Windows.Forms.ComboBox();
            this.lstDBColumns = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSegment = new System.Windows.Forms.ComboBox();
            this.lstSegColumns = new System.Windows.Forms.ListBox();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tvSegmentTableMap = new System.Windows.Forms.TreeView();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.txtMapFilePath = new System.Windows.Forms.TextBox();
            this.btnFindFile = new System.Windows.Forms.Button();
            this.btnLoadMapFile = new System.Windows.Forms.Button();
            this.cmbMessageType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHL7Versions = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tables:";
            // 
            // cmbDBTables
            // 
            this.cmbDBTables.FormattingEnabled = true;
            this.cmbDBTables.Location = new System.Drawing.Point(338, 124);
            this.cmbDBTables.Name = "cmbDBTables";
            this.cmbDBTables.Size = new System.Drawing.Size(300, 21);
            this.cmbDBTables.TabIndex = 2;
            // 
            // lstDBColumns
            // 
            this.lstDBColumns.FormattingEnabled = true;
            this.lstDBColumns.Location = new System.Drawing.Point(338, 151);
            this.lstDBColumns.Name = "lstDBColumns";
            this.lstDBColumns.ScrollAlwaysVisible = true;
            this.lstDBColumns.Size = new System.Drawing.Size(300, 212);
            this.lstDBColumns.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segment:";
            // 
            // cmbSegment
            // 
            this.cmbSegment.FormattingEnabled = true;
            this.cmbSegment.Location = new System.Drawing.Point(15, 124);
            this.cmbSegment.Name = "cmbSegment";
            this.cmbSegment.Size = new System.Drawing.Size(300, 21);
            this.cmbSegment.TabIndex = 6;
            // 
            // lstSegColumns
            // 
            this.lstSegColumns.FormattingEnabled = true;
            this.lstSegColumns.Location = new System.Drawing.Point(15, 151);
            this.lstSegColumns.Name = "lstSegColumns";
            this.lstSegColumns.ScrollAlwaysVisible = true;
            this.lstSegColumns.Size = new System.Drawing.Size(300, 212);
            this.lstSegColumns.TabIndex = 8;
            // 
            // btnMap
            // 
            this.btnMap.Enabled = false;
            this.btnMap.Location = new System.Drawing.Point(482, 369);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 10;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(563, 369);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tvSegmentTableMap
            // 
            this.tvSegmentTableMap.Location = new System.Drawing.Point(15, 400);
            this.tvSegmentTableMap.Name = "tvSegmentTableMap";
            this.tvSegmentTableMap.Size = new System.Drawing.Size(623, 270);
            this.tvSegmentTableMap.TabIndex = 12;
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Enabled = false;
            this.btnSaveMap.Location = new System.Drawing.Point(563, 676);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMap.TabIndex = 13;
            this.btnSaveMap.Text = "Save";
            this.btnSaveMap.UseVisualStyleBackColor = true;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // txtMapFilePath
            // 
            this.txtMapFilePath.Enabled = false;
            this.txtMapFilePath.Location = new System.Drawing.Point(68, 31);
            this.txtMapFilePath.Name = "txtMapFilePath";
            this.txtMapFilePath.Size = new System.Drawing.Size(470, 20);
            this.txtMapFilePath.TabIndex = 14;
            // 
            // btnFindFile
            // 
            this.btnFindFile.Location = new System.Drawing.Point(544, 31);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(26, 20);
            this.btnFindFile.TabIndex = 15;
            this.btnFindFile.Text = "...";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // btnLoadMapFile
            // 
            this.btnLoadMapFile.Enabled = false;
            this.btnLoadMapFile.Location = new System.Drawing.Point(576, 31);
            this.btnLoadMapFile.Name = "btnLoadMapFile";
            this.btnLoadMapFile.Size = new System.Drawing.Size(62, 20);
            this.btnLoadMapFile.TabIndex = 16;
            this.btnLoadMapFile.Text = "Load";
            this.btnLoadMapFile.UseVisualStyleBackColor = true;
            this.btnLoadMapFile.Click += new System.EventHandler(this.btnLoadMapFile_Click);
            // 
            // cmbMessageType
            // 
            this.cmbMessageType.FormattingEnabled = true;
            this.cmbMessageType.Location = new System.Drawing.Point(110, 68);
            this.cmbMessageType.Name = "cmbMessageType";
            this.cmbMessageType.Size = new System.Drawing.Size(121, 21);
            this.cmbMessageType.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Message Type:";
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(318, 68);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(121, 21);
            this.cmbEventType.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Event Type:";
            // 
            // cmbHL7Versions
            // 
            this.cmbHL7Versions.FormattingEnabled = true;
            this.cmbHL7Versions.Location = new System.Drawing.Point(517, 68);
            this.cmbHL7Versions.Name = "cmbHL7Versions";
            this.cmbHL7Versions.Size = new System.Drawing.Size(121, 21);
            this.cmbHL7Versions.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Version:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Map File:";
            // 
            // frmHL7DBComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 709);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbHL7Versions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEventType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMessageType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadMapFile);
            this.Controls.Add(this.btnFindFile);
            this.Controls.Add(this.txtMapFilePath);
            this.Controls.Add(this.btnSaveMap);
            this.Controls.Add(this.tvSegmentTableMap);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.lstSegColumns);
            this.Controls.Add(this.cmbSegment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstDBColumns);
            this.Controls.Add(this.cmbDBTables);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(669, 747);
            this.MinimumSize = new System.Drawing.Size(669, 747);
            this.Name = "frmHL7DBComparison";
            this.Text = "frmHL7DBComparison";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbDBTables, 0);
            this.Controls.SetChildIndex(this.lstDBColumns, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbSegment, 0);
            this.Controls.SetChildIndex(this.lstSegColumns, 0);
            this.Controls.SetChildIndex(this.btnMap, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.tvSegmentTableMap, 0);
            this.Controls.SetChildIndex(this.btnSaveMap, 0);
            this.Controls.SetChildIndex(this.txtMapFilePath, 0);
            this.Controls.SetChildIndex(this.btnFindFile, 0);
            this.Controls.SetChildIndex(this.btnLoadMapFile, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbMessageType, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbEventType, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbHL7Versions, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDBTables;
        private System.Windows.Forms.ListBox lstDBColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSegment;
        private System.Windows.Forms.ListBox lstSegColumns;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TreeView tvSegmentTableMap;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.TextBox txtMapFilePath;
        private System.Windows.Forms.Button btnFindFile;
        private System.Windows.Forms.Button btnLoadMapFile;
        private System.Windows.Forms.ComboBox cmbMessageType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHL7Versions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}