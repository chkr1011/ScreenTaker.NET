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
    public partial class FormSettings : Form
    {
        #region Constructor

        public FormSettings()
        {
            InitializeComponent();
        }

        #endregion

        private HotkeyHandling.HOTKEY _HotkeyCompScreenBuffer = new HotkeyHandling.HOTKEY();
        private HotkeyHandling.HOTKEY _HotkeyCurrScreenBuffer = new HotkeyHandling.HOTKEY();
        private HotkeyHandling.HOTKEY _HotkeyDefScreenBuffer = new HotkeyHandling.HOTKEY();
        private HotkeyHandling.HOTKEY _HotkeyUploadBuffer = new HotkeyHandling.HOTKEY();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Cancel; }

        /// <summary>
        /// Beim Laden des Fensters werden die Einstellungen eingelesen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfig_Load(object sender, EventArgs e)
        {
            if (!STSystem.Settings.SystemSettings.GetDataBool("UseNoUserprofiles"))
            {
                labelHeadline.Text = "Einstellungen anpassen für " + Environment.UserName;
            }
            else
            {
                labelHeadline.Text = "Einstellungen anpassen";
            }

            textBoxFTPPass.PasswordChar = (char)0x25CF;

            checkBoxUseNoUserprofiles.Checked = STSystem.Settings.SystemSettings.GetDataBool("UseNoUserprofiles");


            textBoxExternalToolName.Text = STSystem.Settings.UserSettings.GetDataString("ExternalToolName");
            textBoxExternalToolFile.Text = STSystem.Settings.UserSettings.GetDataString("ExternalToolFile");
            textBoxHomeDir.Text = STSystem.Settings.UserSettings.GetDataString("Homedir");
            checkBoxCloseOnAction.Checked = STSystem.Settings.UserSettings.GetDataBool("CloseOnAction");
            numericUpDownHistoryLenght.Value = STSystem.Settings.UserSettings.GetDataInt("HistoryLenght");
            checkBoxEnableAutoUpdate.Checked = STSystem.Settings.UserSettings.GetDataBool("autoupdate");
            checkBoxAutorun.Checked = new OSIntegration().AutorunExists(STSystem.AppTitle);

            _HotkeyCompScreenBuffer = HotkeyHandling.Generate(STSystem.Settings.UserSettings.GetDataString("hotkeycompscreen"));
            _HotkeyCurrScreenBuffer = HotkeyHandling.Generate(STSystem.Settings.UserSettings.GetDataString("hotkeycurrscreen"));
            _HotkeyDefScreenBuffer = HotkeyHandling.Generate(STSystem.Settings.UserSettings.GetDataString("hotkeydefscreen"));
            _HotkeyUploadBuffer = HotkeyHandling.Generate(STSystem.Settings.UserSettings.GetDataString("HotkeyUpload"));

            checkBoxAlwaysOpenMaximized.Checked = STSystem.Settings.UserSettings.GetDataBool("AlwaysOpenMaximized");
            checkBoxCloseOnURLLink.Checked = STSystem.Settings.UserSettings.GetDataBool("CloseOnURLLink");
            checkBoxAutoShowScreen.Checked = STSystem.Settings.UserSettings.GetDataBool("AutoShowScreen");
            checkBoxHistoryTakeEdited.Checked = STSystem.Settings.UserSettings.GetDataBool("HistoryTakeEdited");
            checkBoxHistoryTakeSized.Checked = STSystem.Settings.UserSettings.GetDataBool("HistoryTakeSized");
            checkBoxAutoNumerate.Checked = STSystem.Settings.UserSettings.GetDataBool("AutoNumerate");
            textBoxDefaultFilename.Text = STSystem.Settings.UserSettings.GetDataString("DefaultFilename");
            checkBoxAutoSaveScreen.Checked = STSystem.Settings.UserSettings.GetDataBool("AutoSaveScreen");
            comboBoxAutosaveFiletype.Text = STSystem.Settings.UserSettings.GetDataString("AutoCompressFiletype");
            numericUpDownQualityAutocompress.Value = new decimal(STSystem.Settings.UserSettings.GetDataInt("QualityAutocompress"));
            checkBoxNoLoadAfterEdit.Checked = STSystem.Settings.UserSettings.GetDataBool("NoLoadAfterEdit");
            comboBoxUploadFormat.Text = STSystem.Settings.UserSettings.GetDataString("UploadFormat");
            checkBoxEnableHistory.Checked = STSystem.Settings.UserSettings.GetDataBool("HistoryEnabled");
            checkBoxUseTraymenuIcons.Checked = STSystem.Settings.UserSettings.GetDataBool("UseTraymenuIcons");
            comboBoxHotkeyUploadProvider.Text = STSystem.Settings.UserSettings.GetDataString("HotkeyUploadProvider");
            checkBoxShowSize.Checked = STSystem.Settings.UserSettings.GetDataBool("ShowSize");
            checkBoxAutoCopyToClipboard.Checked = STSystem.Settings.UserSettings.GetDataBool("AutoCopyToClipboard");

            labelHKFullScreenValue.Text = FormHotkeyGrabber.GetHKValue(_HotkeyCompScreenBuffer);
            labelHKCurrentScreenValue.Text = FormHotkeyGrabber.GetHKValue(_HotkeyCurrScreenBuffer);
            labelHKDefScreenValue.Text = FormHotkeyGrabber.GetHKValue(_HotkeyDefScreenBuffer);
            labelHKUploadValue.Text = FormHotkeyGrabber.GetHKValue(_HotkeyUploadBuffer);

            textBoxFTPServer.Text = STSystem.Settings.UserSettings.GetDataString("FTPServer");
            textBoxFTPDir.Text = STSystem.Settings.UserSettings.GetDataString("FTPDir");
            textBoxFTPUser.Text = STSystem.Settings.UserSettings.GetDataString("FTPUser");
            textBoxFTPPass.Text = STSystem.Settings.UserSettings.GetDataString("FTPPass");

            checkBoxEnableHistory_CheckedChanged(null, null);
            checkBoxAutoSaveScreen_CheckedChanged(null, null);

            STSystem.AnimateWindow(this);
        }

        /// <summary>
        /// Öffnet einen Dialog mit dem das HomeDir gesetzt werden kann
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetHomeDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog _Folder = new FolderBrowserDialog())
            {
                _Folder.Description = "Bitte wählen Sie einen Pfad aus in dem Ihre Screenshots gespeichert werden.";

                if (_Folder.ShowDialog() == DialogResult.OK)
                {
                    textBoxHomeDir.Text = _Folder.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Speichern der Einstellungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            STSystem.Settings.SystemSettings.SetDataValue("UseNoUserprofiles", checkBoxUseNoUserprofiles.Checked);
            
            STSystem.Settings.UserSettings.SetDataValue("ExternalToolFile", textBoxExternalToolFile.Text);
            STSystem.Settings.UserSettings.SetDataValue("ExternalToolName", textBoxExternalToolName.Text);
            STSystem.Settings.UserSettings.SetDataValue("HistoryEnabled", checkBoxEnableHistory.Checked);
            STSystem.Settings.UserSettings.SetDataValue("HistoryLenght", numericUpDownHistoryLenght.Value);
            STSystem.Settings.UserSettings.SetDataValue("Homedir", textBoxHomeDir.Text);
            STSystem.Settings.UserSettings.SetDataValue("CloseOnAction", checkBoxCloseOnAction.Checked);

            STSystem.Settings.UserSettings.SetDataValue("hotkeycompscreen", HotkeyHandling.Generate(_HotkeyCompScreenBuffer));
            STSystem.Settings.UserSettings.SetDataValue("hotkeycurrscreen", HotkeyHandling.Generate(_HotkeyCurrScreenBuffer));
            STSystem.Settings.UserSettings.SetDataValue("hotkeydefscreen", HotkeyHandling.Generate(_HotkeyDefScreenBuffer));
            STSystem.Settings.UserSettings.SetDataValue("HotkeyUpload", HotkeyHandling.Generate(_HotkeyUploadBuffer));

            STSystem.Settings.UserSettings.SetDataValue("AlwaysOpenMaximized", checkBoxAlwaysOpenMaximized.Checked);
            STSystem.Settings.UserSettings.SetDataValue("CloseOnURLLink", checkBoxCloseOnURLLink.Checked);
            STSystem.Settings.UserSettings.SetDataValue("AutoShowScreen", checkBoxAutoShowScreen.Checked);
            STSystem.Settings.UserSettings.SetDataValue("HistoryTakeEdited", checkBoxHistoryTakeEdited.Checked);
            STSystem.Settings.UserSettings.SetDataValue("HistoryTakeSized", checkBoxHistoryTakeSized.Checked);
            STSystem.Settings.UserSettings.SetDataValue("AutoNumerate", checkBoxAutoNumerate.Checked);
            STSystem.Settings.UserSettings.SetDataValue("DefaultFilename", textBoxDefaultFilename.Text);
            STSystem.Settings.UserSettings.SetDataValue("AutoSaveScreen", checkBoxAutoSaveScreen.Checked);
            STSystem.Settings.UserSettings.SetDataValue("AutoUpdate", checkBoxEnableAutoUpdate.Checked);
            STSystem.Settings.UserSettings.SetDataValue("AutoCompressFiletype", comboBoxAutosaveFiletype.Text);
            STSystem.Settings.UserSettings.SetDataValue("QualityAutocompress", numericUpDownQualityAutocompress.Value);
            STSystem.Settings.UserSettings.SetDataValue("NoLoadAfterEdit", checkBoxNoLoadAfterEdit.Checked);
            STSystem.Settings.UserSettings.SetDataValue("UploadFormat", comboBoxUploadFormat.Text);
            STSystem.Settings.UserSettings.SetDataValue("UseTraymenuIcons", checkBoxUseTraymenuIcons.Checked);
            STSystem.Settings.UserSettings.SetDataValue("HotkeyUploadProvider", comboBoxHotkeyUploadProvider.Text);
            STSystem.Settings.UserSettings.SetDataValue("ShowSize", checkBoxShowSize.Checked);
            STSystem.Settings.UserSettings.SetDataValue("AutoCopyToClipboard", checkBoxAutoCopyToClipboard.Checked);

            #region FTP-Server speichern

            //Pfadangabe überprüfen und korrigieren
            if (textBoxFTPDir.Text.Length > 0)
            {
                if (textBoxFTPDir.Text.Substring(0, 1) == "/")
                {
                    textBoxFTPDir.Text = textBoxFTPDir.Text.Substring(1);
                }
            }

            if(textBoxFTPDir.Text.Length > 0)
            {
                if (textBoxFTPDir.Text.Substring(textBoxFTPDir.Text.Length - 1) == "/")
                {
                    textBoxFTPDir.Text = textBoxFTPDir.Text.Substring(0, textBoxFTPDir.Text.Length - 1);
                }
            }

            if (textBoxFTPServer.Text.Length > 0)
            {
                if (textBoxFTPServer.Text.Substring(textBoxFTPServer.Text.Length - 1) == "/")
                {
                    textBoxFTPServer.Text = textBoxFTPServer.Text.Substring(0, textBoxFTPServer.Text.Length - 1);
                }
            }

            STSystem.Settings.UserSettings.SetDataValue("FTPServer", textBoxFTPServer.Text);
            STSystem.Settings.UserSettings.SetDataValue("FTPUser", textBoxFTPUser.Text);
            STSystem.Settings.UserSettings.SetDataValue("FTPDir", textBoxFTPDir.Text);
            STSystem.Settings.UserSettings.SetDataValue("FTPPass", textBoxFTPPass.Text);

            #endregion

            STSystem.Settings.UserSettings.SaveContent();
            STSystem.Settings.SystemSettings.SaveContent();

            #region HomeDir anlegen falls nicht vorhanden

            if (!Directory.Exists(textBoxHomeDir.Text))
            {
                Directory.CreateDirectory(textBoxHomeDir.Text);
            }

            #endregion

            #region Hotkeys aktualisieren

            HotkeyHandling.UnregisterAll(STSystem.STController);
            STSystem.CurrentHKCurr = _HotkeyCurrScreenBuffer;
            STSystem.CurrentHKFull = _HotkeyCompScreenBuffer;
            STSystem.CurrentHKDef = _HotkeyDefScreenBuffer;
            STSystem.CurrentHKUpload = _HotkeyUploadBuffer;

            STSystem.STController.RegisterHotkeys();

            #endregion

            #region Autostart konfigurieren

            if (checkBoxAutorun.Checked == true)
            {
                new OSIntegration().CreateAutorun(STSystem.AppTitle, Application.ExecutablePath);
            }
            else
            {
                new OSIntegration().DeleteAutorun(STSystem.AppTitle);
            }

            #endregion

            #region History aktualisieren

            if (checkBoxEnableHistory.Checked == false)
            {
                History.Lenght = 0;
            }
            else
            {
                if (History.Lenght != (int)numericUpDownHistoryLenght.Value)
                {
                    History.Lenght = (int)numericUpDownHistoryLenght.Value;
                }
            }

            #endregion

            STSystem.STController.SetTraymenuIcons(checkBoxUseTraymenuIcons.Checked);

            this.Close();
        }


        #region Hotkeys zuweisen

        /// <summary>
        /// Setzen des Hotkeys für den gesamten Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelSetFullScreen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormHotkeyGrabber _HKGrabber = new FormHotkeyGrabber())
            {
                _HKGrabber.Value = STSystem.CurrentHKFull;

                if (_HKGrabber.ShowDialog(this) == DialogResult.OK)
                {
                    labelHKFullScreenValue.Text = _HKGrabber.CurrentValue;
                    _HotkeyCompScreenBuffer     = _HKGrabber.Value;
                }
            }
        }

        /// <summary>
        /// Setzen des Hotkey für das aktuelle Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelSetCurrentScreen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormHotkeyGrabber _HKGrabber = new FormHotkeyGrabber())
            {
                _HKGrabber.Value = STSystem.CurrentHKCurr;

                if (_HKGrabber.ShowDialog(this) == DialogResult.OK)
                {
                    labelHKCurrentScreenValue.Text  = _HKGrabber.CurrentValue;
                    _HotkeyCurrScreenBuffer         = _HKGrabber.Value;
                }
            }
        }

        /// <summary>
        /// Setzen des Hotkeys für den Auswahlbereich
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelSetDefScreen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormHotkeyGrabber _HKGrabber = new FormHotkeyGrabber())
            {
                _HKGrabber.Value = STSystem.CurrentHKDef;

                if (_HKGrabber.ShowDialog(this) == DialogResult.OK)
                {
                    labelHKDefScreenValue.Text  = _HKGrabber.CurrentValue;
                    _HotkeyDefScreenBuffer      = _HKGrabber.Value;
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            tabControlConfig.Dispose();
            tabControlConfig = null;

            this.Dispose();
            GC.SuppressFinalize(this);
        }

        #region Hilfebehandlungen

        /// <summary>
        /// Aufrufen der Hilfe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void FormConfig_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            STSystem.ProcessHelpRequest(STSystem.HelpRequestIDs.config);
        }

        #endregion

        /// <summary>
        /// Setzt MS Paint als Bildbearbeitungsprogramm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelSetMSPaint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxExternalToolName.Text = "Microsoft Paint";
            textBoxExternalToolFile.Text = "mspaint.exe";
        }

        /// <summary>
        /// Setzt den Dateinamen zu dem externen Bildbearbeitungsprogramm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetExternalToolFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog _OpenFile = new OpenFileDialog())
            {
                _OpenFile.Title             = STSystem.AppTitle;
                _OpenFile.Filter            = "Programmdateien |*.exe";
                _OpenFile.RestoreDirectory  = true;

                if (_OpenFile.ShowDialog() == DialogResult.OK)
                {
                    textBoxExternalToolFile.Text = _OpenFile.FileName;
                }
            }
        }

        /// <summary>
        /// Wenn der Zustand geändert wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxEnableHistory_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHistoryTakeEdited.Enabled = checkBoxEnableHistory.Checked;
            checkBoxHistoryTakeSized.Enabled  = checkBoxEnableHistory.Checked;
            numericUpDownHistoryLenght.Enabled  = checkBoxEnableHistory.Checked;
        }

        /// <summary>
        /// Wenn der Zustand verändert wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoSaveScreen_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAutosaveFiletype.Enabled = checkBoxAutoSaveScreen.Checked;
            numericUpDownQualityAutocompress.Enabled = checkBoxAutoSaveScreen.Checked;
        }

        /// <summary>
        /// Setzen des Hotkeys für den Uploader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelSetUploader_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormHotkeyGrabber _HKGrabber = new FormHotkeyGrabber())
            {
                _HKGrabber.Value = STSystem.CurrentHKUpload;

                if (_HKGrabber.ShowDialog(this) == DialogResult.OK)
                {
                    labelHKUploadValue.Text = _HKGrabber.CurrentValue;
                    _HotkeyUploadBuffer = _HKGrabber.Value;
                }
            }
        }
    }
}