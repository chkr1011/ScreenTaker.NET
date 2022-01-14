namespace Screentaker.Forms
{
    partial class FormColorPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColorPicker));
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentColor = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHEX = new System.Windows.Forms.TextBox();
            this.textBoxRGB = new System.Windows.Forms.TextBox();
            this.listViewColors = new System.Windows.Forms.ListView();
            this.columnHeaderRGB = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderHEX = new System.Windows.Forms.ColumnHeader();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Farbe:";
            // 
            // labelCurrentColor
            // 
            this.labelCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentColor.Location = new System.Drawing.Point(80, 43);
            this.labelCurrentColor.Name = "labelCurrentColor";
            this.labelCurrentColor.Size = new System.Drawing.Size(202, 20);
            this.labelCurrentColor.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(196, 272);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(86, 26);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Schließen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "RGB:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "HEX:";
            // 
            // textBoxHEX
            // 
            this.textBoxHEX.Location = new System.Drawing.Point(80, 94);
            this.textBoxHEX.Name = "textBoxHEX";
            this.textBoxHEX.ReadOnly = true;
            this.textBoxHEX.Size = new System.Drawing.Size(202, 21);
            this.textBoxHEX.TabIndex = 8;
            // 
            // textBoxRGB
            // 
            this.textBoxRGB.Location = new System.Drawing.Point(80, 68);
            this.textBoxRGB.Name = "textBoxRGB";
            this.textBoxRGB.ReadOnly = true;
            this.textBoxRGB.Size = new System.Drawing.Size(202, 21);
            this.textBoxRGB.TabIndex = 9;
            // 
            // listViewColors
            // 
            this.listViewColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRGB,
            this.columnHeaderHEX});
            this.listViewColors.FullRowSelect = true;
            this.listViewColors.Location = new System.Drawing.Point(12, 132);
            this.listViewColors.MultiSelect = false;
            this.listViewColors.Name = "listViewColors";
            this.listViewColors.Size = new System.Drawing.Size(270, 134);
            this.listViewColors.TabIndex = 10;
            this.listViewColors.UseCompatibleStateImageBehavior = false;
            this.listViewColors.View = System.Windows.Forms.View.Details;
            this.listViewColors.SelectedIndexChanged += new System.EventHandler(this.listViewColors_SelectedIndexChanged);
            // 
            // columnHeaderRGB
            // 
            this.columnHeaderRGB.Text = "RGB";
            this.columnHeaderRGB.Width = 87;
            // 
            // columnHeaderHEX
            // 
            this.columnHeaderHEX.Text = "HEX";
            this.columnHeaderHEX.Width = 95;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 272);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(112, 26);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Farben löschen";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-3, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 33);
            this.label4.TabIndex = 13;
            this.label4.Text = " Aufgenommene Farben";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewColors);
            this.Controls.Add(this.textBoxRGB);
            this.Controls.Add(this.textBoxHEX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelCurrentColor);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormColorPicker";
            this.Text = "Color Picker - Screentaker.NET";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentColor;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHEX;
        private System.Windows.Forms.TextBox textBoxRGB;
        private System.Windows.Forms.ListView listViewColors;
        private System.Windows.Forms.ColumnHeader columnHeaderRGB;
        private System.Windows.Forms.ColumnHeader columnHeaderHEX;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label4;

    }
}