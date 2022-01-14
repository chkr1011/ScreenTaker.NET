using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using System.Text;

using Screentaker.Uploader;

namespace Screentaker.Forms
{
    public partial class FormUploadResult : Form
    {
        #region Internals

        private Image _Source               = null;
        private Thread _UploaderThread      = null;
        private string _Filename            = string.Empty;
        private string _ScreenshotLink      = string.Empty;

        private string _CurrentFTPServer    = string.Empty;
        private string _CurrentFTPDir       = string.Empty;
        
        public UploadType Provider          = UploadType.Imageshack;

        delegate void SetReportCallback(string Value);

        #endregion

        /// <summary>
        /// Der hochzuladende Screenshot
        /// </summary>
        public Image Screenshot
        {
            set
            {
                pictureBoxThumbnail.Image = ImageProcessing.GetThumbnail(value, 100, 100);
                _Source                   = ((Image)value.Clone());
            }
        }

        public FormUploadResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Schlie�t dieses Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        { this.Close(); }

        /// <summary>
        /// L�dt das Image hoch
        /// </summary>
        private void BeginUpload()
        {
            SetReport(new Uploading().UploadEx(_Filename, Provider, ref _ScreenshotLink));
        }

        /// <summary>
        /// Setzt das Ergebnis
        /// </summary>
        /// <param name="Text"></param>
        private void SetReport(string Text)
        {
            try
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.richTextBoxResult.InvokeRequired)
                {
                    SetReportCallback _Set = new SetReportCallback(SetReport);

                    //Invoke f�hrt ein Delegate des zugrundeliegenden Threads aus.
                    //Dabei werden die Parameter als Array �bergeben. Hier quasi
                    //als object[]
                    this.Invoke(_Set, new object[] { Text });
                }
                else
                {
                    richTextBoxResult.Text = Text;
                }

                if ((_ScreenshotLink != null) &&(_ScreenshotLink != string.Empty))
                {
                    buttonCopyURL.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                richTextBoxResult.Text = "\r\nW�hrend des Uploads ist ein Fehler aufgetreten!\r\n\r\n" + 
                    "Beschreibung: " + ex.Message + "\r\n\r\nM�glicherweise gibt es Probleme durch den Provider. Versuchen Sie es sp�ter nocheinmal.";
            }

            buttonClose.Text         = "Schlie�en";
        }

        /// <summary>
        /// Wenn der Text ge�mdert wurde kann der Button zum schliessen angezeigt werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxResult_TextChanged(object sender, EventArgs e)
        {
            buttonClose.Enabled = true;
        }

        /// <summary>
        /// Wenn das Fenster geladen wird...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUploadResult_Load(object sender, EventArgs e)
        {
            //Oberfl�che anpassen und animieren
            STSystem.AnimateWindow(this);
            this.MinimumSize = this.Size;

            #region Aktionen bei Events setzen

            // Kopieren der Screenshot-URL in die Zwischenablage
            buttonCopyURL.Click += delegate
            {
                if (_ScreenshotLink != null)
                {
                    Clipboard.SetText(_ScreenshotLink);
                } 

                //Fenster schlie�en falls gew�nscht
                if (STSystem.Settings.UserSettings.GetDataBool("CloseOnURLLink") == true)
                {
                    this.Close();
                }
            };

            // Schlie�en dieses Fensters 
            buttonClose.Click += delegate
            {
                if (_UploaderThread.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    _UploaderThread.Abort();
                }

                //Verwendeten Speicher freigeben
                _Filename = null;
                _ScreenshotLink = null;
                _Source = null;
                _UploaderThread = null;

                this.Dispose();
            };

            #endregion


            switch (Provider)
            {
                case UploadType.Imageshack:
                    labelDestination.Text = "Ziel: ImageShack.us <Anonym>";
                    break;

                case UploadType.DirectUpload:
                    labelDestination.Text = "Ziel: DirectUpload.net <Anonym>";
                    break;

                case UploadType.FtpUpload:
                    _CurrentFTPServer = STSystem.Settings.UserSettings.GetDataString("FTPServer");
                    _CurrentFTPDir = STSystem.Settings.UserSettings.GetDataString("FTPDir");
                    
                    labelDestination.Text = "Ziel: FTP-Server " + _CurrentFTPServer +
                        "/" + _CurrentFTPDir;

                    break;
            }
           
            //Image erzeugen
            string _EncSetting = STSystem.Settings.UserSettings.GetDataString("UploadFormat");
            _Filename = STSystem.GetCachedFile("." + _EncSetting);

            ImageProcessing.EncoderByDesc _Encoder = (ImageProcessing.EncoderByDesc)Enum.Parse(typeof(ImageProcessing.EncoderByDesc), _EncSetting);

            ImageProcessing.CompressImage(_Source,
                100,
                _Encoder,
                _Filename);

            _UploaderThread = new Thread(new ThreadStart(BeginUpload));
            _UploaderThread.Start();
        }

        /// <summary>
        /// �ffnen einen Link aus dem RTF-Feld
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxResult_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch
            {
                MessageBox.Show(this, "Der Link konnte nicht ge�ffnet werden. M�glicherweise ist kein Programm mit diesem Link-Typ verkn�pft.",
                    this.Text, MessageBoxButtons.OK ,MessageBoxIcon.Error);

                this.DialogResult = DialogResult.None;
            }
        }

        #region Hilfebehandlungen

        /// <summary>
        /// Ruft die spezifische Hilfe auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.uploader);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormUploadResult_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.uploader);
        }

        #endregion

        /// <summary>
        /// Kopiert die Auswahl in die Zwischenablage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBoxResult.SelectedText);
        }

        /// <summary>
        /// Wenn das Fenster geschlossen wird werden alle verwendeten Ressourcen freigegeben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUploadResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Source.Dispose();
            pictureBoxThumbnail.Image.Dispose();
            pictureBoxThumbnail.Dispose();
        }
    }
}