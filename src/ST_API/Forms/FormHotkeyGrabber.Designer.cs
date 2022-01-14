namespace Screentaker
{
    partial class FormHotkeyGrabber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHotkeyGrabber));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRequiereShift = new System.Windows.Forms.CheckBox();
            this.checkBoxRequiereAlt = new System.Windows.Forms.CheckBox();
            this.checkBoxRequiereSTRG = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxChoosenKey = new System.Windows.Forms.TextBox();
            this.linkLabelUseTab = new System.Windows.Forms.LinkLabel();
            this.linkLabelUsePrintScreen = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Taste:";
            // 
            // checkBoxRequiereShift
            // 
            this.checkBoxRequiereShift.AutoSize = true;
            this.checkBoxRequiereShift.Location = new System.Drawing.Point(12, 93);
            this.checkBoxRequiereShift.Name = "checkBoxRequiereShift";
            this.checkBoxRequiereShift.Size = new System.Drawing.Size(113, 17);
            this.checkBoxRequiereShift.TabIndex = 7;
            this.checkBoxRequiereShift.Text = "SHIFT erforderlich";
            this.checkBoxRequiereShift.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequiereAlt
            // 
            this.checkBoxRequiereAlt.AutoSize = true;
            this.checkBoxRequiereAlt.Location = new System.Drawing.Point(12, 47);
            this.checkBoxRequiereAlt.Name = "checkBoxRequiereAlt";
            this.checkBoxRequiereAlt.Size = new System.Drawing.Size(102, 17);
            this.checkBoxRequiereAlt.TabIndex = 6;
            this.checkBoxRequiereAlt.Text = "ALT erforderlich";
            this.checkBoxRequiereAlt.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequiereSTRG
            // 
            this.checkBoxRequiereSTRG.AutoSize = true;
            this.checkBoxRequiereSTRG.Location = new System.Drawing.Point(12, 70);
            this.checkBoxRequiereSTRG.Name = "checkBoxRequiereSTRG";
            this.checkBoxRequiereSTRG.Size = new System.Drawing.Size(110, 17);
            this.checkBoxRequiereSTRG.TabIndex = 5;
            this.checkBoxRequiereSTRG.Text = "STRG erforderlich";
            this.checkBoxRequiereSTRG.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 251);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(85, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(216, 251);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-2, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 35);
            this.label2.TabIndex = 12;
            this.label2.Text = " Hotkey zuweisen...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxChoosenKey
            // 
            this.textBoxChoosenKey.Location = new System.Drawing.Point(52, 124);
            this.textBoxChoosenKey.Name = "textBoxChoosenKey";
            this.textBoxChoosenKey.Size = new System.Drawing.Size(249, 21);
            this.textBoxChoosenKey.TabIndex = 13;
            this.textBoxChoosenKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxChoosenKey_KeyUp);
            // 
            // linkLabelUseTab
            // 
            this.linkLabelUseTab.AutoSize = true;
            this.linkLabelUseTab.Location = new System.Drawing.Point(49, 147);
            this.linkLabelUseTab.Name = "linkLabelUseTab";
            this.linkLabelUseTab.Size = new System.Drawing.Size(56, 13);
            this.linkLabelUseTab.TabIndex = 14;
            this.linkLabelUseTab.TabStop = true;
            this.linkLabelUseTab.Text = "Tab-Taste";
            this.linkLabelUseTab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUseTab_LinkClicked);
            // 
            // linkLabelUsePrintScreen
            // 
            this.linkLabelUsePrintScreen.AutoSize = true;
            this.linkLabelUsePrintScreen.Location = new System.Drawing.Point(112, 147);
            this.linkLabelUsePrintScreen.Name = "linkLabelUsePrintScreen";
            this.linkLabelUsePrintScreen.Size = new System.Drawing.Size(65, 13);
            this.linkLabelUsePrintScreen.TabIndex = 15;
            this.linkLabelUsePrintScreen.TabStop = true;
            this.linkLabelUsePrintScreen.Text = "Druck-Taste";
            this.linkLabelUsePrintScreen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUsePrintScreen_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(10, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 45);
            this.label3.TabIndex = 17;
            this.label3.Text = "*Um eine Taste zu definieren klicken Sie in das Textfeld und drücken Sie dann die" +
                " gewünschte Taste. Sollten Sie eine Steuertaste verwenden wollen so klicken Sie " +
                "auf einen der entsprechenden Links.";
            // 
            // FormHotkeyGrabber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(313, 286);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabelUsePrintScreen);
            this.Controls.Add(this.linkLabelUseTab);
            this.Controls.Add(this.textBoxChoosenKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxRequiereShift);
            this.Controls.Add(this.checkBoxRequiereAlt);
            this.Controls.Add(this.checkBoxRequiereSTRG);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormHotkeyGrabber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screentaker.NET";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxRequiereShift;
        private System.Windows.Forms.CheckBox checkBoxRequiereAlt;
        private System.Windows.Forms.CheckBox checkBoxRequiereSTRG;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChoosenKey;
        private System.Windows.Forms.LinkLabel linkLabelUseTab;
        private System.Windows.Forms.LinkLabel linkLabelUsePrintScreen;
        private System.Windows.Forms.Label label3;

    }
}

