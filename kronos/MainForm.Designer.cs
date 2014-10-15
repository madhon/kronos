namespace Kronos
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtActLog = new System.Windows.Forms.TextBox();
            this.txtAct = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmdAddAct = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // txtActLog
            // 
            this.txtActLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtActLog.Location = new System.Drawing.Point(12, 27);
            this.txtActLog.Multiline = true;
            this.txtActLog.Name = "txtActLog";
            this.txtActLog.ReadOnly = true;
            this.txtActLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActLog.Size = new System.Drawing.Size(345, 310);
            this.txtActLog.TabIndex = 1;
            // 
            // txtAct
            // 
            this.txtAct.Location = new System.Drawing.Point(91, 345);
            this.txtAct.Name = "txtAct";
            this.txtAct.Size = new System.Drawing.Size(185, 22);
            this.txtAct.TabIndex = 2;
            this.txtAct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAct_KeyDown);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(9, 348);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 13);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "1h 55m";
            // 
            // cmdAddAct
            // 
            this.cmdAddAct.Location = new System.Drawing.Point(282, 343);
            this.cmdAddAct.Name = "cmdAddAct";
            this.cmdAddAct.Size = new System.Drawing.Size(75, 23);
            this.cmdAddAct.TabIndex = 4;
            this.cmdAddAct.Text = "&Add";
            this.cmdAddAct.UseVisualStyleBackColor = true;
            this.cmdAddAct.Click += new System.EventHandler(this.OnAddActivity);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 370);
            this.Controls.Add(this.cmdAddAct);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtAct);
            this.Controls.Add(this.txtActLog);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Kronos";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox txtActLog;
        private System.Windows.Forms.TextBox txtAct;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button cmdAddAct;
    }
}

