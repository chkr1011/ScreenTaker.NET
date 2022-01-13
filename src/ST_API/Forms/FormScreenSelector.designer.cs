namespace Screentaker.Forms
{
    partial class FormScreenSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenSelector));
            this.labelSelectedSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSelectedSize
            // 
            this.labelSelectedSize.AutoSize = true;
            this.labelSelectedSize.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectedSize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedSize.Location = new System.Drawing.Point(12, 9);
            this.labelSelectedSize.Name = "labelSelectedSize";
            this.labelSelectedSize.Size = new System.Drawing.Size(28, 13);
            this.labelSelectedSize.TabIndex = 0;
            this.labelSelectedSize.Text = "0x0";
            this.labelSelectedSize.Visible = false;
            // 
            // FormScreenSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(328, 258);
            this.Controls.Add(this.labelSelectedSize);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScreenSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormScreenSelector";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormScreenSelector_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormScreenSelector_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormScreenSelector_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScreenSelector_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormScreenSelector_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormScreenSelector_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectedSize;

    }
}