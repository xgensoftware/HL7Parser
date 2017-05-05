namespace HL7Explorer
{
    partial class HL7QueryConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMessageType = new System.Windows.Forms.ComboBox();
            this.btnSetQueryConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFacility = new System.Windows.Forms.ComboBox();
            this.dtpFileDates = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMessageType);
            this.groupBox1.Controls.Add(this.btnSetQueryConfig);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbFacility);
            this.groupBox1.Controls.Add(this.dtpFileDates);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 168);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbMessageType
            // 
            this.cmbMessageType.FormattingEnabled = true;
            this.cmbMessageType.Location = new System.Drawing.Point(120, 18);
            this.cmbMessageType.Name = "cmbMessageType";
            this.cmbMessageType.Size = new System.Drawing.Size(121, 21);
            this.cmbMessageType.TabIndex = 13;
            // 
            // btnSetQueryConfig
            // 
            this.btnSetQueryConfig.Location = new System.Drawing.Point(350, 139);
            this.btnSetQueryConfig.Name = "btnSetQueryConfig";
            this.btnSetQueryConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSetQueryConfig.TabIndex = 12;
            this.btnSetQueryConfig.Text = "Connect";
            this.btnSetQueryConfig.UseVisualStyleBackColor = true;
            this.btnSetQueryConfig.Click += new System.EventHandler(this.btnSetQueryConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Message Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Facilities:";
            // 
            // cmbFacility
            // 
            this.cmbFacility.FormattingEnabled = true;
            this.cmbFacility.Location = new System.Drawing.Point(120, 45);
            this.cmbFacility.Name = "cmbFacility";
            this.cmbFacility.Size = new System.Drawing.Size(305, 21);
            this.cmbFacility.TabIndex = 0;
            // 
            // dtpFileDates
            // 
            this.dtpFileDates.Location = new System.Drawing.Point(120, 72);
            this.dtpFileDates.Name = "dtpFileDates";
            this.dtpFileDates.Size = new System.Drawing.Size(200, 20);
            this.dtpFileDates.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date Of Files:";
            // 
            // HL7QueryConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 205);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(490, 243);
            this.MinimumSize = new System.Drawing.Size(490, 243);
            this.Name = "HL7QueryConfig";
            this.Text = "HL7QueryConfig";
            this.Load += new System.EventHandler(this.HL7QueryConfig_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFacility;
        private System.Windows.Forms.DateTimePicker dtpFileDates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetQueryConfig;
        private System.Windows.Forms.ComboBox cmbMessageType;
    }
}