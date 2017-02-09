namespace HL7Explorer
{
    partial class frmTriggerEventAddEdit
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
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMessageType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHL7Versions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsOptional = new System.Windows.Forms.CheckBox();
            this.chkIsRepeatable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSequence = new System.Windows.Forms.TextBox();
            this.gridSegments = new System.Windows.Forms.DataGridView();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRepeating = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddSegment = new System.Windows.Forms.Button();
            this.txtSegment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEventType
            // 
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(309, 36);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(121, 21);
            this.cmbEventType.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Event Type:";
            // 
            // cmbMessageType
            // 
            this.cmbMessageType.FormattingEnabled = true;
            this.cmbMessageType.Location = new System.Drawing.Point(98, 89);
            this.cmbMessageType.Name = "cmbMessageType";
            this.cmbMessageType.Size = new System.Drawing.Size(121, 21);
            this.cmbMessageType.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Message Type:";
            // 
            // cmbHL7Versions
            // 
            this.cmbHL7Versions.FormattingEnabled = true;
            this.cmbHL7Versions.Location = new System.Drawing.Point(98, 62);
            this.cmbHL7Versions.Name = "cmbHL7Versions";
            this.cmbHL7Versions.Size = new System.Drawing.Size(121, 21);
            this.cmbHL7Versions.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Version:";
            // 
            // chkIsOptional
            // 
            this.chkIsOptional.AutoSize = true;
            this.chkIsOptional.Location = new System.Drawing.Point(365, 93);
            this.chkIsOptional.Name = "chkIsOptional";
            this.chkIsOptional.Size = new System.Drawing.Size(65, 17);
            this.chkIsOptional.TabIndex = 13;
            this.chkIsOptional.Text = "Optional";
            this.chkIsOptional.UseVisualStyleBackColor = true;
            // 
            // chkIsRepeatable
            // 
            this.chkIsRepeatable.AutoSize = true;
            this.chkIsRepeatable.Location = new System.Drawing.Point(241, 93);
            this.chkIsRepeatable.Name = "chkIsRepeatable";
            this.chkIsRepeatable.Size = new System.Drawing.Size(81, 17);
            this.chkIsRepeatable.TabIndex = 14;
            this.chkIsRepeatable.Text = "Repeatable";
            this.chkIsRepeatable.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sequence:";
            // 
            // txtSequence
            // 
            this.txtSequence.Location = new System.Drawing.Point(309, 62);
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(121, 20);
            this.txtSequence.TabIndex = 16;
            // 
            // gridSegments
            // 
            this.gridSegments.AllowUserToAddRows = false;
            this.gridSegments.AllowUserToDeleteRows = false;
            this.gridSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequence,
            this.colLength,
            this.colName,
            this.colDataType,
            this.colIsRequired,
            this.colRepeating});
            this.gridSegments.Location = new System.Drawing.Point(15, 141);
            this.gridSegments.Name = "gridSegments";
            this.gridSegments.ReadOnly = true;
            this.gridSegments.Size = new System.Drawing.Size(1062, 503);
            this.gridSegments.TabIndex = 17;
            // 
            // colSequence
            // 
            this.colSequence.DataPropertyName = "Sequence";
            this.colSequence.HeaderText = "Sequence";
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DataType";
            this.colDataType.HeaderText = "Data Type";
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            // 
            // colIsRequired
            // 
            this.colIsRequired.DataPropertyName = "IsRequired";
            this.colIsRequired.HeaderText = "Required";
            this.colIsRequired.Name = "colIsRequired";
            this.colIsRequired.ReadOnly = true;
            // 
            // colRepeating
            // 
            this.colRepeating.DataPropertyName = "IsRepeated";
            this.colRepeating.HeaderText = "Repeated";
            this.colRepeating.Name = "colRepeating";
            this.colRepeating.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(993, 650);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddSegment
            // 
            this.btnAddSegment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSegment.Location = new System.Drawing.Point(903, 650);
            this.btnAddSegment.Name = "btnAddSegment";
            this.btnAddSegment.Size = new System.Drawing.Size(84, 23);
            this.btnAddSegment.TabIndex = 19;
            this.btnAddSegment.Text = "Add Segment";
            this.btnAddSegment.UseVisualStyleBackColor = true;
            // 
            // txtSegment
            // 
            this.txtSegment.Location = new System.Drawing.Point(98, 36);
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(121, 20);
            this.txtSegment.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Segment:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Segments:";
            // 
            // frmTriggerEventAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 685);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddSegment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridSegments);
            this.Controls.Add(this.txtSequence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIsRepeatable);
            this.Controls.Add(this.chkIsOptional);
            this.Controls.Add(this.cmbEventType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMessageType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbHL7Versions);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(711, 494);
            this.Name = "frmTriggerEventAddEdit";
            this.Text = "Trigger Event: Add/Update";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbHL7Versions, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbMessageType, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbEventType, 0);
            this.Controls.SetChildIndex(this.chkIsOptional, 0);
            this.Controls.SetChildIndex(this.chkIsRepeatable, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtSequence, 0);
            this.Controls.SetChildIndex(this.gridSegments, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnAddSegment, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtSegment, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridSegments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMessageType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHL7Versions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsOptional;
        private System.Windows.Forms.CheckBox chkIsRepeatable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSequence;
        private System.Windows.Forms.DataGridView gridSegments;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddSegment;
        private System.Windows.Forms.TextBox txtSegment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRequired;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRepeating;
        private System.Windows.Forms.Label label6;
    }
}