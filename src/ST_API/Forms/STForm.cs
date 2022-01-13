using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Screentaker.Win32API;

namespace Screentaker.Forms
{
    /// <summary>
    /// Dies ist das unsichtbare Hauptfenster des Programms
    /// </summary>
    public partial class STForm : Form
    {
        #region Constructor

        /// <summary>
        /// Initialisiert eine neue Instanz der Klasse STForm
        /// </summary>
        public STForm()
        {
            this.InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Laden des Fensters, es werden alle nötigen Hotkeys registriert
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            #region Falls gewünscht auf Updates prüfen

            if (STSystem.Settings.UserSettings.GetDataBool("AutoUpdate"))
            {
                //An dieser Stelle werden die Informationen angefordert. Sobald
                //diese dann verfügbr sind erscheint das Update-Fenster oder eben nicht
                STSettings _CurrentSTSettings = new STSettings(string.Empty);
                _CurrentSTSettings.UpdateInformationReceived += new STSettings.UpdateInformationReceivedDelegate(_CurrentSTSettings_UpdateInformationReceived);
                _CurrentSTSettings.RequestUpdateInformation();
            }

            #endregion
           
            RegisterHotkeys();
            SetTraymenuIcons(STSystem.Settings.UserSettings.GetDataBool("UseTraymenuIcons"));
            TrayIcon.Visible = true;
        }

        /// <summary>
        /// Sobald UpdateDaten verfügbar sind diese auswerten
        /// </summary>
        /// <param name="Data"></param>
        private void _CurrentSTSettings_UpdateInformationReceived(PropertyFile Data)
        {
            //Nachdem die Updateinformationen nun verfügbar sind wird das Ergebnis ausgewertet
            if (Data != null)
            {
                string _NewVersionString = Data.GetDataString("CurrentVersion");
                if (STSystem.CheckVersion(STSystem.AppVersion, _NewVersionString))
                {
                    using (FormUpdate _CurrentUpdateForm = new FormUpdate())
                    {
                        _CurrentUpdateForm.BufferData = Data;
                        _CurrentUpdateForm.ShowDialog(STSystem.STController);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message _CurrentMessage)
        {
            #region Screenshot-Handling

            HotkeyHandling.HOTKEY _Value = HotkeyHandling.ProcessEvent(_CurrentMessage);

            if (_Value.Key != Keys.None)
            {
                //Aktuelles Fenster anzeigen
                if (HotkeyHandling.Compare(_Value, STSystem.CurrentHKCurr))
                {
                    new ImageGrabbing().Grab(ImageGrabbing.GrabType.ForegroundWindow);
                }

                //Freien Bereich selektieren
                if (HotkeyHandling.Compare(_Value, STSystem.CurrentHKDef))
                {
                    new ImageGrabbing().Grab(ImageGrabbing.GrabType.Selection);
                }

                //Gesamten Bildschirm capturen
                if (HotkeyHandling.Compare(_Value, STSystem.CurrentHKFull))
                {
                    new ImageGrabbing().Grab(ImageGrabbing.GrabType.FullScreen);
                }

                if (HotkeyHandling.Compare(_Value, STSystem.CurrentHKUpload))
                {
                    string _Provider = STSystem.Settings.UserSettings.GetDataString("HotkeyUploadProvider").ToLower();

                    switch (_Provider)
                    {
                        case "imageshack.us": UploadTo(Uploader.UploadType.Imageshack); break;
                        case "directupload.net": UploadTo(Uploader.UploadType.DirectUpload); break;
                    }
                }
            }

            #endregion

            base.WndProc(ref _CurrentMessage);
        }

        #region Public Methods

        /// <summary>
        /// Setzen der Icons im Traymenu
        /// </summary>
        /// <param name="State"></param>
        public void SetTraymenuIcons(bool State)
        {
            if (State == true)
            {
                EmbeddedResources _CurrentResReader = new EmbeddedResources();

                this.MenuItemAreaSelector.Image = _CurrentResReader.LoadImage("AreaSelector.png");
                this.MenuItemControlSelector.Image = _CurrentResReader.LoadImage("ControlSelector.png");
                this.MenuItemHistory.Image = global::Screentaker.Properties.Resources.HistoryHS;
                this.MenuItemUploader.Image = global::Screentaker.Properties.Resources.UploadHS;
                this.MenuItemConfig.Image = global::Screentaker.Properties.Resources.OptionsHS;
                this.MenuItemDonate.Image = global::Screentaker.Properties.Resources.DonationHS_16x16;
                this.MenuItemHelp.Image = global::Screentaker.Properties.Resources.HelpHS;
                this.MenuItemOpenFile.Image = _CurrentResReader.LoadImage("OpenFile.png");
            }
            else
            {
                foreach (ToolStripItem _CurrentItem in contextMenu.Items)
                {
                    if (_CurrentItem.Image != null)
                    {
                        _CurrentItem.Image.Dispose();
                        _CurrentItem.Image = null;
                    }
                }
            }
        }

        /// <summary>
        /// Registriert alle Hotkeys die dem ST zugeordnet wurden
        /// </summary>
        public void RegisterHotkeys()
        {
            string _ExceptionResult = string.Empty;

            HotkeyHandling.Register(this,
                STSystem.CurrentHKFull.Key,
                STSystem.CurrentHKFull.RequiereAlt,
                STSystem.CurrentHKFull.RequiereStrg,
                STSystem.CurrentHKFull.RequiereShift,
                ref _ExceptionResult);

            HotkeyHandling.Register(this,
                STSystem.CurrentHKCurr.Key,
                STSystem.CurrentHKCurr.RequiereAlt,
                STSystem.CurrentHKCurr.RequiereStrg,
                STSystem.CurrentHKCurr.RequiereShift,
                ref _ExceptionResult);

            HotkeyHandling.Register(this,
               STSystem.CurrentHKDef.Key,
               STSystem.CurrentHKDef.RequiereAlt,
               STSystem.CurrentHKDef.RequiereStrg,
               STSystem.CurrentHKDef.RequiereShift,
               ref _ExceptionResult);

            HotkeyHandling.Register(this,
               STSystem.CurrentHKUpload.Key,
               STSystem.CurrentHKUpload.RequiereAlt,
               STSystem.CurrentHKUpload.RequiereStrg,
               STSystem.CurrentHKUpload.RequiereShift,
               ref _ExceptionResult);


            if (_ExceptionResult != string.Empty)
            {
                TrayIcon.Visible = true;
                TrayIcon.ShowBalloonTip(0, STSystem.AppTitle, _ExceptionResult, ToolTipIcon.Warning);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Klick auf Neu öffnet auswahlfenster und zeigt Ergebnis an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            new ImageGrabbing().Grab(ImageGrabbing.GrabType.Selection);
        }

        /// <summary>
        /// Klick im Tray auf Beenden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            STSystem.Shutdown();
        }

        /// <summary>
        /// Öffnet den Einstellungen-Dialog und lädt die nötigen Einstellungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form _CurrentForm in Application.OpenForms)
            { if (_CurrentForm is FormSettings) { _CurrentForm.BringToFront(); return; } }

            using (FormSettings _Configuration = new FormSettings())
            {
                _Configuration.StartPosition = FormStartPosition.Manual;
                _Configuration.Left = Screen.PrimaryScreen.WorkingArea.Width - _Configuration.Width;
                _Configuration.Top = Screen.PrimaryScreen.WorkingArea.Height - _Configuration.Height;
                _Configuration.ShowInTaskbar = true;

                _Configuration.ShowDialog();
            }
        }

        /// <summary>
        /// Verlauf anzeigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHistory_Click(object sender, EventArgs e)
        {
            FormHistory _History = new FormHistory();
            _History.OpenNew = true;
            _History.Show();
        }

        /// <summary>
        /// Wenn mit der Maus auf das Traysymbol geklickt wurde wird der Auswahlbereich
        /// geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                new ImageGrabbing().Grab(ImageGrabbing.GrabType.Selection);
            }
        }

        /// <summary>
        /// Zeigt das Info-Form über dieses Programm an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemST_Click(object sender, EventArgs e)
        {
            foreach (Form _CurrentForm in Application.OpenForms)
            {
                if (_CurrentForm is FormCaptured)
                {
                    ((FormCaptured)_CurrentForm).ShowAbout();
                    return;
                }
            }

            FormCaptured _NewCapturedWindow = new FormCaptured();
            _NewCapturedWindow.Show();
        }

        /// <summary>
        /// Upload zu DirectUpload.NET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemUplDirectUpload_Click(object sender, EventArgs e)
        {
            UploadTo(Uploader.UploadType.DirectUpload);
        }

        /// <summary>
        /// Direktes hochladen einer Datei
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemUplImageShack_Click(object sender, EventArgs e)
        {
            UploadTo(Uploader.UploadType.Imageshack);
        }

        /// <summary>
        /// Lädt ein beliebiges Image an einen FTP-Server hoch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fTPUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadTo(Screentaker.Uploader.UploadType.FtpUpload);
        }

        /// <summary>
        /// Lädt eine beliebige Datei an einem bestimmten Provider hoch
        /// </summary>
        /// <param name="Provider"></param>
        private void UploadTo(Uploader.UploadType Provider)
        {
            Image _UploadImage = ImageProcessing.OpenImage(null, string.Empty);

            if (_UploadImage != null)
            {
                using (FormUploadResult _Upload = new FormUploadResult())
                {
                    _Upload.Screenshot = _UploadImage;
                    _Upload.Provider = Provider;
                    _Upload.StartPosition = FormStartPosition.Manual;

                    _Upload.Left = Screen.PrimaryScreen.WorkingArea.Width - _Upload.Width;
                    _Upload.Top = Screen.PrimaryScreen.WorkingArea.Height - _Upload.Height;

                    _Upload.TopMost         = false;
                    _Upload.ShowInTaskbar   = true;
                    _Upload.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Ermöglicht eine Spende
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDonate_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.Donation);
        }

        /// <summary>
        /// Aufrufen der Online-Hilfe für Screentaker.NET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.Main);
        }

        #endregion

        /// <summary>
        /// Öffnen eines neuen Screenshots
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            Image _OpenedImage = ImageProcessing.OpenImage(null, STSystem.Settings.UserSettings.GetDataString("HomeDir"));

            if(_OpenedImage != null)
            {
                //Aktion durchführen
                new ImageGrabbing().Show(_OpenedImage, true, "Aus Datei");    
            }
        }

        /// <summary>
        /// Zeigt einen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemControlSelector_Click(object sender, EventArgs e)
        {
            FormControlSelector _CurrentSelector = new FormControlSelector();
            _CurrentSelector.Show();

        }
    }
}