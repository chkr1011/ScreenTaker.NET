using System;
using System.Collections.Generic;
using System.Text;

namespace Screentaker
{
    /// <summary>
    /// Bietet einen Wert dem ein Name zugewiesen werden kann
    /// </summary>
    public class NamedValue
    {
        #region Internals

        private string _Name = string.Empty;
        private object _Value = null;
        private string _Block = string.Empty;
        private bool _Modified = false;

        #endregion

        #region Properies

        /// <summary>
        /// Name dieses Werts
        /// </summary>
        public string Name
        {
            get
            { return _Name; }

            set
            { _Name = value; }
        }

        /// <summary>
        /// Der eigentliche Wert dieses Werts
        /// </summary>
        public object Value
        {
            get
            { return _Value; }

            set
            {
                _Value = value;
                _Modified = true;

                if (value is string)
                {
                    _Value = FormatStringValue(Convert.ToString(value));
                }

                if (value is byte[])
                {
                    _Value = FormatBinaryValue((byte[])value);
                }

                if (value is bool)
                {
                    _Value = Convert.ToString(value);
                }
            }
        }

        /// <summary>
        /// Der Block in dem sich diese Einstellung befindet
        /// </summary>
        public string Block
        {
            get
            { return _Block; }

            set
            { _Block = value; }
        }

        /// <summary>
        /// Definiert ob dieser Wert bereits geändert wurde
        /// </summary>
        public bool Modified
        {
            get
            { return _Modified; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Liest den Wert an Hand einer Zeile wieder ein.
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="NewBlock"></param>
        public void Read(string Source, string NewBlock)
        {
            _Name = Source.Substring(0, Source.IndexOf("="));
            _Value = Source.Substring(Source.IndexOf("=") + 1);
            _Block = NewBlock;
        }

        /// <summary>
        /// Liefert diesen Wert als konformen INI-Eintrag zurück
        /// </summary>
        /// <returns></returns>
        public string Write()
        {
            return _Name + "=" + Convert.ToString(_Value);
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Formatiert ein Byte-Array in das gewünschte Format
        /// </summary>
        /// <param name="BinarySource"></param>
        /// <returns></returns>
        public static string FormatBinaryValue(byte[] BinarySource)
        {
            return EasyMask.ToHex(Encoding.Default.GetString(BinarySource));
        }

        /// <summary>
        /// Wandelt einen HEX-String wieder in ein Byte-Array zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static byte[] DeFormatBinaryValue(string Source)
        {
            return Encoding.Default.GetBytes(EasyMask.FromHex(Source));
        }

        /// <summary>
        /// Maskiert Zeilenumbrüche etc. und liefert das Ergebnis zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string FormatStringValue(string Source)
        {
            string _ResultBuffer = Source;
            _ResultBuffer = _ResultBuffer.Replace("\r\n", @"\r\n");
            _ResultBuffer.Replace("\n", @"\n");
            _ResultBuffer.Replace("\t", @"\t");

            return _ResultBuffer;
        }

        /// <summary>
        /// Erstetzt maskierte Steuerzeichen wieder durch echte Steuerzeichen
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string DeFormatStringValue(string Source)
        {
            string _ResultBuffer = Source;
            _ResultBuffer = _ResultBuffer.Replace(@"\r\n", "\r\n");
            _ResultBuffer = _ResultBuffer.Replace(@"\n", "\n");
            _ResultBuffer = _ResultBuffer.Replace(@"\t", "\t");

            return _ResultBuffer;
        }

        #endregion
    }
}
