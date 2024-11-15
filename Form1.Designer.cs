namespace BuyiToolbar
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
            this.components = new System.ComponentModel.Container();
            this.BgIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BgIcon
            // 
            this.BgIcon.ContextMenuStrip = this.MainMenu;
            this.BgIcon.Text = "Buyi Toolbar";
            this.BgIcon.Visible = true;
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.MainMenu.Name = "mainMenu";
            this.MainMenu.Size = new System.Drawing.Size(90, 30);
            this.MainMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MainMenu_Opening);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem1});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(89, 26);
            this.aToolStripMenuItem.Text = "a";
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(89, 26);
            this.aToolStripMenuItem1.Text = "a";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 247);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buyi Toolbar";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon BgIcon;
        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem1;
    }
}

