namespace Screentaker.Forms
{
    partial class FormUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
            this.labelHeadline = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.labelAvailableVersion = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.linkLabelShowNotes = new LinkLabelEx.LinkLabelEx();
            this.SuspendLayout();
            // 
            // labelHeadline
            // 
            this.labelHeadline.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelHeadline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHeadline.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeadline.ForeColor = System.Drawing.Color.White;
            this.labelHeadline.Location = new System.Drawing.Point(11, 9);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(422, 41);
            this.labelHeadline.TabIndex = 2;
            this.labelHeadline.Text = "Informationen anfordern...";
            this.labelHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Installierte Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aktuelle Version:";
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentVersion.Location = new System.Drawing.Point(124, 61);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(122, 13);
            this.labelCurrentVersion.TabIndex = 5;
            this.labelCurrentVersion.Text = "CURRENTVERSION";
            // 
            // labelAvailableVersion
            // 
            this.labelAvailableVersion.AutoSize = true;
            this.labelAvailableVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailableVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelAvailableVersion.Location = new System.Drawing.Point(124, 95);
            this.labelAvailableVersion.Name = "labelAvailableVersion";
            this.labelAvailableVersion.Size = new System.Drawing.Size(128, 13);
            this.labelAvailableVersion.TabIndex = 6;
            this.labelAvailableVersion.Text = "AVAILABLEVERSION";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(350, 301);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(83, 26);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Abbrechen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.Location = new System.Drawing.Point(124, 119);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(121, 13);
            this.labelReleaseDate.TabIndex = 11;
            this.labelReleaseDate.Text = "Release: RELEASEDATE";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Image = global::Screentaker.Properties.Resources.WebUpdateHS;
            this.buttonDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDownload.Location = new System.Drawing.Point(41, 188);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(356, 35);
            this.buttonDownload.TabIndex = 12;
            this.buttonDownload.Text = "Programm beenden und aktuelle Version herunterladen";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sie können den automatischen Suchvorgang beim Programmstart im Bereich der Einste" +
                "llungen anpassen. ";
            // 
            // buttonHelp
            // 
            this.buttonHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonHelp.Image = global::Screentaker.Properties.Resources.HelpHS;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(11, 301);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(83, 26);
            this.buttonHelp.TabIndex = 14;
            this.buttonHelp.Text = "Hilfe";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // linkLabelShowNotes
            // 
            this.linkLabelShowNotes.Arguments = "";
            this.linkLabelShowNotes.AutoSize = true;
            this.linkLabelShowNotes.Command = "";
            this.linkLabelShowNotes.ExceptionText = "";
            this.linkLabelShowNotes.Location = new System.Drawing.Point(124, 138);
            this.linkLabelShowNotes.Name = "linkLabelShowNotes";
            this.linkLabelShowNotes.Size = new System.Drawing.Size(205, 13);
            this.linkLabelShowNotes.TabIndex = 15;
            this.linkLabelShowNotes.TabStop = true;
            this.linkLabelShowNotes.Text = "Informationen zu dieser Version anzeigen";
            // 
            // FormUpdate
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(445, 338);
            this.Controls.Add(this.linkLabelShowNotes);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.labelReleaseDate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelAvailableVersion);
            this.Controls.Add(this.labelCurrentVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHeadline);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUpdate";
            this.Text = "Webupdate - Screentaker.NET";
            this.Load += new System.EventHandler(this.FormUpdate_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormUpdate_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Label labelAvailableVersion;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelReleaseDate;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonHelp;
        private LinkLabelEx.LinkLabelEx linkLabelShowNotes;
    }
}