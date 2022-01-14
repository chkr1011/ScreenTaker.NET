using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Screentaker.Forms
{
    public partial class FormQualityWizard : Form
    {
        #region Contructor

        public FormQualityWizard()
        {
            InitializeComponent();

            pictureBoxExOriginal.InnerPanel.Scroll += new ScrollEventHandler(OriginalInnerPanel_Scroll);
            pictureBoxExSized.InnerPanel.Scroll += new ScrollEventHandler(SizedInnerPanel_Scroll);
        }

        void OriginalInnerPanel_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxExSized.InnerPanel.VerticalScroll.Value = pictureBoxExOriginal.InnerPanel.VerticalScroll.Value;
            pictureBoxExSized.InnerPanel.HorizontalScroll.Value = pictureBoxExOriginal.InnerPanel.HorizontalScroll.Value;
        }

        void SizedInnerPanel_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxExOriginal.InnerPanel.VerticalScroll.Value = pictureBoxExSized.InnerPanel.VerticalScroll.Value;
            pictureBoxExOriginal.InnerPanel.HorizontalScroll.Value = pictureBoxExSized.InnerPanel.HorizontalScroll.Value;
        }

        #endregion

        /// <summary>
        /// Wenn der Benutzer eine andere Qualität wählt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarQuality_ValueChanged(object sender, EventArgs e)
        {
            double _Size = 0;
            pictureBoxExSized.UpdateImage(ImageProcessing.CompressImage(pictureBoxExOriginal.Image, trackBarQuality.Value, ImageProcessing.EncoderByDesc.JPG, ref _Size, string.Empty));

            //Größenangabe hinzufügen
            labelFileSizeSized.Text = "Dateigröße: " + Convert.ToString((uint)(_Size / 1024)) + " KB";
            labelQualityIndex.Text = "Qualität: " + trackBarQuality.Value.ToString() + "%";
        }

        /// <summary>
        /// Laden dieses Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormQualityWizard_Load(object sender, EventArgs e)
        {
            STSystem.AnimateWindow(this);
            trackBarQuality_ValueChanged(null, null);

            labelFileSizeOriginal.Text = labelFileSizeSized.Text;
        }

        /// <summary>
        /// Nach dem Klick auf OK wird das Fenster geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.OK; }

        #region Hilfebehandlungen

        /// <summary>
        /// Ruft die spezifische Hilfe auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        { STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.qualitywizard); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormQualityWizard_HelpRequested(object sender, HelpEventArgs hlpevent)
        { STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.qualitywizard); }

        #endregion
    }
}