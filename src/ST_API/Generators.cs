using System;
using System.Collections.Generic;
using System.Text;

namespace Screentaker
{
    /// <summary>
    /// Liefert alle nötigen Methoden etc. um bestimmte Daten zu generieren
    /// oder zu manipulieren
    /// </summary>
    public static class Generators
    {
        #region Properties

        /// <summary>
        /// Liefert einen String des aktuellen Datum im folgenden Format
        /// YYMMTT
        /// </summary>
        public static string ShortDate
        {
            get
            {
                return string.Format("{0:yyMMdd}", DateTime.Now);
            }
        }

        /// <summary>
        /// Liefert einen String des aktuellen Datums + Uhrzeit zurück.
        /// Beispiel: 200704301230220120 (Milisekunden werden ebenfalls berücksichtigt!
        /// </summary>
        public static string LongDate
        {
            get
            {
                return string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Prüft ob einer der in Values angegebenen Werte im string Source
        /// enthalten sind
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static bool CheckString(string Source, string[] Values)
        {
            foreach (string _CurrentValue in Values)
            {
                if (Source.ToUpper().IndexOf(_CurrentValue.ToUpper()) > -1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Ersetzt alle in dem Array vorkommenden strings mit einem
        /// anderen string
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Find"></param>
        /// <param name="ReplaceWith"></param>
        /// <returns></returns>
        public static string ReplaceEx(string Source, string[] Find, string ReplaceWith)
        {
            string _Result = Source;

            foreach (string _CurrentFind in Find)
            {
                if (_CurrentFind != null)
                {
                    _Result = _Result.Replace(_CurrentFind, ReplaceWith);
                }
            }

            return _Result;
        }

        /// <summary>
        /// Füllt eine Zahl mit Nullen auf. Dabei wird Max als Begrenzung gesetzt.
        /// Bedeutet: aus 5 bei max 100 wird 005, aus 100 bei Max 1000 wird 0100
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Max"></param>
        /// <returns></returns>
        public static string FillNumber(int Value, int MaxValue)
        {
            int _MaxDigits = MaxValue.ToString().Length;
            return Value.ToString().PadLeft(_MaxDigits, '0');
        }

        #endregion
    } 
}
