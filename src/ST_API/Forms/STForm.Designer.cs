namespace Screentaker.Forms
{
    partial class STForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STForm));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemST = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAreaSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemControlSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUploader = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUplImageShack = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUplDirectUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.contextMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Screentaker.NET\r\n\r\nProfessionelle Screenshots Ihres Desktops.";
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskIcon_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemST,
            this.MenuItemAreaSelector,
            this.MenuItemControlSelector,
            this.MenuItemOpenFile,
            this.MenuItemHistory,
            this.MenuItemUploader,
            this.MenuItemConfig,
            this.toolStripMenuItem1,
            this.MenuItemDonate,
            this.MenuItemHelp,
            this.MenuItemExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(198, 230);
            // 
            // MenuItemST
            // 
            this.MenuItemST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MenuItemST.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemST.ForeColor = System.Drawing.Color.DimGray;
            this.MenuItemST.Name = "MenuItemST";
            this.MenuItemST.Size = new System.Drawing.Size(197, 22);
            this.MenuItemST.Text = "Über Screentaker.NET";
            this.MenuItemST.Click += new System.EventHandler(this.MenuItemST_Click);
            // 
            // MenuItemAreaSelector
            // 
            this.MenuItemAreaSelector.Name = "MenuItemAreaSelector";
            this.MenuItemAreaSelector.Size = new System.Drawing.Size(197, 22);
            this.MenuItemAreaSelector.Text = "Bereich erfassen";
            this.MenuItemAreaSelector.Click += new System.EventHandler(this.Open_Click);
            // 
            // MenuItemControlSelector
            // 
            this.MenuItemControlSelector.Name = "MenuItemControlSelector";
            this.MenuItemControlSelector.Size = new System.Drawing.Size(197, 22);
            this.MenuItemControlSelector.Text = "Element auswählen";
            this.MenuItemControlSelector.Click += new System.EventHandler(this.MenuItemControlSelector_Click);
            // 
            // MenuItemOpenFile
            // 
            this.MenuItemOpenFile.Name = "MenuItemOpenFile";
            this.MenuItemOpenFile.Size = new System.Drawing.Size(197, 22);
            this.MenuItemOpenFile.Text = "Screenshot öffnen";
            this.MenuItemOpenFile.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemHistory
            // 
            this.MenuItemHistory.Name = "MenuItemHistory";
            this.MenuItemHistory.Size = new System.Drawing.Size(197, 22);
            this.MenuItemHistory.Text = "Verlauf öffen";
            this.MenuItemHistory.Click += new System.EventHandler(this.MenuItemHistory_Click);
            // 
            // MenuItemUploader
            // 
            this.MenuItemUploader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUplImageShack,
            this.MenuItemUplDirectUpload,
            this.fTPUploadToolStripMenuItem});
            this.MenuItemUploader.Name = "MenuItemUploader";
            this.MenuItemUploader.Size = new System.Drawing.Size(197, 22);
            this.MenuItemUploader.Text = "Uploader";
            // 
            // MenuItemUplImageShack
            // 
            this.MenuItemUplImageShack.Name = "MenuItemUplImageShack";
            this.MenuItemUplImageShack.Size = new System.Drawing.Size(163, 22);
            this.MenuItemUplImageShack.Text = "ImageShack.us";
            this.MenuItemUplImageShack.Click += new System.EventHandler(this.MenuItemUplImageShack_Click);
            // 
            // MenuItemUplDirectUpload
            // 
            this.MenuItemUplDirectUpload.Name = "MenuItemUplDirectUpload";
            this.MenuItemUplDirectUpload.Size = new System.Drawing.Size(163, 22);
            this.MenuItemUplDirectUpload.Text = "DirectUpload.net";
            this.MenuItemUplDirectUpload.Click += new System.EventHandler(this.MenuItemUplDirectUpload_Click);
            // 
            // fTPUploadToolStripMenuItem
            // 
            this.fTPUploadToolStripMenuItem.Name = "fTPUploadToolStripMenuItem";
            this.fTPUploadToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.fTPUploadToolStripMenuItem.Text = "FTP-Upload";
            this.fTPUploadToolStripMenuItem.Click += new System.EventHandler(this.fTPUploadToolStripMenuItem_Click);
            // 
            // MenuItemConfig
            // 
            this.MenuItemConfig.Name = "MenuItemConfig";
            this.MenuItemConfig.Size = new System.Drawing.Size(197, 22);
            this.MenuItemConfig.Text = "Einstellungen";
            this.MenuItemConfig.Click += new System.EventHandler(this.ConfigToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // MenuItemDonate
            // 
            this.MenuItemDonate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemDonate.ForeColor = System.Drawing.Color.Red;
            this.MenuItemDonate.Name = "MenuItemDonate";
            this.MenuItemDonate.Size = new System.Drawing.Size(197, 22);
            this.MenuItemDonate.Text = "Spenden!";
            this.MenuItemDonate.Click += new System.EventHandler(this.MenuItemDonate_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(197, 22);
            this.MenuItemHelp.Text = "Hilfe / Homepage";
            this.MenuItemHelp.Click += new System.EventHandler(this.MenuItemHelp_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(197, 22);
            this.MenuItemExit.Text = "Beenden";
            this.MenuItemExit.Click += new System.EventHandler(this.Close_Click);
            // 
            // STForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(184, 42);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "STForm";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Screentaker.NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAreaSelector;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHistory;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUploader;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUplImageShack;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUplDirectUpload;
        private System.Windows.Forms.ToolStripMenuItem MenuItemST;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDonate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenFile;
        public System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem fTPUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemControlSelector;

    }
}

