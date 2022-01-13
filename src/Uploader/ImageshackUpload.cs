using System.Text;

namespace Screentaker.Uploader
{
    /// <summary>
    /// Lädt ein Bild auf die Seite http://imageshack.us hoch
    /// </summary>
    public class ImageshackUpload : AbstractHttpUpload
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public ImageshackUpload()
        {
            this.init("http://imageshack.us/index.php", "fileupload");
        }

        /// <summary>
        /// Override
        /// </summary>
        /// <param name="path">path</param>
        public override void SendPostRequest(string path)
        {
            // PostHeader erstellen
            byte[] postData = Encoding.ASCII.GetBytes("--" + this.boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"xml\"\r\n\r\n\"yes\"\r\n"
                + "--" + this.boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"optimage\"\r\n\r\n1\r\n\r\n"
                + "--" + this.boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"optsize\"\r\n\r\n\"resample\"\r\n"
                + "--" + this.boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"cookie\"\r\n\r\n\r\n"
                + "--" + this.boundary + "\r\n"
                + "Content-Disposition: form-data; name=\"" + this.fieldName + "\"; filename=\""
                + path + "\"\r\nContent-Type: multipart/form-data" + "\r\n\r\n\n");

            // Dateiinhalt in Bytes umwandeln
            byte[] fileContent = this.GetFileContent(path);

            // Request verschicken
            this.SendPostRequest(postData, fileContent);
        }
    }
}
