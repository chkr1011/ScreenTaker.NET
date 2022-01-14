using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using Screentaker.Forms;
using Screentaker.Win32API;

namespace Screentaker
{
    /// <summary>
    /// Stellt alle nötigen Infos und Methoden zur Verfügung die zum grabben
    /// von Images benötigt werden
    /// </summary>
    public class ImageGrabbing : IDisposable
    {
        #region Enums

        /// <summary>
        /// Liefert alle 3 Typen an Screenshots die gegrabbt werden können
        /// </summary>
        public enum GrabType
        {
            Selection,
            FullScreen,
            ForegroundWindow
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liefert die Position und Größe des aktuellen Fensters zurück. Dies 
        /// kann dann mit GetScreenshot verwendet werden.
        /// </summary>
        /// <returns></returns>
        public Rectangle ForegroundWindow
        {
            get
            {
                //Handle des aktuellen Fensters ermitteln
                IntPtr _CurrentWindowHandle = Win32API.User32.GetForegroundWindow();

                Win32API.User32.RECT _ClientLocation = new Win32API.User32.RECT();

                //Position und Größe des Fensters ermitteln
                Win32API.User32.GetWindowRect(_CurrentWindowHandle, ref _ClientLocation);

                //Convertieren von Win32API.RECT nach Rectangle
                int _WindowX = _ClientLocation.Left;
                int _WindowY = _ClientLocation.Top;
                int _WindowHeight = _ClientLocation.Bottom - _ClientLocation.Top;
                int _WindowWidth = _ClientLocation.Right - _ClientLocation.Left;

                if (_WindowX < 0) { _WindowX = 0; }

                if (_WindowY < 0)
                {
                    _WindowHeight -= (2 * (_WindowY * -1));
                    _WindowY = 0;
                }

                if (_WindowWidth > Screen.PrimaryScreen.Bounds.Width)
                { _WindowWidth = Screen.PrimaryScreen.Bounds.Width; }

                return new Rectangle(_WindowX, _WindowY, _WindowWidth, _WindowHeight);
            }
        }

        /// <summary>
        /// Liefert ein Rectangle was exact die Screengröße entspricht
        /// </summary>
        public Rectangle FullScreen
        {
            get
            {
                int _AllWidth = Screen.AllScreens[Screen.AllScreens.Length - 1].Bounds.X +
                    Screen.AllScreens[Screen.AllScreens.Length - 1].Bounds.Width;

                int _AllHeight = Screen.AllScreens[Screen.AllScreens.Length - 1].Bounds.Y +
                    Screen.AllScreens[Screen.AllScreens.Length - 1].Bounds.Height;

                return new Rectangle(0, 0, _AllWidth, _AllHeight);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Liefert ein bestimmtes Icon eines geöffneten Fensters zurück
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="IconType">Small = 0; Large = 1</param>
        public Bitmap GetWindowIcon(IntPtr Target, int IconType)
        {
            try
            {
                int _Result = 0;

                User32.SendMessageTimeout(Target,
                    User32.WM_GETICON,
                    IconType,
                    0,
                    User32.SMTO_ABORTIFHUNG,
                    1000, out _Result);

                IntPtr _IconHandle = new IntPtr(_Result);

                if (_IconHandle == IntPtr.Zero)
                {
                    _Result = User32.GetClassLong(Target, User32.GCL_HICON);
                    _IconHandle = new IntPtr(_Result);
                }

                if (_IconHandle == IntPtr.Zero)
                {
                    User32.SendMessageTimeout(Target,
                        User32.WM_QUERYDRAGICON,
                        0,
                        0,
                        User32.SMTO_ABORTIFHUNG,
                        1000, out _Result);
                    _IconHandle = new IntPtr(_Result);
                }

                if (_IconHandle == IntPtr.Zero)
                    return null;
                else
                    return Bitmap.FromHicon(_IconHandle);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Diese Methode liefert einen Screenshot. Dabei wird der Bereich
        /// des Screenshots auf dem Desktop in Form eines Rectangles angegeben
        /// </summary>
        /// <param name="Area">Bereich auf dem Desktop</param>
        /// <returns></returns>
        public Image GetScreen(Rectangle Area)
        {
            #region Fehlerprüfungen

            //Damit keine ArgumentException bei einer Breite bzw Höhe des Auswahlrechtsecks
            //geworfen wird, setzen wir diese notfalls auf 1.
            if (Area.Width < 1)
            {
                Area.Width = 1;
            }

            if (Area.Height < 1)
            {
                Area.Height = 1;
            }

            #endregion

            #region Screenshot holen

            IntPtr _hDesktopWindow = Win32API.User32.GetDesktopWindow();
            IntPtr _hSource = Win32API.User32.GetDC(_hDesktopWindow);
            IntPtr _hDestination = Win32API.GDI32.CreateCompatibleDC(_hSource);
            IntPtr _hNewBitmap = Win32API.GDI32.CreateCompatibleBitmap(_hSource, Area.Width, Area.Height);
            IntPtr _hOldBitmap = Win32API.GDI32.SelectObject(_hDestination, _hNewBitmap);

            Win32API.GDI32.BitBlt(_hDestination, 0, 0, FullScreen.Width, FullScreen.Height, _hSource, Area.X, Area.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);

            Bitmap _AlphaScreenshot = Bitmap.FromHbitmap(_hNewBitmap);

            Win32API.GDI32.SelectObject(_hDestination, _hOldBitmap);
            Win32API.GDI32.DeleteObject(_hNewBitmap);
            Win32API.GDI32.DeleteDC(_hDestination);
            Win32API.GDI32.ReleaseDC(_hDestination, _hSource);

            #endregion

            #region Hinzufügen zu der History

            if (STSystem.Settings.UserSettings.GetDataBool("HistoryEnabled"))
            { History.Add(_AlphaScreenshot); }

            #endregion

            #region Autospeichern des Screenshots

            if (STSystem.Settings.UserSettings.GetDataBool("AutoSaveScreen"))
            {
                //Einstellungen einlesen
                string _TargetFile = STSystem.Settings.UserSettings.GetDataString("HomeDir") + @"\";
                string _DefFilename = STSystem.Settings.UserSettings.GetDataString("DefaultFilename");
                int _CompressionLevel = STSystem.Settings.UserSettings.GetDataInt("QualityAutocompress");
                string _Filetype = STSystem.Settings.UserSettings.GetDataString("AutoCompressFiletype");

                //Vorbereitungen
                if (!Directory.Exists(_TargetFile)) { Directory.CreateDirectory(_TargetFile); }

                _TargetFile += STSystem.GetUnusedFilename(_TargetFile, _DefFilename, "." + _Filetype.ToLower());
                ImageProcessing.CompressImage(_AlphaScreenshot, _CompressionLevel, ImageProcessing.GetEncDescription("." + _Filetype.ToLower()), _TargetFile);
            }

            #endregion

            #region Screenshot falls gewünscht in die Zwischenablage kopieren

            if (STSystem.Settings.UserSettings.GetDataBool("AutoCopyToClipboard"))
            { Clipboard.SetImage(_AlphaScreenshot); }

            #endregion

            return _AlphaScreenshot;
        }

        /// <summary>
        /// Zeigt einen neuen Screenshot an und überträgt ihn in die History etc.
        /// </summary>
        /// <param name="Screenshot"></param>
        /// <param name="IgnoreAutoShow"></param>
        /// <returns></returns>
        public void Show(Image Screenshot, bool IgnoreAutoShow, string Title)
        {
            //Neuen Screenshot nur falls gewünscht anzeigen
            if ((STSystem.Settings.UserSettings.GetDataBool("AutoShowScreen")) || (IgnoreAutoShow))
            {
                foreach (Form _CurrentForm in Application.OpenForms)
                {
                    if (_CurrentForm is FormCaptured)
                    {
                        ((FormCaptured)_CurrentForm).AddScreenshot(Screenshot, Title);
                        return;
                    }
                }


                FormCaptured _NewCapturedForm = new FormCaptured();
                _NewCapturedForm.AddScreenshot(Screenshot, Title);
                _NewCapturedForm.Show();
            }
        }

        /// <summary>
        /// Öffnet den Auswahlbereich um einen beliebigen Bereich zu grabben
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="GrabPen"></param>
        /// <param name="Transparency"></param>
        /// <param name="OnlyParent"></param>
        /// <returns></returns>
        public Rectangle SelectArea(Form Parent, Pen GrabPen, double Transparency, bool OnlyParent)
        {
            foreach (Form _CurrentScreen in Application.OpenForms)
            {
                if (_CurrentScreen is FormScreenSelector)
                {
                    //Falls bereits ein Auswahlfenster angezeigt wird wird der
                    //Vorgang abgeschlossen
                    _CurrentScreen.BringToFront();
                    return Rectangle.Empty;
                }
            }

            using (FormScreenSelector _Selector = new FormScreenSelector())
            {
                _Selector.Transparency = Transparency;
                _Selector.GrabbingPen = GrabPen;
                _Selector.ShowSize = STSystem.Settings.UserSettings.GetDataBool("ShowSize");

                if (OnlyParent)
                {
                    if (_Selector.GrabForm(Parent) == DialogResult.OK)
                    {
                        GrabPen.Dispose();
                        GrabPen = null;

                        return _Selector.SelectedArea;
                    }
                    else
                    {
                        GrabPen.Dispose();
                        GrabPen = null;

                        return Rectangle.Empty;
                    }
                }
                else
                {
                    if (_Selector.Grab(Parent) == DialogResult.OK)
                    {
                        GrabPen.Dispose();
                        GrabPen = null;

                        return _Selector.SelectedArea;
                    }
                    else
                    {
                        GrabPen.Dispose();
                        GrabPen = null;

                        return Rectangle.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Parent"></param>
        /// <returns></returns>
        public Rectangle SelectArea(Form Parent)
        {
            return SelectArea(Parent, new Pen(Color.Black, 1), .5, false);
        }

        /// <summary>
        /// Captured den entsprechenden Typ und zeigt diesen sofort im
        /// Bearbeitungsfenster an
        /// </summary>
        /// <param name="Type"></param>
        public void Grab(GrabType Type)
        {
            Rectangle _ImageArea = Rectangle.Empty;
            string _Title = string.Empty;

            if (Type == GrabType.Selection)
            {
                _ImageArea = SelectArea(null);
                _Title = _ImageArea.Height.ToString() + "x" + _ImageArea.Width.ToString();
            }
            else if (Type == GrabType.FullScreen)
            {
                _ImageArea = FullScreen;
                _Title = "Desktop";
            }
            else if (Type == GrabType.ForegroundWindow)
            {
                _ImageArea = ForegroundWindow;

                StringBuilder _TitleBuffer = new StringBuilder(256);
                IntPtr _TargetHandle = Win32API.User32.GetForegroundWindow();
                Win32API.User32.GetWindowText(_TargetHandle, _TitleBuffer, 256);

                _Title = _TitleBuffer.ToString();
            }

            //Abbruch falls die Größe nicht ermittelt werden konnte
            if (_ImageArea == Rectangle.Empty)
            { return; }

            Image _NewImage = GetScreen(_ImageArea);
            Show(_NewImage, false, _Title);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Verwendete Resourcen freigeben
        /// </summary>
        public void Dispose()
        {
           
        }

        #endregion
    }
}
