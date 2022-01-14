using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Screentaker
{
    /// <summary>
    /// Liefert Methoden zum Drucken etc.
    /// </summary>
    public class Printing
    {
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="preview"></param>
        /// <param name="Printername"></param>
        private void Print(Image img, PrintPreviewDialog preview, string Printername)
        {
            using (PrintDocument doc = new PrintDocument())
            {
                // Hier wird das PrintPage-Event in Form einer anonymen Methode erzeugt
                doc.PrintPage += delegate(object sender, PrintPageEventArgs e)
                {
                    Graphics g = e.Graphics;
                    g.PageUnit = GraphicsUnit.Millimeter;
                    g.PageScale = 1F;
                    g.DrawImage(img, new Point());
                };

                // Es wurde eine Vorschau erwünscht
                if (preview != null)
                {
                    doc.PrinterSettings.PrinterName = Printername;

                    preview.Document = doc;
                    preview.ShowDialog();
                }
                // direkt drucken
                else
                {
                    doc.PrinterSettings.PrinterName = Printername;

                    doc.Print();
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Zeigt eine Vorschau des Bildes an.
        /// Anschließend hat man die Möglichkeit es zu drucken.
        /// </summary>
        /// <param name="img">Das zu druckende Bild</param>
        public void PrintPreview(Image img, string Printername)
        {
            using (PrintPreviewDialog dialog = new PrintPreviewDialog())
            {
                Print(img, dialog, Printername);
            }
        }

        /// <summary>
        /// Druckt sofort das übergebene Bild
        /// </summary>
        /// <param name="img">Das zu druckende Bild</param>
        public void Print(Image img, string Printername)
        {
            Print(img, null);
        }

        #endregion
    }
}
