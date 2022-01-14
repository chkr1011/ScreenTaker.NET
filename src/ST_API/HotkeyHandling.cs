using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace Screentaker
{
    /// <summary>
    /// Stellt alle Methoden etc. bereit die für das Handling der Hotkeys nötig sind
    /// </summary>
    public static class HotkeyHandling
    {
        #region Internals

        private static ArrayList _Hotkeys = new ArrayList();

        #endregion

        #region Structs

        /// <summary>
        /// Dieses Struct stellt alle nötigen Informationen zu einem Hotkey bereit
        /// </summary>
        public struct HOTKEY
        {
            public ushort ID;
            public Keys Key;
            public bool RequiereAlt;
            public bool RequiereStrg;
            public bool RequiereShift;
            public ushort RequiereCode;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Liefert ein HOTKEY-Struct zurück welches durch die Message definiert wurde
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        private static HOTKEY GetHotkey(Message Msg)
        {
            int _SendedID = Msg.WParam.ToInt32();
            foreach (HOTKEY _CurrentHotkey in _Hotkeys)
            {
                if (_CurrentHotkey.ID == _SendedID)
                {
                    return _CurrentHotkey;
                }
            }

            return new HOTKEY();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registriert einen Globalen Hotkey. Dabei kann Spezifiziert werden welche Keys zudem gedrückt
        /// werden müssen
        /// </summary>
        /// <param name="hotkey"></param>
        /// <param name="mods"></param>
        public static void Register(Form Target, Keys Hotkey, bool ReqAlt, bool ReqStrg, bool ReqShift, ref string Exception)
        {
            ushort _Additions = 0;

            #region Zusatztasten hinzufügen

            if (ReqAlt) { _Additions += 1; }
            if (ReqStrg) { _Additions += 2; }
            if (ReqShift) { _Additions += 4; }

            //Win-Taste = 8

            #endregion

            try
            {
                ushort _CurrentID = Convert.ToUInt16((int)Hotkey + _Additions);

                // Registriere Hotkey, sonst werfe Fehler
                bool _RegSuccess = Win32API.User32.RegisterHotKey(Target.Handle, _CurrentID, _Additions, (int)Hotkey);

                if (!_RegSuccess)
                {
                    Exception = "Konnte Hotkey nicht registrieren. Möglicherweise wird dieser bereits durch ein anderes Programm verwendet.\nError code: " + Marshal.GetLastWin32Error();
                }
                else
                {
                    //Wenn der Hotkey erfolgreich hinzugefügt werden konnte wird
                    //ein neues Hotkey-Struct gefüllt und der Arraylist übergeben.
                    HOTKEY _NewHotkey = new HOTKEY();
                    _NewHotkey.ID = _CurrentID;
                    _NewHotkey.Key = Hotkey;
                    _NewHotkey.RequiereAlt = ReqAlt;
                    _NewHotkey.RequiereStrg = ReqStrg;
                    _NewHotkey.RequiereShift = ReqShift;
                    _NewHotkey.RequiereCode = _Additions;

                    _Hotkeys.Add(_NewHotkey);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "Warnung " + e.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                UnregisterAll(Target);
            }
        }

        /// <summary>
        /// Enternt alle Hotkeys die einem bestimmten Fenster zugeordnet
        /// wurden
        /// </summary>
        /// <param name="Target"></param>
        public static void UnregisterAll(Form Target)
        {
            foreach (HOTKEY _CurrentHK in _Hotkeys)
            {
                if (_CurrentHK.ID != 0)
                {
                    Win32API.User32.UnregisterHotKey(Target.Handle, _CurrentHK.ID);
                }
            }

            _Hotkeys.Clear();
        }

        /// <summary>
        /// Überprüft auf einen Hotkey der gedrückt wurde und gibt diesen
        /// als Keys zurück
        /// </summary>
        /// <param name="CurrentMessage"></param>
        /// <returns></returns>
        public static HOTKEY ProcessEvent(Message CurrentMessage)
        {
            //Nur weitermachen wenn es sich um eine Hotkey-Benachrichtigung
            //handelt. Ansonsten abbruch
            if (CurrentMessage.Msg == 0x312)
            {
                return GetHotkey(CurrentMessage);
            }

            return new HOTKEY();
        }

        /// <summary>
        /// Erstellt einen Hotkey an Hand der Values die durch ; getrennt werden
        /// KEYID;ADDITIONS
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static HOTKEY Generate(string Values)
        {
            HOTKEY _Result = new HOTKEY();
            string[] _Values = Values.Split(';');

            _Result.Key = (Keys)Enum.Parse(typeof(Keys), _Values[0]);
            _Result.RequiereAlt = Convert.ToBoolean(_Values[1]);
            _Result.RequiereStrg = Convert.ToBoolean(_Values[2]);
            _Result.RequiereShift = Convert.ToBoolean(_Values[3]);

            //Errechnen des Addition-Codes
            ushort _AddCode = 0;
            if (Convert.ToBoolean(_Values[1]) == true) { _AddCode += 1; }
            if (Convert.ToBoolean(_Values[2]) == true) { _AddCode += 2; }
            if (Convert.ToBoolean(_Values[3]) == true) { _AddCode += 4; }
            _Result.RequiereCode = _AddCode;

            return _Result;

        }

        /// <summary>
        /// Liefert einen String zurück mit dem wieder ein neuer HOTKEY generiert werden kann
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string Generate(HOTKEY Values)
        {
            string _Result = string.Empty;

            _Result += Values.Key.ToString() + ";";
            _Result += Values.RequiereAlt.ToString() + ";";
            _Result += Values.RequiereStrg.ToString() + ";";
            _Result += Values.RequiereShift.ToString();

            return _Result;
        }

        /// <summary>
        /// Liefert zurück ob ein Hotkey-String sowie ein HOTKEY-Struct identisch sind
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static bool Compare(HOTKEY SourceA, HOTKEY SourceB)
        {
            //if (SourceA.Key != SourceB.Key) { return false; }
            //if (SourceA.RequiereAlt != SourceB.RequiereAlt) { return false; }
            //if (SourceA.RequiereStrg != SourceB.RequiereStrg) { return false; }
            //if (SourceA.RequiereShift != SourceB.RequiereShift) { return false; }
            //return true;

            return ((SourceA.Key != SourceB.Key) || (SourceA.RequiereAlt != SourceB.RequiereAlt)
                || (SourceA.RequiereStrg != SourceB.RequiereStrg) || (SourceA.RequiereShift != SourceB.RequiereShift))
                ? false : true;
        }

        #endregion
    } 
}
