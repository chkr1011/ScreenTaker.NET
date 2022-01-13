using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LinkLabelEx
{
    public partial class LinkLabelEx : LinkLabel
    {
        #region Contructor

        public LinkLabelEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Internals

        private string _Command         = string.Empty;
        private string _Arguments       = string.Empty;
        private string _ExceptionText   = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Befehl der nach dem Klick auf den Link ausgeführt wird
        /// </summary>
        public string Command
        {
            get { return _Command; }
            
            set
            { 
                _Command = value;

                //Event attachen falls nötig
                if (_Command != string.Empty)
                {
                    base.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelEx_LinkClicked);
                }
                else
                {
                    //Bisher nichts
                }
            }
        }

        /// <summary>
        /// Argumente die mit dem Prozess verbunden werden sollen
        /// </summary>
        public string Arguments
        {
            get { return _Arguments; }
            set { _Arguments = value; }
        }

        /// <summary>
        /// Definiert den Text der angezeigt werden soll wenn ein Fehler auftritt
        /// </summary>
        public string ExceptionText
        {
            get { return _ExceptionText; }
            set { _ExceptionText = value; }
        }

        #endregion

        #region Overrides

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            _Arguments      = null;
            _Command        = null;
            _ExceptionText  = null;

            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Nach dem Klick auf einen Link wird der entsprechende Command ausgeführt.
        /// Falls der Command auf string.Empty gesetzt wird, geschieht nichts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabelEx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (Process _NewProcess = new Process())
                {
                    _NewProcess.StartInfo.FileName = _Command;
                    _NewProcess.StartInfo.Arguments = _Arguments;

                    _NewProcess.Start();
                }
            }
            catch
            {
                MessageBox.Show(_ExceptionText, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
