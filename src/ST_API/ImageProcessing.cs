using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Screentaker
{
    /// <summary>
    /// Liefert Methoden etc. um Images zu bearbeiten
    /// </summary>
    public static class ImageProcessing
    {
        #region Enums

        /// <summary>
        /// Enthält alle Encoderdescriptions
        /// </summary>
        public enum EncoderByDesc
        {
            JPG,
            BMP,
            GIF,
            TIFF,
            PNG
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Fügt einem Image ein weiteres Image hinzu. Dies wird unten an das Ausgangsbild eingefügt.
        /// Das hinzuzufügende Image muss die selbe Breite wie das Ausgangsimage haben.
        /// </summary>
        /// <param name="DefaultImage"></param>
        /// <param name="AppendImage"></param>
        public static void AppendVImage(ref Image DefaultImage, Image AppendImage)
        {
            if (DefaultImage == null)
            { return; }

            if (AppendImage == null)
            { return; }

            int _NewHeigth = DefaultImage.Height + AppendImage.Height;
            int _NewWidth = DefaultImage.Width + AppendImage.Width;

            using (Bitmap _ResultBuffer = new Bitmap(_NewWidth, _NewHeigth))
            {
                using (Graphics _CurrentGraphics = Graphics.FromImage(_ResultBuffer))
                {
                    _CurrentGraphics.DrawImageUnscaled(DefaultImage, 0, 0);
                    _CurrentGraphics.DrawImageUnscaled(AppendImage, 0, DefaultImage.Height);
                    _CurrentGraphics.Save();
                }

                DefaultImage = (Image)_ResultBuffer.Clone();
            }
        }

        /// <summary>
        /// Verändert nicht die Größe des Ausgangsimages und zeichnet das PutImage
        /// an die unterste Position des Ausgangsbildes. Beide Images müssen dazu die 
        /// gleiche Breite haben
        /// </summary>
        /// <param name="DefaultImage"></param>
        /// <param name="PutImage"></param>
        public static void PutImageBottom(ref Image DefaultImage, Image PutImage)
        {
            using(Graphics _CurrentGraphics = Graphics.FromImage(DefaultImage))
            {
                Point _TargetPoint = new Point(DefaultImage.Width - PutImage.Width, 0);

                _CurrentGraphics.DrawImageUnscaled(PutImage, _TargetPoint);
                _CurrentGraphics.Save();
            }
        }

        /// <summary>
        /// Liefert ein Thumbnail eines Images zurück
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static Image GetThumbnail(Image Source, int Width, int Height)
        {
            try
            {
                return Source.GetThumbnailImage(Width, Height,
                    new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            }
            catch
            {
                return Source;
            }
        }


        /// <summary>
        /// Benötigt GetThumbnail
        /// </summary>
        /// <returns>true</returns>
        public static bool ThumbnailCallback()
        {
            return true;
        }

        /// <summary>
        /// Liefert an Hand der Extension den entsprechenden Codec
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static EncoderByDesc GetEncDescription(string Extension)
        {
            switch (Extension.ToUpper())
            {
                case ".JPG": return EncoderByDesc.JPG;
                case ".PNG": return EncoderByDesc.PNG;
                case ".BMP": return EncoderByDesc.BMP;
                case ".TIF": return EncoderByDesc.TIFF;

                default: return EncoderByDesc.PNG;
            }
        }

        /// <summary>
        /// Liefert ein ImageCodecInfo an Hand des MimeTypes
        /// </summary>
        public static ImageCodecInfo GetEncoderInfo(EncoderByDesc Description)
        {
            string _DescBuffer = Description.ToString();
            if (_DescBuffer == "JPG") { _DescBuffer = "JPEG"; }

            ImageCodecInfo[] _AllCodecs = ImageCodecInfo.GetImageEncoders();
            for (int _CurrentIndex = 0; _CurrentIndex < _AllCodecs.Length; _CurrentIndex++)
            {
                if (_AllCodecs[_CurrentIndex].FormatDescription == _DescBuffer)
                {
                    return _AllCodecs[_CurrentIndex];
                }
            }

            //Keiner gefunden!
            return null;
        }

        /// <summary>
        /// Öffnet den Aktuellen Screenshot in konfigurierten externen Programm.
        /// </summary>
        /// <param name="Screenshot"></param>
        /// <param name="AppFile"></param>
        /// <param name="AppName"></param>
        /// <param name="WaitForExit"></param>
        /// <returns></returns>
        public static Image EditExternal(Image Screenshot, string AppFile, string AppName, bool WaitForExit)
        {
            //Der Screenshot wird zunächst im Temp-Verzeichnis mit einem eindeutigen
            //Dateinamen gespeichert. Danach wird das entsprechende Programm geöffnet.
            //Solange das Tool geöffnet ist bleibt Screentaker.NET eingefroren.
            //Sobald das Tool beendet wird lädt der Screentaker das Bild aus dem Cache
            //Verzeichnis neu ein und zeigt es an. Danach kann es wie gewohnt gespeichert
            //werden etc.
            string _Filename = STSystem.GetCachedFile(".bmp");
            Screenshot.Save(_Filename, ImageFormat.MemoryBmp);

            #region Starten des Externen Tools

            Process _ExternalToolExe = new Process();
            _ExternalToolExe.StartInfo.FileName = AppFile;
            _ExternalToolExe.StartInfo.Arguments = "\"" + _Filename + "\"";

            try
            {
                _ExternalToolExe.Start();
            }
            catch
            {
                MessageBox.Show(AppName + " konnte nicht gestartet werden.",
                    STSystem.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Screenshot;
            }

            #endregion

            #region Auf Programmende warten

            if (WaitForExit == true)
            {
                _ExternalToolExe.WaitForExit();
            }

            #endregion

            #region Bearbeitetes Bild einlesen und zurückliefern

            Image _Result = null;
            try
            {
                _Result = Image.FromFile(_Filename);
            }
            catch { }

            #endregion

            return _Result;
        }

        #region Compress Image

        /// <summary>
        /// Liefert ein komprimiertes Image zurück.
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="QualityLevel"></param>
        /// <returns></returns>
        public static Image CompressImage(Image Source, int QualityLevel, EncoderByDesc EncoderDesc, ref double ResultSize, string Filename)
        {
            //Entsprechenden Parameter für den Encoder bestimmen
            EncoderParameter _QualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt32(QualityLevel));

            //Informationen für den Codec zusammensetzen
            ImageCodecInfo _IMGCodec = ImageProcessing.GetEncoderInfo(EncoderDesc);
            EncoderParameters _EncParams = new EncoderParameters(1);
            _EncParams.Param[0] = _QualityParam;

            //Image mit der neuen Qualitätseinstellung speichern und
            //neu einlesen
            MemoryStream _FileStream = new MemoryStream();
            Source.Save(_FileStream, _IMGCodec, _EncParams);
            ResultSize = _FileStream.Length;
            Bitmap _ImageBuffer = new Bitmap(Image.FromStream(_FileStream));
            _FileStream.Close();

            if (Filename != string.Empty)
            {
                if (EncoderDesc == EncoderByDesc.BMP)
                {
                    _ImageBuffer.Save(Filename, ImageFormat.MemoryBmp);
                }
                else
                {
                    _ImageBuffer.Save(Filename, _IMGCodec, _EncParams);
                }
            }

            return _ImageBuffer;
        }

        /// <summary>
        /// Liefert ein komprimiertes Image zurück.
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="QualityLevel"></param>
        /// <returns></returns>
        public static Image CompressImage(Image Source, int QualityLevel)
        {
            double _Buffer = 0;
            return CompressImage(Source, QualityLevel, EncoderByDesc.JPG, ref _Buffer, string.Empty);
        }

        /// <summary>
        /// Liefert ein komprimiertes Image zurück.
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="QualityLevel"></param>
        /// <returns></returns>
        public static Image CompressImage(Image Source, int QualityLevel, EncoderByDesc EncDesc, string Filename)
        {
            double _Buffer = 0;
            return CompressImage(Source, QualityLevel, EncDesc, ref _Buffer, Filename);
        }

        /// <summary>
        /// Liefert ein komprimiertes Image zurück.
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="EncDesc"></param>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static Image CompressImage(Image Source, EncoderByDesc EncDesc, string Filename)
        {
            return CompressImage(Source, 100, EncDesc, Filename);
        }

        /// <summary>
        /// Speichert das angegebene Image in höchster Qualität im angegebenen Dateinamen
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static Image CompressImage(Image Source, string Filename)
        {
            return CompressImage(Source, 100, GetEncDescription(Filename.Substring(Filename.LastIndexOf(".") - 1)), Filename);
        }

        #endregion

        /// <summary>
        /// Öffnet einen Dialog zum öffnen einer Bilddatei
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="InitDir"></param>
        /// <returns></returns>
        public static Image OpenImage(Form Parent, string InitDir)
        {
            OpenFileDialog _OpenImage = new OpenFileDialog();

            _OpenImage.Title = STSystem.AppTitle;
            _OpenImage.Filter = "Bilddateien |*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            _OpenImage.InitialDirectory = InitDir;
            _OpenImage.CheckFileExists = true;
            _OpenImage.RestoreDirectory = true;


            if (_OpenImage.ShowDialog(Parent) == DialogResult.OK)
            {
                //Prüfen auf gültigen Dateityp
                string _CurrentExtension = new FileInfo(_OpenImage.FileName).Extension;
                if (!Generators.CheckString(_CurrentExtension, new string[5] { ".jpg", ".jpeg", ".bmp", ".png", ".gif" }))
                {
                    Messages.ErrorBox(Parent, "Sie haben keinen gültigen Dateitypen angegeben. Ein Upload ist daher nicht möglich.");
                    return null;
                }

                //Image zurückgeben
                try
                {
                    //FileStream _ImageStream = new FileStream(_OpenImage.FileName, FileMode.Open);
                    //Image _ResultBuffer = Image.FromStream(_ImageStream);

                    //_OpenImage.Dispose();

                    return Image.FromFile(_OpenImage.FileName);
                }
                catch { return null; }

            }
            else { return null; }

        }

        #endregion
    }
}
