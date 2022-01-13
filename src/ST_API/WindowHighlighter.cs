using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Screentaker.Win32API;

namespace Screentaker
{
    public class WindowHighlighter
    {
        /// <summary>
        /// Zeichnet einen Rahmen um ein Control
        /// </summary>
        /// <param name="Target"></param>
        public void HighlightControl(IntPtr Target)
        {
            //Position und Größe des Zielelements holen
            User32.RECT _TargetRect = new User32.RECT();
            User32.GetWindowRect(Target, ref _TargetRect);

            IntPtr _TargetDC = User32.GetWindowDC(Target);
            if (_TargetDC != IntPtr.Zero)
            {
                //Falls der Bereich vorhanden ist wird er nun markiert
                using (Pen _CurrentPen = new Pen(Color.Red, 2))
                {
                    using (Graphics _CurrentGraphics = Graphics.FromHdc(_TargetDC))
                    {
                        _CurrentGraphics.DrawRectangle(_CurrentPen, 0, 0,
                            _TargetRect.Right - _TargetRect.Left,
                            _TargetRect.Bottom - _TargetRect.Top);
                    }
                }
            }

            GDI32.ReleaseDC(Target, _TargetDC);
        }

        /// <summary>
        /// Veranlasst ein Control sich neu zu zeichnen
        /// </summary>
        /// <param name="Target"></param>
        public void RefreshControl(IntPtr Target)
		{
            User32.InvalidateRect(Target, IntPtr.Zero, 1);
            User32.UpdateWindow(Target);
            User32.RedrawWindow(Target, IntPtr.Zero, IntPtr.Zero, User32.RDW_FRAME |
                User32.RDW_INVALIDATE |
                User32.RDW_UPDATENOW |
                User32.RDW_ALLCHILDREN);
        }
    }
}
