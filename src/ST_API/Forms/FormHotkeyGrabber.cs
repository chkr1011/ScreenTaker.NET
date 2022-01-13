using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Screentaker
{
    public partial class FormHotkeyGrabber : Form
    {
        #region Constructor

        public FormHotkeyGrabber()
        {
            InitializeComponent();
        }

        #endregion

        #region Internals

        private HotkeyHandling.HOTKEY _CurrentHotkey = new HotkeyHandling.HOTKEY();

        #endregion

        #region Properties

        /// <summary>
        /// Der aktuell gesetzte Hotkey
        /// </summary>
        public HotkeyHandling.HOTKEY Value
        {
            get
            {
                return _CurrentHotkey;
            }

            set
            {
                _CurrentHotkey = value;
                UpdateCurrentHotkey();
            }      
        }

        /// <summary>
        /// Liefert den aktuellen Key als String zurück.
        /// Dabei wird der string als SHIFT + ALT + STRG + C zurückgegeben
        /// </summary>
        public string CurrentValue
        {
            get
            {
                return GetHKValue(_CurrentHotkey);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Zu verwendende Taste grabben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxChoosenKey_KeyUp(object sender, KeyEventArgs e)
        {
            textBoxChoosenKey.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// Wertet den aktuell gesetzten Hotkey aus und setzt die entsprechenden
        /// Informationen
        /// </summary>
        private void UpdateCurrentHotkey()
        {
            checkBoxRequiereShift.Checked = _CurrentHotkey.RequiereShift;
            checkBoxRequiereAlt.Checked = _CurrentHotkey.RequiereAlt;
            checkBoxRequiereSTRG.Checked = _CurrentHotkey.RequiereStrg;

            textBoxChoosenKey.Text = Convert.ToString(_CurrentHotkey.Key);
        }

        /// <summary>
        /// Bricht den Vorgang ab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Schließt dieses Fenster und gibt das Ergebnis zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            #region Fehlerprüfungen

            if (textBoxChoosenKey.Text == string.Empty)
            {
                Messages.WarningBox(this, "Bitte wählen Sie noch eine Taste aus.");
                return;
            }


            #endregion

            //Erst den neuen Hotkey setzen, dann Fenster schließen
            _CurrentHotkey.Key              = (Keys)Enum.Parse(typeof(Keys), textBoxChoosenKey.Text);
            _CurrentHotkey.RequiereAlt      = checkBoxRequiereAlt.Checked;
            _CurrentHotkey.RequiereStrg     = checkBoxRequiereSTRG.Checked;
            _CurrentHotkey.RequiereShift    = checkBoxRequiereShift.Checked;
           
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Public Methods (Static)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Hotkey"></param>
        /// <returns></returns>
        public static string GetHKValue(HotkeyHandling.HOTKEY Hotkey)
        {
            string _Result = string.Empty;

            if (Hotkey.RequiereAlt) { _Result += "Alt + "; }
            if (Hotkey.RequiereStrg) { _Result += "Strg + "; }
            if (Hotkey.RequiereShift) { _Result += "Shift + "; }

            _Result += Convert.ToString(Hotkey.Key);

            //Ausgabe des Ergebnisses
            return _Result;
        }
            
        #endregion

        #region Steuertastenbehandlung

        /// <summary>
        /// Setzt Tab als die verwendete Taste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelUseTab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxChoosenKey.Text = "Tab";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelUsePrintScreen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxChoosenKey.Text = "PrintScreen";
        }

        #endregion
    }


}