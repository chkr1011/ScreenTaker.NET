using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace Screentaker
{
    /// <summary>
    /// 
    /// </summary>
    public class EmbeddedResources
    {
        /// <summary>
        /// Öffnet eine eingebettete Resource als Stream
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Stream Load(string Name)
        {
            try
            {
                Stream _CurentStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Screentaker.Resources." + Name);
                return _CurentStream;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Öffnet ein Image aus den eingebundenen Resourcen
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Image LoadImage(string Name)
        {
            try
            {
                return Image.FromStream(Load(Name));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Öffnet einen Cursor aus den eingebundenen Resourcen
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public Cursor LoadCursor(string Name)
        {
            try
            {
                return new Cursor(Load(Name));
            }
            catch
            {
                return null;
            }

        }
    }
}
