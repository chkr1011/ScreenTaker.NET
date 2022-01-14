namespace Screentaker.Forms
{
    partial class FormHistory
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

            SelectedImage = null;
            _ImagePool = null;
            imageListLargeHistory.Dispose();
            imageListLargeHistory = null;
            listViewHistoryImages.Dispose();
            listViewHistoryImages = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.listViewHistoryImages = new System.Windows.Forms.ListView();
            this.imageListLargeHistory = new System.Windows.Forms.ImageList(this.components);
            this.toolStripHistory = new System.Windows.Forms.ToolStrip();
            this.ButtonSelectCurrent = new System.Windows.Forms.ToolStripButton();
            this.ButtonClear = new System.Windows.Forms.ToolStripButton();
            this.ButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.LabelPleaseWait = new System.Windows.Forms.ToolStripLabel();
            this.pictureBoxCurrentPreview = new System.Windows.Forms.PictureBox();
            this.toolStripHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewHistoryImages
            // 
            this.listViewHistoryImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewHistoryImages.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listViewHistoryImages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewHistoryImages.LargeImageList = this.imageListLargeHistory;
            this.listViewHistoryImages.Location = new System.Drawing.Point(0, 41);
            this.listViewHistoryImages.MultiSelect = false;
            this.listViewHistoryImages.Name = "listViewHistoryImages";
            this.listViewHistoryImages.Size = new System.Drawing.Size(660, 356);
            this.listViewHistoryImages.TabIndex = 0;
            this.listViewHistoryImages.UseCompatibleStateImageBehavior = false;
            this.listViewHistoryImages.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listViewHistoryImages_ItemMouseHover);
            this.listViewHistoryImages.SelectedIndexChanged += new System.EventHandler(this.listViewHistoryImages_SelectedIndexChanged);
            this.listViewHistoryImages.DoubleClick += new System.EventHandler(this.listViewHistoryImages_DoubleClick);
            // 
            // imageListLargeHistory
            // 
            this.imageListLargeHistory.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLargeHistory.ImageSize = new System.Drawing.Size(128, 128);
            this.imageListLargeHistory.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripHistory
            // 
            this.toolStripHistory.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripHistory.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonSelectCurrent,
            this.ButtonClear,
            this.ButtonHelp,
            this.LabelPleaseWait});
            this.toolStripHistory.Location = new System.Drawing.Point(0, 0);
            this.toolStripHistory.Name = "toolStripHistory";
            this.toolStripHistory.Size = new System.Drawing.Size(660, 38);
            this.toolStripHistory.TabIndex = 5;
            // 
            // ButtonSelectCurrent
            // 
            this.ButtonSelectCurrent.Image = global::Screentaker.Properties.Resources.NextHS;
            this.ButtonSelectCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSelectCurrent.Name = "ButtonSelectCurrent";
            this.ButtonSelectCurrent.Size = new System.Drawing.Size(109, 35);
            this.ButtonSelectCurrent.Text = "Screenshot Öffnen";
            this.ButtonSelectCurrent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSelectCurrent.Click += new System.EventHandler(this.ButtonSelectCurrent_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Image = global::Screentaker.Properties.Resources.cross;
            this.ButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(83, 35);
            this.ButtonClear.Text = "Verlauf leeren";
            this.ButtonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
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
            this.ButtonHelp.ToolTipText = "Hilfe";
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // LabelPleaseWait
            // 
            this.LabelPleaseWait.ForeColor = System.Drawing.Color.Maroon;
            this.LabelPleaseWait.Name = "LabelPleaseWait";
            this.LabelPleaseWait.Size = new System.Drawing.Size(202, 35);
            this.LabelPleaseWait.Text = "Ansicht wird geladen... Bitte warten...";
            // 
            // pictureBoxCurrentPreview
            // 
            this.pictureBoxCurrentPreview.Location = new System.Drawing.Point(12, 57);
            this.pictureBoxCurrentPreview.Name = "pictureBoxCurrentPreview";
            this.pictureBoxCurrentPreview.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxCurrentPreview.TabIndex = 6;
            this.pictureBoxCurrentPreview.TabStop = false;
            this.pictureBoxCurrentPreview.Visible = false;
            this.pictureBoxCurrentPreview.MouseHover += new System.EventHandler(this.pictureBoxCurrentPreview_MouseHover);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 397);
            this.Controls.Add(this.pictureBoxCurrentPreview);
            this.Controls.Add(this.toolStripHistory);
            this.Controls.Add(this.listViewHistoryImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verlauf - Screentaker.NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHistory_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormHistory_HelpRequested);
            this.toolStripHistory.ResumeLayout(false);
            this.toolStripHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewHistoryImages;
        private System.Windows.Forms.ImageList imageListLargeHistory;
        private System.Windows.Forms.ToolStrip toolStripHistory;
        private System.Windows.Forms.ToolStripButton ButtonSelectCurrent;
        private System.Windows.Forms.ToolStripButton ButtonClear;
        private System.Windows.Forms.ToolStripLabel LabelPleaseWait;
        private System.Windows.Forms.ToolStripButton ButtonHelp;
        private System.Windows.Forms.PictureBox pictureBoxCurrentPreview;
    }
}