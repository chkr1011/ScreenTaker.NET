using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

using Screentaker.Win32API;

namespace Screentaker
{
    public partial class FormControlSelector : Form
    {
        private IntPtr _ControlHandleBuffer = IntPtr.Zero;
        private bool _Capturing = false;
        private WindowHighlighter _CurrentHighlighter = new WindowHighlighter();
        private EmbeddedResources _ResReader = new EmbeddedResources();
        private ImageGrabbing _CurrentImageGrabber = new ImageGrabbing();
        private string _CurrentImageTitle = string.Empty;
        private Cursor _CurrentCursorBuffer = Cursor.Current;

        private Image _ScrollImageBuffer = new Bitmap(1,1);
        private int _PagePositionBuffer = -1;

        private System.Windows.Forms.Timer _CurrenScrollTimer = new System.Windows.Forms.Timer();


        public FormControlSelector()
        {
            InitializeComponent();

            textBoxDetails.Text = "Typ:\r\nTitel:";
        }

        #region Properties

        /// <summary>
        /// Liefert zurück ob der MausCursor sich in diesem Fenster befindet
        /// </summary>
        bool CursorIsInWindow
        {
            get
            {
                if ((this.Top <= MousePosition.Y) &&
                    (MousePosition.Y <= (this.Top + this.Height)))
                {
                    return true;
                }
                else
                {
                    if ((this.Left <= MousePosition.X) &&
                        (MousePosition.X <= (this.Left + this.Width)))
                    {
                        return true;
                    }
                    else
                    {
                        //Definitiv nicht
                        return false;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Verarbeitet Window-Messages
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case (int)User32.WindowMessages.WM_LBUTTONUP:
                    LeftMouseUpAction();
                    break;

                case (int)User32.WindowMessages.WM_MOUSEMOVE:
                    MouseMoveAction();
                    break;
            }
        }

        /// <summary>
        /// Positionieren des Forms sowie abbruch falls es bereits angezeigt wird
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

            base.OnLoad(e);
        }

        /// <summary>
        /// Wenn die Maus bewegt wird geschieht folgendes
        /// </summary>
        private void MouseMoveAction()
        {
            if (_Capturing)
            {
                IntPtr _CurrentHandle = User32.WindowFromPoint(Cursor.Position);

                if (_CurrentHandle != _ControlHandleBuffer)
                {
                    _CurrentHighlighter.RefreshControl(_ControlHandleBuffer);
                    _CurrentHighlighter.HighlightControl(_CurrentHandle);
                    _ControlHandleBuffer = _CurrentHandle;
                }

                StringBuilder _TextBuffer = new StringBuilder(256);
                User32.GetClassName(_CurrentHandle, _TextBuffer, 256);
                textBoxDetails.Text = "Typ:\t" + _TextBuffer.ToString() + "\r\n";
                _CurrentImageTitle = _TextBuffer.ToString();
                User32.GetWindowText(_CurrentHandle, _TextBuffer, 256);
                textBoxDetails.Text += "Titel:\t" + _TextBuffer.ToString() + "\r\n";
            }
        }

        /// <summary>
        /// Wenn die linke Maustaste losgelassen wird
        /// </summary>
        private void LeftMouseUpAction()
        {
            _Capturing = false;
            textBoxDetails.Text = string.Empty;

            User32.ReleaseCapture();
            Cursor.Current = _CurrentCursorBuffer;
            labelStart.Image = _ResReader.LoadImage("Selector_With.png");
            _CurrentHighlighter.RefreshControl(_ControlHandleBuffer);
            

            //if (CursorIsInWindow)
            //{
            //    MessageBox.Show(this, "Sie können kein Element dieses Fensters auswählen. Bitte versuchen Sie es mit einem anderen Element auf Ihrem Desktop",
            //        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            //Falls der Cursor wieder "zurückgelegt" wurde abbrechen
            IntPtr _IconHolderHandle = labelStart.Handle;
            if (_IconHolderHandle != User32.WindowFromPoint(MousePosition))
            {
                this.SendToBack();

                labelStart.Image = _ResReader.LoadImage("Selector_With.png");
                User32.RECT _TargetArea = new User32.RECT();
                User32.GetWindowRect(_ControlHandleBuffer, ref _TargetArea);

                #region Convertieren von Win32API.RECT nach Rectangle
                
                int _WindowX = _TargetArea.Left;
                int _WindowY = _TargetArea.Top;
                int _WindowHeight = _TargetArea.Bottom - _TargetArea.Top;
                int _WindowWidth = _TargetArea.Right - _TargetArea.Left;

                if (_WindowX < 0) { _WindowX = 0; }

                if (_WindowY < 0)
                {
                    _WindowHeight -= (2 * (_WindowY * -1));
                    _WindowY = 0;
                }

                Rectangle _TargetControlLocation = new Rectangle(_WindowX,
                    _WindowY, _WindowWidth, _WindowHeight);

                #endregion

                _CurrentImageGrabber.Show(_CurrentImageGrabber.GetScreen(_TargetControlLocation),
                    false, _CurrentImageTitle);

                this.Close();
            }
        }

        /// <summary>
        /// Aktiviert den ControlSelector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelStart_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = _ResReader.LoadCursor("Selector.cur");
            labelStart.Image = _ResReader.LoadImage("Selector_Without.png");
            _Capturing =  true;
            User32.SetCapture(this.Handle);
        }

        /// <summary>
        /// Schließt dieses Fenster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        { this.Close(); }

        /// <summary>
        /// Ruft die Hilfe für dieses Element auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            return; //Debug-Return
            
            _CurrenScrollTimer.Interval = 2000;
            _CurrenScrollTimer.Tick += new EventHandler(_CurrenScrollTimer_Tick);
            _CurrenScrollTimer.Start();
        }

        void _CurrenScrollTimer_Tick(object sender, EventArgs e)
        {
            Win32API.User32.SCROLLINFO _CurrentScrollInfo = new User32.SCROLLINFO();
            _CurrentScrollInfo.cbSize = Marshal.SizeOf(_CurrentScrollInfo);
            _CurrentScrollInfo.fMask = (int)User32.ScrollInfoMask.SIF_ALL;

            ImageGrabbing _CurrentGrabber = new ImageGrabbing();

            const int WM_VSCROLL = 0x115;
            //const int SB_BOTTOM = 7;
            //const int SB_TOP = 0;
            //const int SB_LINEDOWN = 1;
            const int SB_THUMBPOSITION = 4;
            const int SB_PAGEDOWN = 3;
            //const int WM_ENDSESSION = 0x0016;


            
            
            //labelInformation2.Text = "Buffer: " + _PagePositionBuffer.ToString() +
            //    " Current: " + _CurrentScrollInfo.nPos.ToString() + 
            //    " Track: " + _CurrentScrollInfo.nTrackPos.ToString() +
            //    " Page: " + _CurrentScrollInfo.nPage.ToString() +
            //    " Max: " +   _CurrentScrollInfo.nMax.ToString() +
            //    " Min: " + _CurrentScrollInfo.nMin.ToString();



            //if (_PagePositionBuffer == _CurrentScrollInfo.nPos)
            //{
            //    this.BackgroundImage = _ScrollImageBuffer;
            //    return;
            //}
            //else
            //{
            //    _PagePositionBuffer = _CurrentScrollInfo.nPos;
            //}

            IntPtr _TargetControl = User32.WindowFromPoint(MousePosition);

            //Setzt die Vertikale Scrollbar nach ganz oben
            User32.PostMessage(_TargetControl, WM_VSCROLL, SB_THUMBPOSITION, 0);

            Thread.Sleep(1000);

            //Auslesen der Infos für die Vertikale Scrollbar
            User32.GetScrollInfo(_TargetControl, Win32API.User32.SB_VERT, ref _CurrentScrollInfo);
            
            User32.RECT _TargetArea = new User32.RECT();
            User32.GetWindowRect(_TargetControl, ref _TargetArea);

            #region Convertieren von Win32API.RECT nach Rectangle
            
            int _WindowX = _TargetArea.Left + 2;
            int _WindowY = _TargetArea.Top + 3;
            int _WindowHeight = _TargetArea.Bottom - _TargetArea.Top - 7;
            int _WindowWidth = _TargetArea.Right - _TargetArea.Left;

            if (_WindowX < 0) { _WindowX = 0; }

            if (_WindowY < 0)
            {
                _WindowHeight -= (2 * (_WindowY * -1));
                _WindowY = 0;
            }

            #endregion

            Rectangle _TargetControlLocation = new Rectangle(_WindowX,
                _WindowY, _WindowWidth, _WindowHeight);

            int TEST = 0;

            for (int _CurrentIndexTab = 0; _CurrentIndexTab < (_CurrentScrollInfo.nMax / _CurrentScrollInfo.nPage); _CurrentIndexTab++)
            {
                TEST++;

                ImageProcessing.AppendVImage(ref  _ScrollImageBuffer,
                    _CurrentGrabber.GetScreen(_TargetControlLocation));

                //Scrollt 1 Seite nach unten
                User32.PostMessage(_TargetControl, WM_VSCROLL, SB_PAGEDOWN, 0);

                Thread.Sleep(1000);
            }

            this.BackgroundImage = (Image)_ScrollImageBuffer.Clone();

            _CurrenScrollTimer.Stop();
            _ScrollImageBuffer.Dispose();

            Text = TEST.ToString();
        }
    }
}