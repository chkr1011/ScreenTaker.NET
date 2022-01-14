using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Screentaker.Forms
{
    public partial class FormHistory : Form
    {
        #region Internals

        private Timer _PreviewCloser = new Timer();

        #endregion

        #region Constructor

        public FormHistory()
        {
            InitializeComponent();

            _PreviewCloser.Interval = 3000;
            _PreviewCloser.Tick += delegate { _PreviewCloser.Stop(); pictureBoxCurrentPreview.Visible = false; };

        }

        #endregion

        public Image SelectedImage  = null;
        public bool OpenNew         = false;
        public Image[] _ImagePool   = new Image[0];


        #region Private Methods

        /// <summary>
        /// Hinzufügen der Bilder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHistory_Load(object sender, EventArgs e)
        {
            Win32API.User32.AnimateWindow(this.Handle.ToInt32(), 100, 16);

            listViewHistoryImages.Items.Clear();
            imageListLargeHistory.Images.Clear();

            this.Refresh();

            //Jedes Image aus der Arraylist hinzufügen
            int _Counter    = 0;
            _ImagePool      = History.Images;
            foreach (Image _CurrentImage in History.Images)
            {
                imageListLargeHistory.Images.Add(ImageProcessing.GetThumbnail(_CurrentImage,
                    128, 128));
                
                ListViewItem _NewItem = new ListViewItem();
                _NewItem.ImageIndex = _Counter;

                listViewHistoryImages.Items.Add(_NewItem);
               
                _Counter++;
            }

            //Ersten Eintrag auswählen
            if (listViewHistoryImages.Items.Count > 0)
            {
                listViewHistoryImages.Items[0].Selected = true;
            }

            //Ausblenden des Info-Labels
            LabelPleaseWait.Visible = false;
        }

        /// <summary>
        /// Öffnen eines Images aus der History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewHistoryImages_DoubleClick(object sender, EventArgs e)
        {
            //Abbruch falls kein Eintrag ausgewählt wurde
            if (listViewHistoryImages.SelectedItems.Count == 0) { return; }

            SelectedImage = _ImagePool[listViewHistoryImages.SelectedItems[0].ImageIndex];

            if (OpenNew == true)
            {
                new ImageGrabbing().Show((Image)SelectedImage.Clone(), true, "Aus Verlauf");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        #endregion

        /// <summary>
        /// Zeigt den aktuellen Screen in der Vorschau an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewHistoryImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHistoryImages.SelectedItems.Count == 0)
            {
                return;
            }
        }

        /// <summary>
        /// Löschen der History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            History.Clear();            
            this.Close();
        }

        /// <summary>
        /// Auswählen des aktuell ausgewählten Screenys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectCurrent_Click(object sender, EventArgs e)
        {
            listViewHistoryImages_DoubleClick(null, null);
        }

        #region Hilfebehandlungen

        /// <summary>
        /// Öffnet die spezifische Hilfe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.history);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormHistory_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.history);
        }

        #endregion

        /// <summary>
        /// Anzeigen des Images als Thumbnail-Context
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewHistoryImages_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            pictureBoxCurrentPreview.Visible = true;

            pictureBoxCurrentPreview.Image = _ImagePool[e.Item.ImageIndex];
            pictureBoxCurrentPreview.Size = pictureBoxCurrentPreview.Image.Size;
            
            Point _ThumbnailPreviewLocation = this.PointToClient(MousePosition);
            pictureBoxCurrentPreview.Left = _ThumbnailPreviewLocation.X;
            pictureBoxCurrentPreview.Top = _ThumbnailPreviewLocation.Y + 5;

            _PreviewCloser.Stop();
            _PreviewCloser.Start();
        }

        private void pictureBoxCurrentPreview_MouseHover(object sender, EventArgs e)
        {
            pictureBoxCurrentPreview.Visible = false;
        }
    }
}