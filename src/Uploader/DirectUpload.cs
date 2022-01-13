using System.Text;

namespace Screentaker.Uploader
{
    /// <summary>
    /// Lädt eine Bild auf die Seite http://www.directupload.net hoch
    /// </summary>
    public class DirectUpload : AbstractHttpUpload
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public DirectUpload()
        {
            this.init("http://www.directupload.net/index.php?mode=upload", "bilddatei");
        }

        /// <summary>
        /// Override
        /// </summary>
        /// <param name="path">path</param>
        public override void SendPostRequest(string path)
        {
            byte[] postData = Encoding.ASCII.GetBytes("--" + boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"" + this.fieldName + "\"; filename=\""
                + path + "\"\r\nContent-Type: multipart/form-data" + "\r\n\r\n\n");

            // Dateiinhalt in Bytes umwandeln
            byte[] fileContent = this.GetFileContent(path);

            // Request verschicken
            this.SendPostRequest(postData, fileContent);
        }
    }
}