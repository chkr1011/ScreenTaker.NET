using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Screentaker.Forms
{
    public partial class FormUpdate : Form
    {
        #region Internals

        private bool _ShowUnbounded = true;
        private PropertyFile _BufferData = null;
        private string _CurrentVersionFile  = string.Empty;
        private string _AvailableVersion = string.Empty;
       
        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public FormUpdate()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gepufferte Daten
        /// </summary>
        public PropertyFile BufferData
        {
            get { return _BufferData; }
            set { _BufferData = value; }
        }
    

        /// <summary>
        /// Definiert ob das Fenster unten Rechts am Monitor angezeigt werden soll.
        /// </summary>
        public bool ShowUnbounded
        {
            get { return _ShowUnbounded; }
            set 
            { 
                _ShowUnbounded = value;

                if (value == true)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.ShowInTaskbar = true;
                }
                else
                {
                    this.StartPosition = FormStartPosition.CenterParent;
                    this.ShowInTaskbar = false;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            #region Oberfl‰che anpassen

            labelReleaseDate.Text = string.Empty;
            labelCurrentVersion.Text = STSystem.AppVersion + " " + STSystem.AppVersionAd;
            labelAvailableVersion.Text = "(Bitte warten)";

            linkLabelShowNotes.Enabled = false;
            buttonDownload.Enabled = false;

            this.Refresh();
            Application.DoEvents();

            if (_ShowUnbounded)
            {
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            }

            STSystem.AnimateWindow(this);

            #endregion

            if (_BufferData == null)
            {
                STSettings _CurrentSettings = new STSettings(string.Empty);
                _CurrentSettings.UpdateInformationReceived += new STSettings.UpdateInformationReceivedDelegate(_CurrentSettings_UpdateInformationReceived);
                _CurrentSettings.RequestUpdateInformation();
            }
            else
            {
                SetData(_BufferData);
            }
        }

        /// <summary>
        /// Updateinformationen erhalten
        /// </summary>
        /// <param name="Data"></param>
        private void _CurrentSettings_UpdateInformationReceived(PropertyFile Data)
        {
            SetData(Data);
        }

        /// <summary>
        /// Setzt alle Informationen an Hand des heruntergeladenen ProperyFiles
        /// </summary>
        /// <param name="Data"></param>
        private void SetData(PropertyFile Data)
        {
            //Daten empfangen.. Ergebnis auswerten
            labelAvailableVersion.Text = Data.GetDataString("CurrentVersion");
            _AvailableVersion = labelAvailableVersion.Text;
            labelAvailableVersion.Text += " " + Data.GetDataString("CurrentVersionAd");
            labelReleaseDate.Text = "Release: " + Data.GetDataString("CurrentVersionReleased");
            _CurrentVersionFile = Data.GetDataString("CurrentVersionFile");

            linkLabelShowNotes.Enabled = true;
            buttonDownload.Enabled = true;
            buttonClose.Text = "Schlieﬂen";

            if (STSystem.CheckVersion(STSystem.AppVersion, _AvailableVersion))
            {
                labelHeadline.Text = "Neue Version gefunden!";
                this.AcceptButton = buttonDownload;
                buttonDownload.Focus();
            }
            else
            {
                labelHeadline.Text = "Keine neue Version vorhanden!";
                labelAvailableVersion.ForeColor = Color.Green;
            }

            //Neue Quelle dieser Datei aktualisieren
            STSystem.Settings.SystemSettings.SetDataValue("WebExchangeURL", Data.GetDataString("CurrentUpdateURL"));
            STSystem.Settings.SystemSettings.SaveContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// L‰dt die neue Programmversion herunter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_CurrentVersionFile);
                STSystem.Shutdown();
            }
            catch
            {
                Messages.ErrorBox(this, "Die neue Version konnte nicht bezogen werden.\r\nBitte versuchen Sie es sp‰ter erneut.");
            }
        }

        #endregion

        #region Hilfebehandlungen

        /// <summary>
        /// Ruft die spezifische Hilfe auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.webupdate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormUpdate_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.webupdate);
        }

        #endregion
    }
}