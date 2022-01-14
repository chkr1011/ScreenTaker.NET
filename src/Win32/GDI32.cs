using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Screentaker.Win32API
{
    /// <summary>
    /// Methoden der GDI32.dll
    /// </summary>
    public class GDI32
    {
        /// <summary>
        /// The BitBlt function performs a bit-block transfer of the color
        /// data corresponding to a rectangle of pixels from the specified source
        /// device context into a destination device context.
        /// </summary>
        /// <param name="hdcDest"></param>
        /// <param name="xDest"></param>
        /// <param name="yDest"></param>
        /// <param name="wDest"></param>
        /// <param name="hDest"></param>
        /// <param name="hdcSource"></param>
        /// <param name="xSrc"></param>
        /// <param name="ySrc"></param>
        /// <param name="rop"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC,
            int xSrc, int ySrc, CopyPixelOperation dwRop);


        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing
        /// it for use by other applications. The effect of the ReleaseDC 
        /// function depends on the type of DC. It frees only common and window DCs.
        /// It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hDc"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        /// <summary>
        /// The DeleteDC function deletes the specified device context (DC).
        /// </summary>
        /// <param name="hDc"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        /// <summary>
        /// The DeleteObject function deletes a logical pen, brush, font, 
        /// bitmap, region, or palette, freeing all system resources associated
        /// with the object. After the object is deleted, the specified handle
        /// is no longer valid.
        /// </summary>
        /// <param name="hDc"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        /// <summary>
        /// The CreateCompatibleBitmap function creates a bitmap 
        /// compatible with the device that is associated with the 
        /// specified device context.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        /// <summary>
        /// The CreateCompatibleDC function creates a memory device context (DC)
        /// compatible with the specified device.
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// The SelectObject function selects an object into the specified 
        /// device context (DC). The new object replaces the previous 
        /// object of the same type.
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="bmp"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
    }
}
