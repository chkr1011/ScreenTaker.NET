using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Screentaker
{
    /// <summary>
    /// Bietet diverse Methoden um schnell und einfach Meldungen auszugeben
    /// </summary>
    public static class Messages
    {
        #region Public Methods

        /// <summary>
        /// Zeigt eine Warnungsbox an
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="Message"></param>
        public static void WarningBox(Form Parent, string Message)
        {
            MessageBox.Show(Parent, Message, STSystem.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Zeigt eine Errorbox an
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="Message"></param>
        public static void ErrorBox(Form Parent, string Message)
        {
            MessageBox.Show(Parent, Message, STSystem.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Zeigt eine Infobox an
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="Message"></param>
        public static void InfoBox(Form Parent, string Message)
        {
            MessageBox.Show(Parent, Message, STSystem.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
