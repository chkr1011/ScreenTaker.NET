using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Screentaker.Win32API
{
    /// <summary>
    /// Methoden die aus der Kernel32.dll stammen
    /// </summary>
    public class Kernel32
    {
        /// <summary>
        /// The GlobalFindAtom function searches the global atom table 
        /// for the specified character string and retrieves the global 
        /// atom associated with that string.
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern ushort GlobalFindAtom(string lpString);


        /// <summary>
        /// The GlobalAddAtom function adds a character string to the global atom table
        /// and returns a unique value (an atom) identifying the string.
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern ushort GlobalAddAtom(string lpString);


        /// <summary>
        /// The GlobalDeleteAtom function decrements the reference count of
        /// a global string atom. If the atom's reference count reaches zero,
        /// GlobalDeleteAtom removes the string associated with the atom from the
        /// global atom table.
        /// </summary>
        /// <param name="nAtom"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern ushort GlobalDeleteAtom(ushort nAtom);
    }
}
