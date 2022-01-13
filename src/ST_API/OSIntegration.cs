using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Screentaker
{
    /// <summary>
    /// Bietet Methoden die f�r die Integration in das Basissystem n�tzlich sind
    /// </summary>
    public class OSIntegration
    {
        #region Autorun setzen

        /// <summary>
        /// Setz den Autostart f�r ein Programm. Command kann dabei der Dateiname
        /// etc. sein.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Command"></param>
        public void CreateAutorun(string Name, string Command)
        {
            using (RegistryKey _RunEntrys = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                _RunEntrys.SetValue(Name, Command);
            }
        }

        /// <summary>
        /// L�scht einen Eintrag im Autostart-Bereich der Registry
        /// </summary>
        /// <param name="Name"></param>
        public void DeleteAutorun(string Name)
        {
            using (RegistryKey _RunEntrys = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                if (AutorunExists(Name) == true)
                {
                    _RunEntrys.DeleteValue(Name);
                }
            }
        }

        /// <summary>
        /// Liefert zur�ck ob ein Wert f�r Autorun gesetzt wurde
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool AutorunExists(string Name)
        {
            using (RegistryKey _RunEntrys = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                foreach (string _CurrentName in _RunEntrys.GetValueNames())
                {
                    if (_CurrentName == Name)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion
    }
}
