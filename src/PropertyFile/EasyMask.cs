using System;
using System.Collections.Generic;
using System.Text;

namespace Screentaker
{
    class EasyMask
    {
        #region Internals

        private static int _Rounds = 4;

        #endregion

        #region Properties

        /// <summary>
        /// Gibt an, wie oft der String in sich selbst verschlüsselt werden soll
        /// </summary>
        public static int Rounds
        {
            get
            { return _Rounds; }

            set
            { _Rounds = value; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Erhöht ein Byte um einen bestimmten Wert. Wenn dieser größer als 255 ist
        /// wird wieder bei 0 angefangen
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="CryptValue"></param>
        /// <returns></returns>
        private static int Up255(int Source, int CryptValue)
        {
            int _Result = Source + CryptValue;

            if (_Result > 255)
            {
                _Result -= 255;
            }

            return _Result;
        }

        /// <summary>
        /// Reduziert ein Byte um einen bestimmten Wert. Wenn dieser kleiner als 0 ist
        /// wird wieder bei 255 angefangen
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="CryptValue"></param>
        /// <returns></returns>
        private static int Down255(int Source, int CryptValue)
        {
            int _Result = Source - CryptValue;

            if (_Result < 0)
            {
                _Result += 255;
            }

            return _Result;
        }

        /// <summary>
        /// Reduziert die Angegbene Quelle um DownValue. Sollte das 
        /// Ergebnis kleiner 0 sein wird 9 als Ergebnis zurückgeliefert
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static int Down9(int Source, int Value)
        {
            int _Result = Source - Value;

            if (_Result < 0)
            {
                _Result = 9 - (_Result * (-1));
            }

            return _Result;
        }

        /// <summary>
        /// Erhöht die Angegbene Quelle um DownValue. Sollte das 
        /// Ergebnis größer 9 sein wird 0 als Ergebnis zurückgeliefert
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static int Up9(int Source, int Value)
        {
            int _Result = Source + Value;

            if (_Result > 9)
            {
                _Result = 9 - (_Result * (-1));
            }

            return _Result;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Errechnet eine Anzahl von Runden an Hand einer Passworts. Dieses
        /// muss dann zum ent- sowie verschlüsseln angegeben werden
        /// </summary>
        /// <param name="Password"></param>
        public static void SetRoundsFromPass(string Password)
        {
            byte[] _PassCharBuffer = Encoding.Default.GetBytes(Password);
            int _ResultBuffer = 0;

            for (int _CurrentIndex = 0; _CurrentIndex < _PassCharBuffer.Length; _CurrentIndex++)
            {
                _ResultBuffer += Convert.ToInt32(_PassCharBuffer[_CurrentIndex]);
            }

            _Rounds = _ResultBuffer;
        }

        /// <summary>
        /// Liefert einen angegebenen String als String zurück in dem der verschlüsselte
        /// String als Hexa-Dezial-Wert angezeigt wird.
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string Encrypt(string Source)
        {
            string _Result = string.Empty;
            byte[] _CharsBuffer = Encoding.Default.GetBytes(Source);

            #region String verschlüsseln

            int _CurrentCryptValue = 9;
            for (int _CurrentRound = 0; _CurrentRound < _Rounds; _CurrentRound++)
            {
                for (int _CurrentChar = 0; _CurrentChar < _CharsBuffer.Length; _CurrentChar++)
                {
                    int _CurrentByte = Convert.ToInt32(_CharsBuffer[_CurrentChar]);
                    _CurrentByte = Down255(_CurrentByte, _CurrentCryptValue);
                    _CharsBuffer[_CurrentChar] = Convert.ToByte(_CurrentByte);

                    _CurrentCryptValue = Down9(_CurrentCryptValue, 1);
                }
            }

            #endregion

            return Encoding.Default.GetString(_CharsBuffer);
        }

        /// <summary>
        /// Verschlüsselt einen String und liefert ihn im Hex-Format zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string EncryptToHex(string Source)
        {
            return ToHex(Encrypt(Source));
        }

        /// <summary>
        /// Liefert einen entschlüsselten String als String zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string Decrypt(string Source)
        {
            string _Result = string.Empty;
            byte[] _CharsBuffer = Encoding.Default.GetBytes(Source);

            #region String verschlüsseln

            int _CurrentCryptValue = 9;

            for (int _CurrentRound = 0; _CurrentRound < _Rounds; _CurrentRound++)
            {
                for (int _CurrentChar = 0; _CurrentChar < _CharsBuffer.Length; _CurrentChar++)
                {
                    int _CurrentByte = Convert.ToInt32(_CharsBuffer[_CurrentChar]);
                    _CurrentByte = Up255(_CurrentByte, _CurrentCryptValue);
                    _CurrentCryptValue = Down9(_CurrentCryptValue, 1);

                    _CharsBuffer[_CurrentChar] = Convert.ToByte(_CurrentByte);
                }
            }

            #endregion

            return Encoding.Default.GetString(_CharsBuffer);
        }

        /// <summary>
        /// Entschlüsselt einen String der im Hex-Format voeliegt
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string DecryptFromHex(string Source)
        {
            return Decrypt(FromHex(Source));
        }

        /// <summary>
        /// Liefert einen String als Hex-Formatiert zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string ToHex(string Source)
        {
            string _Result = string.Empty;
            byte[] _ResultChars = Encoding.Default.GetBytes(Source);

            for (int _CurrentIndex = 0; _CurrentIndex < _ResultChars.Length; _CurrentIndex++)
            {
                _Result += string.Format("{0:X2}", Convert.ToInt32(_ResultChars[_CurrentIndex]));
            }

            return _Result;
        }

        /// <summary>
        /// Liefert einen String der im Hex-Format vieliegt als Normal-Text zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string FromHex(string Source)
        {
            string _Result = string.Empty;
            string _HexBuffer = Source;

            ////Prüfung auf gültige Daten
            //if ((_HexBuffer.Length / 2) != 0)
            //{
            //    throw new Exception("001: Das Format ist nicht gültig.");
            //}

            while (_HexBuffer != string.Empty)
            {
                string _CurrentHex = _HexBuffer.Substring(0, 2);
                _HexBuffer = _HexBuffer.Substring(2);

                int _CurrentValue = Int32.Parse(_CurrentHex, System.Globalization.NumberStyles.HexNumber);
                _Result += Encoding.Default.GetString(new byte[1] { (byte)_CurrentValue });
            }

            return _Result;
        }

        #endregion
    }
}
