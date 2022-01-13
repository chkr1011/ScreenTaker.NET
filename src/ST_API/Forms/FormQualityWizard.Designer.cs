namespace Screentaker.Forms
{
    partial class FormQualityWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQualityWizard));
            this.trackBarQuality = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFileSizeSized = new System.Windows.Forms.Label();
            this.labelFileSizeOriginal = new System.Windows.Forms.Label();
            this.labelQualityIndex = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.pictureBoxExSized = new Screentaker.PictureBoxEx();
            this.pictureBoxExOriginal = new Screentaker.PictureBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarQuality
            // 
            this.trackBarQuality.Location = new System.Drawing.Point(7, 328);
            this.trackBarQuality.Maximum = 100;
            this.trackBarQuality.Name = "trackBarQuality";
            this.trackBarQuality.Size = new System.Drawing.Size(619, 45);
            this.trackBarQuality.TabIndex = 2;
            this.trackBarQuality.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarQuality.Value = 100;
            this.trackBarQuality.ValueChanged += new System.EventHandler(this.trackBarQuality_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Originalqualität";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(341, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Neue Qualität - JPG Kompression";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(437, 403);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(91, 26);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(535, 403);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 26);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelFileSizeSized
            // 
            this.labelFileSizeSized.AutoSize = true;
            this.labelFileSizeSized.Location = new System.Drawing.Point(338, 303);
            this.labelFileSizeSized.Name = "labelFileSizeSized";
            this.labelFileSizeSized.Size = new System.Drawing.Size(85, 13);
            this.labelFileSizeSized.TabIndex = 18;
            this.labelFileSizeSized.Text = "Dateigröße: N/A";
            // 
            // labelFileSizeOriginal
            // 
            this.labelFileSizeOriginal.AutoSize = true;
            this.labelFileSizeOriginal.Location = new System.Drawing.Point(4, 303);
            this.labelFileSizeOriginal.Name = "labelFileSizeOriginal";
            this.labelFileSizeOriginal.Size = new System.Drawing.Size(85, 13);
            this.labelFileSizeOriginal.TabIndex = 17;
            this.labelFileSizeOriginal.Text = "Dateigröße: N/A";
            // 
            // labelQualityIndex
            // 
            this.labelQualityIndex.AutoSize = true;
            this.labelQualityIndex.Location = new System.Drawing.Point(4, 376);
            this.labelQualityIndex.Name = "labelQualityIndex";
            this.labelQualityIndex.Size = new System.Drawing.Size(70, 13);
            this.labelQualityIndex.TabIndex = 19;
            this.labelQualityIndex.Text = "Qualität: N/A";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Image = global::Screentaker.Properties.Resources.HelpHS;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(7, 403);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(97, 26);
            this.buttonHelp.TabIndex = 20;
            this.buttonHelp.Text = "Hilfe";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // pictureBoxExSized
            // 
            this.pictureBoxExSized.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxExSized.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxExSized.Image = null;
            this.pictureBoxExSized.Location = new System.Drawing.Point(341, 45);
            this.pictureBoxExSized.Name = "pictureBoxExSized";
            this.pictureBoxExSized.Size = new System.Drawing.Size(285, 238);
            this.pictureBoxExSized.TabIndex = 1;
            // 
            // pictureBoxExOriginal
            // 
            this.pictureBoxExOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxExOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxExOriginal.Image = null;
            this.pictureBoxExOriginal.Location = new System.Drawing.Point(7, 45);
            this.pictureBoxExOriginal.Name = "pictureBoxExOriginal";
            this.pictureBoxExOriginal.Size = new System.Drawing.Size(284, 238);
            this.pictureBoxExOriginal.TabIndex = 0;
            // 
            // FormQualityWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 442);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.labelQualityIndex);
            this.Controls.Add(this.labelFileSizeSized);
            this.Controls.Add(this.labelFileSizeOriginal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarQuality);
            this.Controls.Add(this.pictureBoxExSized);
            this.Controls.Add(this.pictureBoxExOriginal);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormQualityWizard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qualitätseinstellungen - Screentaker.NET";
            this.Load += new System.EventHandler(this.FormQualityWizard_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormQualityWizard_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarQuality;
        public PictureBoxEx pictureBoxExOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        public PictureBoxEx pictureBoxExSized;
        private System.Windows.Forms.Label labelFileSizeSized;
        private System.Windows.Forms.Label labelFileSizeOriginal;
        private System.Windows.Forms.Label labelQualityIndex;
        private System.Windows.Forms.Button buttonHelp;
    }
}