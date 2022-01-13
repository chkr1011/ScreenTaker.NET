using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Screentaker.Forms
{
    public partial class FormColorPicker : Form
    {
        #region Constructor

        public FormColorPicker()
        {
            InitializeComponent();
        }

        #endregion

        #region Internals
        
        public List<STTabPage> _CapturedSTTabls = new List<STTabPage>();
 
        #endregion

        /// <summary>
        /// Fügt den zu überwachenden STTabPages eine weitere hinzu
        /// </summary>
        /// <param name="Source"></param>
        public void AddTab(STTabPage Source)
        {
            Source.Screen.Image_MouseMove += new PictureBoxEx.Image_MouseMoveEventHandler(Screen_Image_MouseMove);
            Source.Screen.Image_MouseClick += new PictureBoxEx.Image_MouseClickEventHandler(Screen_Image_MouseClick);

            _CapturedSTTabls.Add(Source);
        
        }

        /// <summary>
        /// Entfernt eine STTabPage aus der Collectio und entfernt die angehängten Events
        /// </summary>
        /// <param name="Target"></param>
        public void RemoveTab(STTabPage Target)
        {
            Target.Screen.Image_MouseMove -= this.Screen_Image_MouseMove;
            Target.Screen.Image_MouseClick -= this.Screen_Image_MouseClick;

            Target.Screen.SetMode(PictureBoxEx.EditModes.None);
        }

        /// <summary>
        /// Bewegen der Maus im Quellobjekt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Screen_Image_MouseMove(object sender, MouseEventArgs e)
        {
            Color _CurrentColor = ((PictureBoxEx)sender).GetCurrentColor();
            labelCurrentColor.BackColor = _CurrentColor;

            textBoxRGB.Text = Generators.FillNumber(_CurrentColor.R, 255) +
                    "," + Generators.FillNumber(_CurrentColor.G, 255) +
                    "," + Generators.FillNumber(_CurrentColor.B, 255);

            textBoxHEX.Text = string.Format("{0:X2}", _CurrentColor.R) +
                    string.Format("{0:X2}", _CurrentColor.G) +
                    string.Format("{0:X2}", _CurrentColor.B);
        }

        /// <summary>
        /// Hinzufügen einer weiteren Farbe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Screen_Image_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem _NewColor = new ListViewItem();
            _NewColor.Text = textBoxRGB.Text;
            _NewColor.SubItems.Add(textBoxHEX.Text);
            _NewColor.BackColor = labelCurrentColor.BackColor;

            listViewColors.Items.Insert(0, _NewColor);
        }

        /// <summary>
        /// Schließen dieses Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            foreach (STTabPage _CurrentSTTabPage in _CapturedSTTabls)
            {
                RemoveTab(_CurrentSTTabPage);
            }

            this.Hide();
        }

        /// <summary>
        /// Falls aus der Liste eine Farbe ausgewählt wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewColors.SelectedItems.Count == 0)
            {
                return;
            }

            labelCurrentColor.BackColor = listViewColors.SelectedItems[0].BackColor;
            textBoxRGB.Text = listViewColors.SelectedItems[0].SubItems[0].Text;
            textBoxHEX.Text = listViewColors.SelectedItems[0].SubItems[1].Text;
        }

        /// <summary>
        /// Löschen aller Farben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewColors.Items.Clear();
        }
    }
}