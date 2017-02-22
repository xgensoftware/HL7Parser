namespace HL7Explorer
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuTriggerBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemViewHL7Message = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFile,
            this.toolsToolStripMenuTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(312, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuFile
            // 
            this.toolStripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItemClose});
            this.toolStripMenuFile.Name = "toolStripMenuFile";
            this.toolStripMenuFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuFile.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolsToolStripMenuTools
            // 
            this.toolsToolStripMenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuTriggerBuild,
            this.toolStripMenuItemViewHL7Message});
            this.toolsToolStripMenuTools.Name = "toolsToolStripMenuTools";
            this.toolsToolStripMenuTools.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuTools.Text = "Tools";
            // 
            // toolStripMenuTriggerBuild
            // 
            this.toolStripMenuTriggerBuild.Name = "toolStripMenuTriggerBuild";
            this.toolStripMenuTriggerBuild.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuTriggerBuild.Text = "Trigger Event Builder";
            this.toolStripMenuTriggerBuild.Click += new System.EventHandler(this.toolStripMenuTriggerBuild_Click);
            // 
            // toolStripMenuItemViewHL7Message
            // 
            this.toolStripMenuItemViewHL7Message.Name = "toolStripMenuItemViewHL7Message";
            this.toolStripMenuItemViewHL7Message.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemViewHL7Message.Text = "View HL7Message";
            this.toolStripMenuItemViewHL7Message.Click += new System.EventHandler(this.toolStripMenuItemViewHL7Message_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemClose.Text = "Close";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 75);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFile;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuTools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuTriggerBuild;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemViewHL7Message;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    }
}

