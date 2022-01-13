using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;

namespace Screentaker.Forms
{
    public partial class FormCaptured : Form
    {
        public FormCaptured()
        {
            InitializeComponent();

            ButtonSaveAsBMP.Click += delegate { SaveImage(ImageProcessing.EncoderByDesc.BMP, ".bmp"); };
            ButtonSaveAsPNG.Click += delegate { SaveImage(ImageProcessing.EncoderByDesc.PNG, ".png"); };
            ButtonSaveJPG.Click += delegate { SaveImage(ImageProcessing.EncoderByDesc.JPG, ".jpg"); };
        
            MenuItemImageshack.Click += delegate { UploadTo(Uploader.UploadType.Imageshack); };
            MenuItemDirectUpload.Click += delegate { UploadTo(Uploader.UploadType.DirectUpload); };
            MenuItemFTPServer.Click += delegate { UploadTo(Uploader.UploadType.FtpUpload); };

            ResizeBegin += delegate { _LastWindowState = this.WindowState; };
            
        
            UpdateToolbar();
        }

        #region Internals

        private bool _CloseOnAction                 = STSystem.Settings.UserSettings.GetDataBool("CloseOnAction");
        private FormColorPicker _ColorPicker        = null;
        private FormWindowState _LastWindowState    = FormWindowState.Normal;
        
        #endregion

        #region Properties

        /// <summary>
        /// Das aktuell ausgewählte Tab welches einen Screenshot bereitstellt
        /// </summary>
        public STTabPage SelectedScreenshot
        {
            get
            {
                if (tabControlCaptured.SelectedTab is STTabPage)
                {
                    return ((STTabPage)tabControlCaptured.SelectedTab);
                }
                else
                {
                    return null;
                }
            }

            set
            {
                tabControlCaptured.SelectedTab = value;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Je nach ausgewähltem Tab werden die Toolbar-Buttons ein- bzw. ausgeblendet.
        /// Wenn es sich um das Starttab handelt werden die Buttons ausgeblendet sowie wenn
        /// alle Tabs entfernt wurden.
        /// </summary>
        private void UpdateToolbar()
        {
            bool _NewValue = false;

            if (tabControlCaptured.SelectedTab == null)
            { _NewValue = false; }

            else if (tabControlCaptured.SelectedTab.Name == tabPageST.Name)
            { 
                _NewValue = false;

                ButtonColorPicker.Checked = false;
                ButtonDrawRect.Checked = false;
                ButtonDrawLine.Checked = false;
            }

            else if (tabControlCaptured.SelectedTab is STTabPage)
            { 
                _NewValue = true;

                if (SelectedScreenshot.Screen.EditMode == PictureBoxEx.EditModes.ColorPicker)
                { ButtonColorPicker.Checked = true; }


                if (SelectedScreenshot.Screen.EditMode == PictureBoxEx.EditModes.RectangleTool)
                { ButtonDrawRect.Checked = true; }
            }

            ButtonClipboard.Enabled = _NewValue;
            ButtonPrint.Enabled = _NewValue;
            ButtonSaveAs.Enabled = _NewValue;
            ButtonColorPicker.Enabled = _NewValue;
            DownButtonUpload.Enabled = _NewValue;
            TextBoxFilename.Enabled = _NewValue;
            ButtonSaveAsBMP.Enabled = _NewValue;
            ButtonSaveJPG.Enabled = _NewValue;
            ButtonSaveAsPNG.Enabled = _NewValue;
            ButtonEditExternal.Enabled = _NewValue;
            ButtonRestoreOriginal.Enabled = _NewValue;
            ButtonZoomIn.Enabled = _NewValue;
            ButtonZoomOut.Enabled = _NewValue;
            ButtonOriginalSize.Enabled = _NewValue;
            ButtonQuality.Enabled = _NewValue;
            ButtonDrawLine.Enabled = _NewValue;
            ButtonDrawRect.Enabled = _NewValue;
            ButtonReCapture.Enabled = _NewValue;

            
        }

        #endregion

        /// <summary>
        /// Fügt dem TabControl ein neuen Element hinzu und zeigt dies an
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Title"></param>
        public void AddScreenshot(Image Source, string Title)
        {
            STTabPage _NewTab = new STTabPage();
            _NewTab.ScreenImage = Source;
            _NewTab.Title = Title;

            tabControlCaptured.TabPages.Add(_NewTab);
            tabControlCaptured.SelectedTab = _NewTab;


            UpdateToolbar();

            //Falls konfiguriert wird dieses Fenster immer maximized angezeigt
            if (STSystem.Settings.UserSettings.GetDataBool("AlwaysOpenMaximized") == true)
            { this.WindowState = FormWindowState.Maximized; }
            else
            { this.WindowState = _LastWindowState; }
        }

        /// <summary>
        /// Zeigt das Screentaker.NET-Tab an
        /// </summary>
        public void ShowAbout()
        {
            foreach (TabPage _CurrentTab in tabControlCaptured.TabPages)
            {
                if (_CurrentTab.Name == "tabPageST")
                {
                    tabControlCaptured.SelectedTab = _CurrentTab;
                    return;
                }
            }

            //Falls das Tab nicht angezeigt wird es erneut in die Liste eintragen
            tabControlCaptured.TabPages.Insert(0, tabPageST);
            tabControlCaptured.SelectedTab = tabPageST;
        }

        /// <summary>
        /// Zeigt das Fenster an und fügt den Screenshot in das Fenster ein. Weiterhin wird das 
        /// Fenster automatisch an die Größe des Screenshots angepasst
        /// </summary>
        /// <param name="Screenshot"></param>
        [Obsolete("AddScreenshot() benutzen!")]
        public void Show(Image Screenshot)
        {
            if (Screenshot != null)
            {
                //ResizeToScreenshot();
            }

            #region Alle vorhandenen Drucker ermitteln

            try
            {
                foreach (string _CurrentPrintername in PrinterSettings.InstalledPrinters)
                {

                    ButtonPrint.DropDownItems.Add(_CurrentPrintername);
                }
            }
            catch { /*Nichts tun, kein Drucker vorhanden!*/ }

            #endregion

            #region Größe des Fensters anpassen

            //Größe des Fensters anpassen falls das angezeigt 
            //Bild größer als der Arbeitsbereich ist
            if ((this.Width > Screen.PrimaryScreen.WorkingArea.Width) || (this.Height > Screen.PrimaryScreen.WorkingArea.Height))
            {
                this.WindowState = FormWindowState.Maximized;
            }

            //Falls konfiguriert wird dieses Fenster immer maximized angezeigt
            if (STSystem.Settings.UserSettings.GetDataBool("AlwaysOpenMaximized") == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            #endregion

            #region Falls konfiguriert Dateinamen setzen


            if (STSystem.Settings.UserSettings.GetDataBool("AutoNumerate"))
            {
                //Zahl hinter den Standard-Dateinamen hinzufügen
                TextBoxFilename.Text = STSystem.GetUnusedFilename(STSystem.Settings.UserSettings.GetDataString("HomeDir") +
                                        @"\", STSystem.Settings.UserSettings.GetDataString("DefaultFilename"),
                                        string.Empty);
                                        
            }
            else
            {
                //Nur Dateinamen setzen
                TextBoxFilename.Text = STSystem.Settings.UserSettings.GetDataString("DefaultFilename");
            }

            #endregion

            UpdateStatusbar();

            //Externen Toolnamen einsetzen
            ButtonEditExternal.ToolTipText = "Mit externem Programm bearbeiten\r\n\r\n(" + 
                STSystem.Settings.UserSettings.GetDataString("ExternalToolName") + ")";

            //pBoxShot.InnerControl.MouseMove += new MouseEventHandler(ImageBox_MouseMove);

            this.Show();
            TextBoxFilename.Focus();
        }

        /// <summary>
        /// Passt das Fenster dem Screenshot an
        /// </summary>
        private void ResizeToScreenshot()
        {
            //this.Height = pBoxShot.Image.Height + toolStripMain.Height + statusStripMain.Height + 60;
            //this.Width = pBoxShot.Image.Width + 30;
        }

        /// <summary>
        /// Wenn die Maus über das Image-Control der pBox-Shot bewegt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateStatusbar();
        }

        #region Screenshot speichern

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Format"></param>
        /// <param name="Extension"></param>
        private void SaveImage(ImageProcessing.EncoderByDesc EncDesc, string Extension)
        {
            if (TextBoxFilename.Text == string.Empty)
            {
                Messages.WarningBox(this, "Bitte geben Sie einen Dateinamen ein.\r\nDer Vorgang wird abgebrochen.");
                return;
            }

            //Verzeichnis ermitteln und falls nötig anlegen
            string _Target = STSystem.Settings.UserSettings.GetDataString("HomeDir");
            if (!Directory.Exists(_Target)) { Directory.CreateDirectory(_Target); }

            _Target += @"\" + TextBoxFilename.Text + Extension;

            //Falls die Datei bereits existiert nachfragen
            if (File.Exists(_Target) == true)
            {
                if (MessageBox.Show(this, "Die Datei \"" + _Target + "\" existiert bereits. Möchten Sie die vorhandene Datei überschreiben?",
                    STSystem.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            ImageProcessing.CompressImage(SelectedScreenshot.ScreenImage, EncDesc, _Target);

            //Schließen falls konfiguriert
            if (_CloseOnAction == true)
            { this.Close(); }
        }

        #endregion

        /// <summary>
        /// Öffnet den Screenshot zum Bearbeiten in einem Externen Tool, welches vorher
        /// definiert wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditExternal_Click(object sender, EventArgs e)
        {
            //Das Fenster wird ausgeblendet, das externe Tool gestartet und nach dem
            //Bearbeiten wird das Fenster wieder geöffnet und das neue Image angezeigt
            this.Hide();
            string AppFile = STSystem.Settings.UserSettings.GetDataString("ExternalToolFile");
            string AppName = STSystem.Settings.UserSettings.GetDataString("ExternalToolName");

            SelectedScreenshot.ScreenImage = ImageProcessing.EditExternal(SelectedScreenshot.ScreenImage, AppFile, AppName, true);
            
            AppFile = null;
            AppName = null;

            //Bearbeitetes Bild der History hinzufügen
            if (STSystem.Settings.UserSettings.GetDataBool("HistoryTakeEdited"))
            {
                History.Add(SelectedScreenshot.ScreenImage);
            }

            if (STSystem.Settings.UserSettings.GetDataBool("NoLoadAfterEdit"))
            { this.Close(); }
            else { this.Show(); }
        }

        /// <summary>
        /// Aktualisiert die Statusbar
        /// </summary>
        private void UpdateStatusbar()
        {
            //if (SelectedScreenshot.Image == null)
            //{
            //    LabelImageInf.Text = "Keine Informationen verfügbar!";
            //    return;
            //}

            try
            {
                //Informationen in der Statusleiste anzeigen
                LabelImageInf.Text = string.Empty;

                LabelImageInf.Text += "Höhe: " + SelectedScreenshot.ScreenImage.Height.ToString() + "px ";
                LabelImageInf.Text += "Breite: " + SelectedScreenshot.ScreenImage.Width.ToString() + "px ";

                int _CurrentX = SelectedScreenshot.Screen.CursorPosition.X;
                int _CurrentY = SelectedScreenshot.Screen.CursorPosition.Y;
                
                LabelImageInf.Text += "X: " + Generators.FillNumber(_CurrentX,
                    SelectedScreenshot.ScreenImage.Width) + " ";
                LabelImageInf.Text += "Y: " + Generators.FillNumber(_CurrentY,
                    SelectedScreenshot.ScreenImage.Height) + " ";
     

                //if (SelectedScreenshot.IsZoomed)
                //{
                //    LabelImageInf.Text      = "Informationen stehen im Zoom-Modus nicht zur Verfügung!";
                //}
                //else
                //{


                //    LabelImageInf.Text += "| ";

                //    int _CurrentX = pBoxShot.CursorPosition.X;
                //    int _CurrentY = pBoxShot.CursorPosition.Y;

                //    LabelImageInf.Text += "X: " + Generators.FillNumber(_CurrentX, pBoxShot.Image.Width) + " ";
                //    LabelImageInf.Text += "Y: " + Generators.FillNumber(_CurrentY, pBoxShot.Image.Height) + " ";
                //}
            }
            catch
            {
                LabelImageInf.Text = string.Empty;
            }
        }

        /// <summary>
        /// Speichert den Screenshot unter Verwendung des Speichern-Unter-Dialogs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog _SaveDialog = new SaveFileDialog())
            {
                _SaveDialog.AddExtension = true;
                _SaveDialog.RestoreDirectory = true;
                _SaveDialog.Filter = "PNG(*.png)|*.png|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
                _SaveDialog.FileName = SelectedScreenshot.Title;

                if (_SaveDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ImageProcessing.CompressImage(SelectedScreenshot.ScreenImage,
                        ImageProcessing.GetEncDescription(new FileInfo(_SaveDialog.FileName).Extension),
                        _SaveDialog.FileName);

                    //Fenster schließen falls gewünscht
                    if (_CloseOnAction == true)
                    { this.Close(); }
                }
            }
        }

        /// <summary>
        /// Kopiert den aktuellen Screenshot in die Zwischenablage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(SelectedScreenshot.ScreenImage);

            if (_CloseOnAction == true)
            { this.Close(); }
        }

        /// <summary>
        /// Öffnet das Einstellungen-Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            foreach (Form _CurrentForm in Application.OpenForms)
            { if (_CurrentForm is FormSettings) { _CurrentForm.BringToFront(); return; } }

            using (FormSettings _Configuration = new FormSettings())
            {
                _Configuration.StartPosition    = FormStartPosition.CenterParent;
                _Configuration.ShowInTaskbar    = false;
                _Configuration.ShowDialog(this);
            }
        }

        /// <summary>
        /// Zeigt das History-Fenster an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHistory_Click(object sender, EventArgs e)
        {
            foreach (Form _CurrentForm in Application.OpenForms)
            { if (_CurrentForm is FormHistory) { _CurrentForm.BringToFront(); return; } }

            using (FormHistory _History = new FormHistory())
            {
                if (_History.ShowDialog() == DialogResult.OK)
                {
                    AddScreenshot(_History.SelectedImage, "Aus Verlauf");;
                }
            }
        }

        /// <summary>
        /// Laden des Fensters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptured_Load(object sender, EventArgs e)
        {
            STSystem.AnimateWindow(this);

            labelVersion.Text = "Version: " + STSystem.AppVersion + " " + STSystem.AppVersionAd;

            #region Alle vorhandenen Drucker ermitteln

            try
            {
                foreach (string _CurrentPrintername in PrinterSettings.InstalledPrinters)
                {

                    ButtonPrint.DropDownItems.Add(_CurrentPrintername);
                }
            }
            catch { /*Nichts tun, kein Drucker vorhanden!*/ }

            #endregion

            #region Größe des Fensters anpassen

            //Größe des Fensters anpassen falls das angezeigt 
            //Bild größer als der Arbeitsbereich ist
            if ((this.Width > Screen.PrimaryScreen.WorkingArea.Width) || (this.Height > Screen.PrimaryScreen.WorkingArea.Height))
            {
                this.WindowState = FormWindowState.Maximized;
            }

            //Falls konfiguriert wird dieses Fenster immer maximized angezeigt
            if (STSystem.Settings.UserSettings.GetDataBool("AlwaysOpenMaximized") == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            #endregion

            #region Falls konfiguriert Dateinamen setzen

            if (STSystem.Settings.UserSettings.GetDataBool("AutoNumerate"))
            {
                //Zahl hinter den Standard-Dateinamen hinzufügen
                TextBoxFilename.Text = STSystem.GetUnusedFilename(STSystem.Settings.UserSettings.GetDataString("HomeDir") +
                                        @"\", STSystem.Settings.UserSettings.GetDataString("DefaultFilename"),
                                        string.Empty);

            }
            else
            {
                //Nur Dateinamen setzen
                TextBoxFilename.Text = STSystem.Settings.UserSettings.GetDataString("DefaultFilename");
            }

            #endregion

            UpdateStatusbar();

            //Externen Toolnamen einsetzen
            ButtonEditExternal.ToolTipText = "Mit externem Programm bearbeiten\r\n\r\n(" +
                STSystem.Settings.UserSettings.GetDataString("ExternalToolName") + ")";

            //pBoxShot.InnerControl.MouseMove += new MouseEventHandler(ImageBox_MouseMove);

            this.Show();
            TextBoxFilename.Focus();
        }

        /// <summary>
        /// Lädt einen Screenshot an einen bestimmten Provider hoch
        /// </summary>
        /// <param name="Provider"></param>
        private void UploadTo(Uploader.UploadType Provider)
        {
            using (FormUploadResult _UploadView = new FormUploadResult())
            {
                _UploadView.Screenshot  = SelectedScreenshot.ScreenImage;
                _UploadView.Provider    = Provider;

                _UploadView.ShowDialog(this);
            }
        }

        /// <summary>
        /// Setzt die Stati aller Buttons für das erweiterte bearbeiten zurück
        /// </summary>
        private void ResetEditModes()
        {
            ButtonDrawLine.Checked = false;
            ButtonDrawRect.Checked = false;
 
            SelectedScreenshot.Screen.SetMode(PictureBoxEx.EditModes.None);
        }

        #region Hotkeys für Funktionen dieses Fensters

        /// <summary>
        /// Hotkeys die nur für dieses Fenster gelten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptured_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyData;

            if (k == (Keys.Control | Keys.S))
            {
               ButtonSaveAs_Click(null, null);
            }
            else if (k == (Keys.Control | Keys.E))
            {
                ButtonEditExternal_Click(null, null);
            }
            else if (k == (Keys.Control | Keys.C))
            {
                ButtonClipboard_Click(null, null);
            }
        }

        #endregion

        /// <summary>
        /// Öffnet den Auswahlbereich um einen Screenshot erneut beschneiden zu können
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReCapture_Click(object sender, EventArgs e)
        {
            STTabPage _CurrentSTabBuffer = SelectedScreenshot;

            SelectedScreenshot.BackColor = Color.White;
            using(ImageGrabbing _CurrentGrabber = new ImageGrabbing())
            {
                _CurrentGrabber.Grab(ImageGrabbing.GrabType.Selection);
            }
            _CurrentSTabBuffer.BackColor = SystemColors.ControlDark;
            
        }

        /// <summary>
        /// Zoomt den Screenshot um 1 Faktor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            //pBoxShot.ZoomIn();
        }

        /// <summary>
        /// Zoomt den Screenshot um 1 Faktor kleiner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonZoomOut_Click(object sender, EventArgs e)
        {
            //pBoxShot.ZoomOut();
        }

        /// <summary>
        /// Setzt den Screenshot wieder auf die Standardgröße zurück und 
        /// zentriert ihn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOriginalSize_Click(object sender, EventArgs e)
        { SelectedScreenshot.Screen.FitToImage(); }

        /// <summary>
        /// Öffnet die URL die die Hilfe bereitstellt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDoku_Click(object sender, EventArgs e)
        { STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.editing); }

        /// <summary>
        /// Fenster öffnen um die Qualitätseinstellungen anzupassen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuality_Click(object sender, EventArgs e)
        {
            using (FormQualityWizard _QWizard = new FormQualityWizard())
            {
                ButtonQuality.Checked = true;

                _QWizard.pictureBoxExOriginal.Image = SelectedScreenshot.ScreenImage;

                if (_QWizard.ShowDialog(this) == DialogResult.OK)
                {
                    SelectedScreenshot.ScreenImage = _QWizard.pictureBoxExSized.Image;
                   
                    //Falls gewünscht in die History übernehmen
                    if (STSystem.Settings.UserSettings.GetDataBool("HistoryTakeSized"))
                    {
                        History.Add(_QWizard.pictureBoxExSized.Image);
                    }
                }

                ButtonQuality.Checked = false;
            }
        }

        #region Hilfebehandlungen

        /// <summary>
        /// Ruft die Hilfe zu diesem Fenster auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.editing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormCaptured_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.editing);
        }

        #endregion

        /// <summary>
        /// Falls ein Drucker angeklickt wurde wird nun der Printdialog 
        /// mit diesem Drucker angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrint_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { new Printing().PrintPreview(SelectedScreenshot.ScreenImage, e.ClickedItem.Text); }

        /// <summary>
        /// Beim schließen dieses Fensters Resourcen freigeben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptured_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.toolStripMain.Dispose();
            tabControlCaptured.Dispose();

            this.Dispose();
        }

        #region Bearbeitungsmodi

        /// <summary>
        /// Modus zum zeichnen einer roten Linie aktivieren/deaktivieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDrawLine_Click(object sender, EventArgs e)
        {
            //if (pBoxShot.EditMode != PictureBoxEx.EditModes.Line)
            //{
            //    ResetEditModes();
            //    pBoxShot.SetMode(PictureBoxEx.EditModes.Line);
            //    ButtonDrawLine.Checked = true;
            //}
            //else
            //{
            //    if (pBoxShot.ImageWasChanged) { History.Add(pBoxShot.Image); }
            //    ResetEditModes();
            //}
        }

        /// <summary>
        /// Stellt das Originalimage wieder her
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRestoreOriginal_Click(object sender, EventArgs e)
        {
            SelectedScreenshot.Screen.RestoreOriginalImage();
        }

        /// <summary>
        /// Starten des Colorpicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonColorPicker_Click(object sender, EventArgs e)
        {
            if (SelectedScreenshot.Screen.EditMode == PictureBoxEx.EditModes.ColorPicker)
            {
                SelectedScreenshot.Screen.SetMode(PictureBoxEx.EditModes.None);
                
                //Event entfernen
                if(_ColorPicker != null)
                {
                    _ColorPicker.RemoveTab(SelectedScreenshot);
                }

                ButtonColorPicker.Checked = false;
                return;
            }
            else
            {
                SelectedScreenshot.Screen.SetMode(PictureBoxEx.EditModes.ColorPicker);
                
                if(_ColorPicker == null)
                { _ColorPicker = new FormColorPicker(); }

                _ColorPicker.AddTab(SelectedScreenshot);
                _ColorPicker.Show();

                ButtonColorPicker.Checked = true;
            }
        }

        /// <summary>
        /// Setzen des Rectangle Tools
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDrawRect_Click(object sender, EventArgs e)
        {
            if (SelectedScreenshot.Screen.EditMode != PictureBoxEx.EditModes.RectangleTool)
            {
                ResetEditModes();
                SelectedScreenshot.Screen.SetMode(PictureBoxEx.EditModes.RectangleTool);
                ButtonDrawRect.Checked = true;
            }
            else
            {
                if (SelectedScreenshot.Screen.ImageWasChanged) 
                { 
                    History.Add(SelectedScreenshot.ScreenImage);
                }
               
                ResetEditModes();
            }
        }

        #endregion

        #region StartTab-Methoden

        /// <summary>
        /// Zeigt die Spendenseite an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDonation_Click(object sender, EventArgs e)
        { STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.Donation); }

        /// <summary>
        /// Prüft auf eine neue Version
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            using (FormUpdate _Updater = new FormUpdate())
            {
                _Updater.ShowUnbounded = false;
                _Updater.ShowDialog(this);
            }
        }

        /// <summary>
        /// Schließt die Startseite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        { tabControlCaptured.TabPages.Remove(tabPageST); }
        
        /// <summary>
        /// Rüft das Informationsfenster zu diesem Programm auf 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAbout_Click(object sender, EventArgs e)
        { ShowAbout(); }

        /// <summary>
        /// Zeigt die Homepage an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHomepage_Click(object sender, EventArgs e)
        { STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.Main); }

        #endregion

        /// <summary>
        /// Wenn ein anderes Tab ausgewählt wurde werden die entsprechenden Buttons
        /// ausgewählt und Events neu angelegt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlCaptured_SelectedIndexChanged(object sender, EventArgs e)
        { 
            UpdateToolbar();
            UpdateStatusbar();
        }

        /// <summary>
        /// Wenn mit der Maus auf einen Tab geklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlCaptured_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                tabControlCaptured.TabPages.Remove(tabControlCaptured.SelectedTab);
            }
        }
    }
}