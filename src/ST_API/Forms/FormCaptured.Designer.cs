namespace Screentaker.Forms
{
    partial class FormCaptured
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaptured));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.ButtonPrint = new System.Windows.Forms.ToolStripDropDownButton();
            this.ButtonClipboard = new System.Windows.Forms.ToolStripButton();
            this.ButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.DownButtonUpload = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItemImageshack = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDirectUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemFTPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TextBoxFilename = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonSaveAsPNG = new System.Windows.Forms.ToolStripButton();
            this.ButtonSaveJPG = new System.Windows.Forms.ToolStripButton();
            this.ButtonSaveAsBMP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonEditExternal = new System.Windows.Forms.ToolStripButton();
            this.ButtonRestoreOriginal = new System.Windows.Forms.ToolStripButton();
            this.ButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ButtonOriginalSize = new System.Windows.Forms.ToolStripButton();
            this.ButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ButtonColorPicker = new System.Windows.Forms.ToolStripButton();
            this.ButtonReCapture = new System.Windows.Forms.ToolStripButton();
            this.ButtonQuality = new System.Windows.Forms.ToolStripButton();
            this.ButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.ButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.ButtonConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonDrawLine = new System.Windows.Forms.ToolStripButton();
            this.ButtonDrawRect = new System.Windows.Forms.ToolStripButton();
            this.LabelImageInf = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRGPColorPicked = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tabControlCaptured = new System.Windows.Forms.TabControl();
            this.tabPageST = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.webBrowserSupportPage = new System.Windows.Forms.WebBrowser();
            this.linkLabelExOpenGPL = new LinkLabelEx.LinkLabelEx();
            this.linkLabelExOpenHomepage = new LinkLabelEx.LinkLabelEx();
            this.linkLabelExMailTo = new LinkLabelEx.LinkLabelEx();
            this.buttonHomepage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDonation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxAppLogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.toolStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tabControlCaptured.SuspendLayout();
            this.tabPageST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonPrint,
            this.ButtonClipboard,
            this.ButtonSaveAs,
            this.DownButtonUpload,
            this.ButtonHistory,
            this.toolStripSeparator1,
            this.TextBoxFilename,
            this.ButtonSaveAsPNG,
            this.ButtonSaveJPG,
            this.ButtonSaveAsBMP,
            this.toolStripSeparator3,
            this.ButtonEditExternal,
            this.ButtonRestoreOriginal,
            this.ButtonZoomIn,
            this.ButtonOriginalSize,
            this.ButtonZoomOut,
            this.ButtonColorPicker,
            this.ButtonReCapture,
            this.ButtonQuality,
            this.ButtonAbout,
            this.ButtonHelp,
            this.ButtonConfig,
            this.toolStripSeparator2,
            this.ButtonDrawLine,
            this.ButtonDrawRect});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(879, 38);
            this.toolStripMain.TabIndex = 1;
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Image = global::Screentaker.Properties.Resources.PrintHS;
            this.ButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(64, 35);
            this.ButtonPrint.Text = "Drucken";
            this.ButtonPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonPrint.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ButtonPrint_DropDownItemClicked);
            // 
            // ButtonClipboard
            // 
            this.ButtonClipboard.Image = global::Screentaker.Properties.Resources.CopyHS;
            this.ButtonClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClipboard.Name = "ButtonClipboard";
            this.ButtonClipboard.Size = new System.Drawing.Size(58, 35);
            this.ButtonClipboard.Text = "Kopieren";
            this.ButtonClipboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonClipboard.ToolTipText = "In die Zwischenablage kopieren";
            this.ButtonClipboard.Click += new System.EventHandler(this.ButtonClipboard_Click);
            // 
            // ButtonSaveAs
            // 
            this.ButtonSaveAs.Image = global::Screentaker.Properties.Resources.SaveHS;
            this.ButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveAs.Name = "ButtonSaveAs";
            this.ButtonSaveAs.Size = new System.Drawing.Size(63, 35);
            this.ButtonSaveAs.Text = "Speichern";
            this.ButtonSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSaveAs.ToolTipText = "Speichern  als ..";
            this.ButtonSaveAs.Click += new System.EventHandler(this.ButtonSaveAs_Click);
            // 
            // DownButtonUpload
            // 
            this.DownButtonUpload.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemImageshack,
            this.MenuItemDirectUpload,
            this.toolStripMenuItem1,
            this.MenuItemFTPServer});
            this.DownButtonUpload.Image = global::Screentaker.Properties.Resources.UploadHS;
            this.DownButtonUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownButtonUpload.Name = "DownButtonUpload";
            this.DownButtonUpload.Size = new System.Drawing.Size(58, 35);
            this.DownButtonUpload.Text = "Upload";
            this.DownButtonUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DownButtonUpload.ToolTipText = resources.GetString("DownButtonUpload.ToolTipText");
            // 
            // MenuItemImageshack
            // 
            this.MenuItemImageshack.Name = "MenuItemImageshack";
            this.MenuItemImageshack.Size = new System.Drawing.Size(163, 22);
            this.MenuItemImageshack.Text = "ImageShack.us";
            // 
            // MenuItemDirectUpload
            // 
            this.MenuItemDirectUpload.Name = "MenuItemDirectUpload";
            this.MenuItemDirectUpload.Size = new System.Drawing.Size(163, 22);
            this.MenuItemDirectUpload.Text = "DirectUpload.net";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // MenuItemFTPServer
            // 
            this.MenuItemFTPServer.Name = "MenuItemFTPServer";
            this.MenuItemFTPServer.Size = new System.Drawing.Size(163, 22);
            this.MenuItemFTPServer.Text = "FTP-Server";
            // 
            // ButtonHistory
            // 
            this.ButtonHistory.Image = global::Screentaker.Properties.Resources.HistoryHS;
            this.ButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonHistory.Name = "ButtonHistory";
            this.ButtonHistory.Size = new System.Drawing.Size(48, 35);
            this.ButtonHistory.Text = "Verlauf";
            this.ButtonHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonHistory.ToolTipText = "Verlauf";
            this.ButtonHistory.Click += new System.EventHandler(this.ButtonHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // TextBoxFilename
            // 
            this.TextBoxFilename.Enabled = false;
            this.TextBoxFilename.Name = "TextBoxFilename";
            this.TextBoxFilename.Size = new System.Drawing.Size(250, 38);
            this.TextBoxFilename.ToolTipText = "Dateiname im Screenshotverzeichnis";
            // 
            // ButtonSaveAsPNG
            // 
            this.ButtonSaveAsPNG.Image = global::Screentaker.Properties.Resources.FilePNG_16x16;
            this.ButtonSaveAsPNG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveAsPNG.Name = "ButtonSaveAsPNG";
            this.ButtonSaveAsPNG.Size = new System.Drawing.Size(35, 35);
            this.ButtonSaveAsPNG.Text = "PNG";
            this.ButtonSaveAsPNG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSaveAsPNG.ToolTipText = "PNG - Speichern";
            // 
            // ButtonSaveJPG
            // 
            this.ButtonSaveJPG.Image = global::Screentaker.Properties.Resources.FileJPG_16x16;
            this.ButtonSaveJPG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveJPG.Name = "ButtonSaveJPG";
            this.ButtonSaveJPG.Size = new System.Drawing.Size(30, 35);
            this.ButtonSaveJPG.Text = "JPG";
            this.ButtonSaveJPG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSaveJPG.ToolTipText = "JPG - Speichern";
            // 
            // ButtonSaveAsBMP
            // 
            this.ButtonSaveAsBMP.Image = global::Screentaker.Properties.Resources.FileBMP_16x16;
            this.ButtonSaveAsBMP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveAsBMP.Name = "ButtonSaveAsBMP";
            this.ButtonSaveAsBMP.Size = new System.Drawing.Size(36, 35);
            this.ButtonSaveAsBMP.Text = "BMP";
            this.ButtonSaveAsBMP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSaveAsBMP.ToolTipText = "BMP - Speichern";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // ButtonEditExternal
            // 
            this.ButtonEditExternal.Image = global::Screentaker.Properties.Resources.picture_go;
            this.ButtonEditExternal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEditExternal.Name = "ButtonEditExternal";
            this.ButtonEditExternal.Size = new System.Drawing.Size(83, 35);
            this.ButtonEditExternal.Text = "Bearbeiten";
            this.ButtonEditExternal.ToolTipText = "Mit externem Programm bearbeiten\r\n\r\n(TOOLNAME)";
            this.ButtonEditExternal.Click += new System.EventHandler(this.ButtonEditExternal_Click);
            // 
            // ButtonRestoreOriginal
            // 
            this.ButtonRestoreOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRestoreOriginal.Image = global::Screentaker.Properties.Resources.star;
            this.ButtonRestoreOriginal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRestoreOriginal.Name = "ButtonRestoreOriginal";
            this.ButtonRestoreOriginal.Size = new System.Drawing.Size(23, 35);
            this.ButtonRestoreOriginal.Text = "Ausgangbild wiederherstellen";
            this.ButtonRestoreOriginal.ToolTipText = "Ausgangbild wiederherstellen\r\n\r\nStellt den ursprünglichen Screenshot wieder her. " +
                "Dabei gehen alle\r\nVeränderungen am aktuellen Screenshot verloren!";
            this.ButtonRestoreOriginal.Click += new System.EventHandler(this.ButtonRestoreOriginal_Click);
            // 
            // ButtonZoomIn
            // 
            this.ButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonZoomIn.Image = global::Screentaker.Properties.Resources.zoom_in;
            this.ButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonZoomIn.Name = "ButtonZoomIn";
            this.ButtonZoomIn.Size = new System.Drawing.Size(23, 35);
            this.ButtonZoomIn.Text = "Screenshot vergrößern";
            this.ButtonZoomIn.Click += new System.EventHandler(this.ButtonZoomIn_Click);
            // 
            // ButtonOriginalSize
            // 
            this.ButtonOriginalSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonOriginalSize.Image = ((System.Drawing.Image)(resources.GetObject("ButtonOriginalSize.Image")));
            this.ButtonOriginalSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOriginalSize.Name = "ButtonOriginalSize";
            this.ButtonOriginalSize.Size = new System.Drawing.Size(23, 35);
            this.ButtonOriginalSize.ToolTipText = "Zurücksetzen auf Ausgangsgröße";
            this.ButtonOriginalSize.Click += new System.EventHandler(this.ButtonOriginalSize_Click);
            // 
            // ButtonZoomOut
            // 
            this.ButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonZoomOut.Image = global::Screentaker.Properties.Resources.zoom_out;
            this.ButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonZoomOut.Name = "ButtonZoomOut";
            this.ButtonZoomOut.Size = new System.Drawing.Size(23, 35);
            this.ButtonZoomOut.Text = "Screenshot verkleinern";
            this.ButtonZoomOut.Click += new System.EventHandler(this.ButtonZoomOut_Click);
            // 
            // ButtonColorPicker
            // 
            this.ButtonColorPicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonColorPicker.Image = global::Screentaker.Properties.Resources.ColorPickerl;
            this.ButtonColorPicker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonColorPicker.Name = "ButtonColorPicker";
            this.ButtonColorPicker.Size = new System.Drawing.Size(23, 35);
            this.ButtonColorPicker.Text = "Color Picker";
            this.ButtonColorPicker.ToolTipText = "Color Picker\r\n\r\nErmöglicht es Ihnen Farbwerte aus einem Screenshot zu extrahieren" +
                ". \r\nDie gewonnenen Farbinformationen können Sie in anderen Programmen\r\nwiederver" +
                "wenden.";
            this.ButtonColorPicker.Click += new System.EventHandler(this.ButtonColorPicker_Click);
            // 
            // ButtonReCapture
            // 
            this.ButtonReCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonReCapture.Image = global::Screentaker.Properties.Resources.shape_group;
            this.ButtonReCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonReCapture.Name = "ButtonReCapture";
            this.ButtonReCapture.Size = new System.Drawing.Size(23, 20);
            this.ButtonReCapture.Text = "Re-Capture";
            this.ButtonReCapture.ToolTipText = "Re-Capture\r\n\r\nMit diesem Tool können Sie den Screenshot beschneiden.";
            this.ButtonReCapture.Click += new System.EventHandler(this.ButtonReCapture_Click);
            // 
            // ButtonQuality
            // 
            this.ButtonQuality.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonQuality.Image = global::Screentaker.Properties.Resources.bricks;
            this.ButtonQuality.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonQuality.Name = "ButtonQuality";
            this.ButtonQuality.Size = new System.Drawing.Size(23, 20);
            this.ButtonQuality.Text = "Qualitätseinstellungen";
            this.ButtonQuality.ToolTipText = "Qualitätseinstellungen\r\n\r\nMit diesem Tool haben Sie die Möglichkeit die Qualität " +
                "des Screenshots zu\r\nreduzieren um so die Dateigröße zu beeinflussen.";
            this.ButtonQuality.Click += new System.EventHandler(this.ButtonQuality_Click);
            // 
            // ButtonAbout
            // 
            this.ButtonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAbout.Image")));
            this.ButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAbout.Name = "ButtonAbout";
            this.ButtonAbout.Size = new System.Drawing.Size(32, 35);
            this.ButtonAbout.Text = "Info";
            this.ButtonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ButtonHelp.Image = global::Screentaker.Properties.Resources.HelpHS;
            this.ButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(36, 35);
            this.ButtonHelp.Text = "Hilfe";
            this.ButtonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ButtonConfig.Image = global::Screentaker.Properties.Resources.OptionsHS;
            this.ButtonConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(82, 35);
            this.ButtonConfig.Text = "Einstellungen";
            this.ButtonConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonConfig.ToolTipText = "Einstellungen";
            this.ButtonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // ButtonDrawLine
            // 
            this.ButtonDrawLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonDrawLine.Image = global::Screentaker.Properties.Resources.LineToolIcon;
            this.ButtonDrawLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDrawLine.Name = "ButtonDrawLine";
            this.ButtonDrawLine.Size = new System.Drawing.Size(23, 20);
            this.ButtonDrawLine.Text = "Linie";
            this.ButtonDrawLine.ToolTipText = "Linie\r\n\r\nMit diesem Tool können Sie mehrere Linien in den Screenshot einfügen.\r\nD" +
                "adurch ist es möglich bestimmte Bereiche zu unterstreichen und hervorzuheben.";
            this.ButtonDrawLine.Click += new System.EventHandler(this.ButtonDrawLine_Click);
            // 
            // ButtonDrawRect
            // 
            this.ButtonDrawRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonDrawRect.Image = global::Screentaker.Properties.Resources.shape_handles;
            this.ButtonDrawRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDrawRect.Name = "ButtonDrawRect";
            this.ButtonDrawRect.Size = new System.Drawing.Size(23, 20);
            this.ButtonDrawRect.Text = "Rechteck";
            this.ButtonDrawRect.ToolTipText = "Rechteck\r\n\r\nMit diesem Tool können Sie ein Rechteck in den Screenshot einfügen.\r\n" +
                "Damit können Sie bestimmte Bereiche hervorheben.";
            this.ButtonDrawRect.Click += new System.EventHandler(this.ButtonDrawRect_Click);
            // 
            // LabelImageInf
            // 
            this.LabelImageInf.BackColor = System.Drawing.SystemColors.Control;
            this.LabelImageInf.Name = "LabelImageInf";
            this.LabelImageInf.Size = new System.Drawing.Size(143, 17);
            this.LabelImageInf.Text = "<IMAGE INFORMATION>";
            // 
            // toolStripStatusLabelRGPColorPicked
            // 
            this.toolStripStatusLabelRGPColorPicked.Name = "toolStripStatusLabelRGPColorPicked";
            this.toolStripStatusLabelRGPColorPicked.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelImageInf,
            this.toolStripStatusLabelRGPColorPicked});
            this.statusStripMain.Location = new System.Drawing.Point(0, 484);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(879, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // tabControlCaptured
            // 
            this.tabControlCaptured.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlCaptured.Controls.Add(this.tabPageST);
            this.tabControlCaptured.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCaptured.Location = new System.Drawing.Point(1, 39);
            this.tabControlCaptured.Name = "tabControlCaptured";
            this.tabControlCaptured.SelectedIndex = 0;
            this.tabControlCaptured.Size = new System.Drawing.Size(879, 442);
            this.tabControlCaptured.TabIndex = 5;
            this.tabControlCaptured.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlCaptured_MouseClick);
            this.tabControlCaptured.SelectedIndexChanged += new System.EventHandler(this.tabControlCaptured_SelectedIndexChanged);
            // 
            // tabPageST
            // 
            this.tabPageST.Controls.Add(this.label6);
            this.tabPageST.Controls.Add(this.webBrowserSupportPage);
            this.tabPageST.Controls.Add(this.linkLabelExOpenGPL);
            this.tabPageST.Controls.Add(this.linkLabelExOpenHomepage);
            this.tabPageST.Controls.Add(this.linkLabelExMailTo);
            this.tabPageST.Controls.Add(this.buttonHomepage);
            this.tabPageST.Controls.Add(this.label1);
            this.tabPageST.Controls.Add(this.buttonUpdate);
            this.tabPageST.Controls.Add(this.buttonDonation);
            this.tabPageST.Controls.Add(this.label5);
            this.tabPageST.Controls.Add(this.label4);
            this.tabPageST.Controls.Add(this.pictureBoxAppLogo);
            this.tabPageST.Controls.Add(this.label3);
            this.tabPageST.Controls.Add(this.buttonClose);
            this.tabPageST.Controls.Add(this.label2);
            this.tabPageST.Controls.Add(this.labelVersion);
            this.tabPageST.Controls.Add(this.labelHeadline);
            this.tabPageST.Location = new System.Drawing.Point(4, 23);
            this.tabPageST.Name = "tabPageST";
            this.tabPageST.Size = new System.Drawing.Size(871, 415);
            this.tabPageST.TabIndex = 0;
            this.tabPageST.Text = "Screentaker.NET";
            this.tabPageST.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Aktuelle Informationen:";
            // 
            // webBrowserSupportPage
            // 
            this.webBrowserSupportPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserSupportPage.Location = new System.Drawing.Point(346, 86);
            this.webBrowserSupportPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSupportPage.Name = "webBrowserSupportPage";
            this.webBrowserSupportPage.Size = new System.Drawing.Size(515, 262);
            this.webBrowserSupportPage.TabIndex = 35;
            this.webBrowserSupportPage.Url = new System.Uri("http://czaplewski.name/screentaker/", System.UriKind.Absolute);
            // 
            // linkLabelExOpenGPL
            // 
            this.linkLabelExOpenGPL.Arguments = "";
            this.linkLabelExOpenGPL.AutoSize = true;
            this.linkLabelExOpenGPL.Command = "http://www.gnu.de/documents/gpl.de.html";
            this.linkLabelExOpenGPL.ExceptionText = "Die Informationsseite konnte nicht geöffnet werden.";
            this.linkLabelExOpenGPL.Location = new System.Drawing.Point(150, 164);
            this.linkLabelExOpenGPL.Name = "linkLabelExOpenGPL";
            this.linkLabelExOpenGPL.Size = new System.Drawing.Size(168, 14);
            this.linkLabelExOpenGPL.TabIndex = 34;
            this.linkLabelExOpenGPL.TabStop = true;
            this.linkLabelExOpenGPL.Text = "Hinweise zu dieser Lizenzform";
            // 
            // linkLabelExOpenHomepage
            // 
            this.linkLabelExOpenHomepage.Arguments = "";
            this.linkLabelExOpenHomepage.AutoSize = true;
            this.linkLabelExOpenHomepage.Command = "http://www.winfuture-forum.de/index.php?showtopic=77047";
            this.linkLabelExOpenHomepage.ExceptionText = "Die Webseite konnte nicht angezeigt werden.";
            this.linkLabelExOpenHomepage.Location = new System.Drawing.Point(11, 226);
            this.linkLabelExOpenHomepage.Name = "linkLabelExOpenHomepage";
            this.linkLabelExOpenHomepage.Size = new System.Drawing.Size(186, 14);
            this.linkLabelExOpenHomepage.TabIndex = 33;
            this.linkLabelExOpenHomepage.TabStop = true;
            this.linkLabelExOpenHomepage.Text = "http://www.winfuture-forum.de";
            // 
            // linkLabelExMailTo
            // 
            this.linkLabelExMailTo.Arguments = "";
            this.linkLabelExMailTo.AutoSize = true;
            this.linkLabelExMailTo.Command = "mailto:screentaker@web.de";
            this.linkLabelExMailTo.ExceptionText = "Es konnte keine neue E-Mail geöffnet werden.";
            this.linkLabelExMailTo.Location = new System.Drawing.Point(11, 286);
            this.linkLabelExMailTo.Name = "linkLabelExMailTo";
            this.linkLabelExMailTo.Size = new System.Drawing.Size(126, 14);
            this.linkLabelExMailTo.TabIndex = 32;
            this.linkLabelExMailTo.TabStop = true;
            this.linkLabelExMailTo.Text = "Screentaker@web.de";
            // 
            // buttonHomepage
            // 
            this.buttonHomepage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHomepage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonHomepage.Image = ((System.Drawing.Image)(resources.GetObject("buttonHomepage.Image")));
            this.buttonHomepage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonHomepage.Location = new System.Drawing.Point(384, 362);
            this.buttonHomepage.Name = "buttonHomepage";
            this.buttonHomepage.Size = new System.Drawing.Size(115, 43);
            this.buttonHomepage.TabIndex = 31;
            this.buttonHomepage.Text = "Homepage";
            this.buttonHomepage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonHomepage.UseVisualStyleBackColor = true;
            this.buttonHomepage.Click += new System.EventHandler(this.buttonHomepage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 43);
            this.label1.TabIndex = 30;
            this.label1.Text = "Sollten Sie eine weitere Funktionalität wünschen oder einen Fehler endeckt haben," +
                " so nehmen Sie bitte über E-Mail oder auf der Projekthomepage Kontakt mit uns au" +
                "f.";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonUpdate.Image = global::Screentaker.Properties.Resources.WebUpdateHS;
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonUpdate.Location = new System.Drawing.Point(505, 362);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(115, 43);
            this.buttonUpdate.TabIndex = 29;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDonation
            // 
            this.buttonDonation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDonation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDonation.ForeColor = System.Drawing.Color.Red;
            this.buttonDonation.Image = global::Screentaker.Properties.Resources.DonationHS_16x16;
            this.buttonDonation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDonation.Location = new System.Drawing.Point(626, 362);
            this.buttonDonation.Name = "buttonDonation";
            this.buttonDonation.Size = new System.Drawing.Size(115, 43);
            this.buttonDonation.TabIndex = 28;
            this.buttonDonation.Text = "Spenden!";
            this.buttonDonation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDonation.UseVisualStyleBackColor = true;
            this.buttonDonation.Click += new System.EventHandler(this.buttonDonation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Projektforum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Entwicklerkontakt:";
            // 
            // pictureBoxAppLogo
            // 
            this.pictureBoxAppLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAppLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAppLogo.Image")));
            this.pictureBoxAppLogo.Location = new System.Drawing.Point(11, 55);
            this.pictureBoxAppLogo.Name = "pictureBoxAppLogo";
            this.pictureBoxAppLogo.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxAppLogo.TabIndex = 24;
            this.pictureBoxAppLogo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Lizenz: Freeware / GPL";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(747, 362);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(115, 43);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Schließen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "(c) 2006 - 2007 Witold Czaplewski und Christian Kratky";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(65, 69);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(61, 14);
            this.labelVersion.TabIndex = 18;
            this.labelVersion.Text = "VERSION";
            // 
            // labelHeadline
            // 
            this.labelHeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeadline.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelHeadline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHeadline.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeadline.ForeColor = System.Drawing.Color.White;
            this.labelHeadline.Location = new System.Drawing.Point(11, 11);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(851, 41);
            this.labelHeadline.TabIndex = 17;
            this.labelHeadline.Text = "Informationen über Screentaker.NET";
            this.labelHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCaptured
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(879, 506);
            this.Controls.Add(this.tabControlCaptured);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "FormCaptured";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screentaker.NET";
            this.Load += new System.EventHandler(this.FormCaptured_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCaptured_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormCaptured_HelpRequested);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCaptured_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabControlCaptured.ResumeLayout(false);
            this.tabPageST.ResumeLayout(false);
            this.tabPageST.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton ButtonSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ButtonSaveJPG;
        private System.Windows.Forms.ToolStripButton ButtonSaveAsPNG;
        private System.Windows.Forms.ToolStripButton ButtonEditExternal;
        private System.Windows.Forms.ToolStripButton ButtonSaveAsBMP;
        private System.Windows.Forms.ToolStripTextBox TextBoxFilename;
        private System.Windows.Forms.ToolStripStatusLabel LabelImageInf;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRGPColorPicked;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripButton ButtonClipboard;
        private System.Windows.Forms.ToolStripButton ButtonConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ButtonHistory;
        private System.Windows.Forms.ToolStripDropDownButton DownButtonUpload;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImageshack;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDirectUpload;
        private System.Windows.Forms.ToolStripButton ButtonReCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ButtonZoomIn;
        private System.Windows.Forms.ToolStripButton ButtonZoomOut;
        private System.Windows.Forms.ToolStripButton ButtonOriginalSize;
        private System.Windows.Forms.ToolStripButton ButtonQuality;
        private System.Windows.Forms.ToolStripButton ButtonHelp;
        private System.Windows.Forms.ToolStripButton ButtonAbout;
        private System.Windows.Forms.ToolStripDropDownButton ButtonPrint;
        private System.Windows.Forms.ToolStripButton ButtonDrawLine;
        private System.Windows.Forms.ToolStripButton ButtonRestoreOriginal;
        private System.Windows.Forms.ToolStripButton ButtonColorPicker;
        private System.Windows.Forms.ToolStripButton ButtonDrawRect;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFTPServer;
        private System.Windows.Forms.TabControl tabControlCaptured;
        private System.Windows.Forms.TabPage tabPageST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDonation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxAppLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Button buttonHomepage;
        private LinkLabelEx.LinkLabelEx linkLabelExMailTo;
        private LinkLabelEx.LinkLabelEx linkLabelExOpenHomepage;
        private LinkLabelEx.LinkLabelEx linkLabelExOpenGPL;
        private System.Windows.Forms.WebBrowser webBrowserSupportPage;
        private System.Windows.Forms.Label label6;

    }
}