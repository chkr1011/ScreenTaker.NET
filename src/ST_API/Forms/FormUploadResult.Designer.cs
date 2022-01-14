namespace Screentaker.Forms
{
    partial class FormUploadResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUploadResult));
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.contextMenuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonCopyURL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            this.contextMenuResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(489, 388);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(92, 26);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Abbrechen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxThumbnail.TabIndex = 2;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Der abgebildete Screenshot wird hochgeladen. Sobald der Vorgang abgeschlossen wur" +
                "de werden die entsprechenden Informationen über den Speicherort angezeigt.";
            // 
            // labelDestination
            // 
            this.labelDestination.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestination.Location = new System.Drawing.Point(108, 71);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(464, 13);
            this.labelDestination.TabIndex = 4;
            this.labelDestination.Text = "Ziel:";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult.BackColor = System.Drawing.Color.White;
            this.richTextBoxResult.ContextMenuStrip = this.contextMenuResults;
            this.richTextBoxResult.Location = new System.Drawing.Point(2, 108);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(579, 274);
            this.richTextBoxResult.TabIndex = 6;
            this.richTextBoxResult.Text = "\nBitte warten ...";
            this.richTextBoxResult.WordWrap = false;
            this.richTextBoxResult.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxResult_LinkClicked);
            this.richTextBoxResult.TextChanged += new System.EventHandler(this.richTextBoxResult_TextChanged);
            // 
            // contextMenuResults
            // 
            this.contextMenuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCopy});
            this.contextMenuResults.Name = "contextMenuResults";
            this.contextMenuResults.Size = new System.Drawing.Size(122, 26);
            // 
            // MenuItemCopy
            // 
            this.MenuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemCopy.Image")));
            this.MenuItemCopy.Name = "MenuItemCopy";
            this.MenuItemCopy.Size = new System.Drawing.Size(121, 22);
            this.MenuItemCopy.Text = "Kopieren";
            this.MenuItemCopy.Click += new System.EventHandler(this.MenuItemCopy_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Image = global::Screentaker.Properties.Resources.HelpHS;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(2, 388);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(92, 26);
            this.buttonHelp.TabIndex = 8;
            this.buttonHelp.Text = "Hilfe";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonCopyURL
            // 
            this.buttonCopyURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyURL.Enabled = false;
            this.buttonCopyURL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCopyURL.Location = new System.Drawing.Point(100, 388);
            this.buttonCopyURL.Name = "buttonCopyURL";
            this.buttonCopyURL.Size = new System.Drawing.Size(151, 26);
            this.buttonCopyURL.TabIndex = 9;
            this.buttonCopyURL.Text = "Screenshot-URL kopieren";
            this.buttonCopyURL.UseVisualStyleBackColor = true;
            // 
            // FormUploadResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 419);
            this.Controls.Add(this.buttonCopyURL);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxThumbnail);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUploadResult";
            this.ShowInTaskbar = false;
            this.Text = "Upload - Screentaker.NET";
            this.Load += new System.EventHandler(this.FormUploadResult_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUploadResult_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormUploadResult_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            this.contextMenuResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonCopyURL;
        private System.Windows.Forms.ContextMenuStrip contextMenuResults;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCopy;
    }
}