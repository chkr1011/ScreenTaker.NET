namespace Screentaker
{
    partial class FormControlSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControlSelector));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelInformation2 = new System.Windows.Forms.Label();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 42);
            this.label2.TabIndex = 13;
            this.label2.Text = " Bestimmtes Element auswählen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 39);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mit diesem Werkzeug können Sie ein bestimmtes Control eines beliebigen Fensters a" +
                "uswählen. Dieses wird dann erfasst und angezeigt.";
            // 
            // labelStart
            // 
            this.labelStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelStart.Image = ((System.Drawing.Image)(resources.GetObject("labelStart.Image")));
            this.labelStart.Location = new System.Drawing.Point(24, 115);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(74, 49);
            this.labelStart.TabIndex = 16;
            this.labelStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelStart_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(293, 268);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(86, 26);
            this.buttonClose.TabIndex = 17;
            this.buttonClose.Text = "Abbrechen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHelp.Image")));
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(12, 268);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(86, 26);
            this.buttonHelp.TabIndex = 18;
            this.buttonHelp.Text = "Hilfe";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // labelInformation2
            // 
            this.labelInformation2.Location = new System.Drawing.Point(12, 197);
            this.labelInformation2.Name = "labelInformation2";
            this.labelInformation2.Size = new System.Drawing.Size(367, 52);
            this.labelInformation2.TabIndex = 19;
            this.labelInformation2.Text = resources.GetString("labelInformation2.Text");
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDetails.Location = new System.Drawing.Point(104, 115);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.ReadOnly = true;
            this.textBoxDetails.Size = new System.Drawing.Size(275, 49);
            this.textBoxDetails.TabIndex = 22;
            // 
            // FormControlSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(391, 304);
            this.Controls.Add(this.textBoxDetails);
            this.Controls.Add(this.labelInformation2);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormControlSelector";
            this.Text = "Control Selector - Screentaker.NET";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelInformation2;
        private System.Windows.Forms.TextBox textBoxDetails;
    }
}