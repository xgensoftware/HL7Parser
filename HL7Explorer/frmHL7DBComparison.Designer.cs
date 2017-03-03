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
            this.lstMapping = new System.Windows.Forms.ListBox();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tables:";
            // 
            // cmbDBTables
            // 
            this.cmbDBTables.FormattingEnabled = true;
            this.cmbDBTables.Location = new System.Drawing.Point(12, 56);
            this.cmbDBTables.Name = "cmbDBTables";
            this.cmbDBTables.Size = new System.Drawing.Size(300, 21);
            this.cmbDBTables.TabIndex = 2;
            // 
            // lstDBColumns
            // 
            this.lstDBColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDBColumns.FormattingEnabled = true;
            this.lstDBColumns.Location = new System.Drawing.Point(12, 83);
            this.lstDBColumns.Name = "lstDBColumns";
            this.lstDBColumns.ScrollAlwaysVisible = true;
            this.lstDBColumns.Size = new System.Drawing.Size(300, 238);
            this.lstDBColumns.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segment:";
            // 
            // cmbSegment
            // 
            this.cmbSegment.FormattingEnabled = true;
            this.cmbSegment.Location = new System.Drawing.Point(336, 56);
            this.cmbSegment.Name = "cmbSegment";
            this.cmbSegment.Size = new System.Drawing.Size(300, 21);
            this.cmbSegment.TabIndex = 6;
            // 
            // lstSegColumns
            // 
            this.lstSegColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSegColumns.FormattingEnabled = true;
            this.lstSegColumns.Location = new System.Drawing.Point(336, 83);
            this.lstSegColumns.Name = "lstSegColumns";
            this.lstSegColumns.ScrollAlwaysVisible = true;
            this.lstSegColumns.Size = new System.Drawing.Size(300, 238);
            this.lstSegColumns.TabIndex = 8;
            // 
            // lstMapping
            // 
            this.lstMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMapping.FormattingEnabled = true;
            this.lstMapping.Location = new System.Drawing.Point(723, 83);
            this.lstMapping.Name = "lstMapping";
            this.lstMapping.Size = new System.Drawing.Size(300, 238);
            this.lstMapping.TabIndex = 9;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(642, 83);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 10;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(642, 112);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(720, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mapping:";
            // 
            // frmHL7DBComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 662);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.lstMapping);
            this.Controls.Add(this.lstSegColumns);
            this.Controls.Add(this.cmbSegment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstDBColumns);
            this.Controls.Add(this.cmbDBTables);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1052, 700);
            this.Name = "frmHL7DBComparison";
            this.Text = "frmHL7DBComparison";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbDBTables, 0);
            this.Controls.SetChildIndex(this.lstDBColumns, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbSegment, 0);
            this.Controls.SetChildIndex(this.lstSegColumns, 0);
            this.Controls.SetChildIndex(this.lstMapping, 0);
            this.Controls.SetChildIndex(this.btnMap, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.label2, 0);
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
        private System.Windows.Forms.ListBox lstMapping;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label2;
    }
}