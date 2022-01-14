using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.IO;

namespace Screentaker
{
    /// <summary>
    /// Stellt alle Objekte und Methoden bez�glich der History bereit
    /// </summary>
    public static class History
    {
        #region Internals

        private static string[] _HistoryFiles = new string[0];
        private static int _HistoryIndex = 0;
        private static int _HistoryLenght = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Liest oder setzt die L�nge der History
        /// </summary>
        public static int Lenght
        {
            get
            {
                return _HistoryLenght;
            }

            set
            {
                _HistoryLenght = value;

                Clear();
            }
        }

        /// <summary>
        /// Liefert ein ImageArray mit allen vorhandenen Images aus der History
        /// </summary>
        /// <returns></returns>
        public static Image[] Images
        {
            get
            {
                ArrayList _ImageListBuffer = new ArrayList();

                //Jedes Image aus der Arraylist hinzuf�gen
                foreach (string _CurrentFilename in _HistoryFiles)
                {
                    //Pr�fungen
                    if (File.Exists(_CurrentFilename) == true)
                    {
                        _ImageListBuffer.Add(Image.FromFile(_CurrentFilename));
                    }
                }

                Image[] _Result = new Image[_ImageListBuffer.Count];

                //Konvertieren des Arrays in ein ImmageArray
                for (int _CurrentIndex = 0; _CurrentIndex < _Result.Length; _CurrentIndex++)
                {
                    _Result[_CurrentIndex] = (Image)_ImageListBuffer[_CurrentIndex];
                }

                _ImageListBuffer = null;

                return _Result;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// F�gt der Historie ein neues Bild hinzu
        /// </summary>
        /// <param name="NewImage"></param>
        public static void Add(Image NewImage)
        {
            //Falls die Funktion deaktiviert wurde werden alte Screenshots
            //gel�scht und die Objekte gekillt
            if (STSystem.Settings.UserSettings.GetDataBool("HistoryEnabled"))
            {
                string _Filename = STSystem.GetCachedFile(".bmp");
                NewImage.Save(_Filename, System.Drawing.Imaging.ImageFormat.MemoryBmp);

                //Index zur�cksetzen
                if (_HistoryIndex >= _HistoryLenght)
                {
                    _HistoryIndex = 0;
                }

                _HistoryFiles[_HistoryIndex] = _Filename;
                _HistoryIndex++;
            }
        }

        /// <summary>
        /// Setzt die History zur�ck
        /// </summary>
        public static void Clear()
        {
            foreach (string _CurrentHistoryFile in _HistoryFiles)
            {
                try
                {
                    File.Delete(_CurrentHistoryFile);
                }
                catch { }
            }

            _HistoryFiles = new string[_HistoryLenght];
            _HistoryIndex = 0;
        }

        #endregion
    }
}
