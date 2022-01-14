using System;
using System.IO;
using System.Net;
using System.Text;

namespace Screentaker.Uploader
{
    /// <summary>
    /// Abstrakte Klasse, die das Interface Upload implementiert.
    /// 
    /// Die Methode init sollte in der abgeleiteten Klasse direkt zu Beginn,
    /// also am besten im Konstruktor aufgerufen werden.
    /// </summary>
    public abstract class AbstractHttpUpload : Upload
    {
        /// <summary>
        /// Mit diesem Objekt erfolgt die Kommunikation mit dem Webserver
        /// </summary>
        protected HttpWebRequest request;
        
        /// <summary>
        /// Eine "Grenze" die für eine POST-Anfrage benötigt wird
        /// </summary>
        protected string boundary;

        /// <summary>
        /// Die Feldbezeichnung in HTML, die das Bild repräsentiert
        /// </summary>
        protected string fieldName = string.Empty;

        /// <summary>
        /// Die Antwort des Servers in Form eines Strings
        /// </summary>
        private string response = string.Empty;

        /// <summary>
        /// Liefert die Antwort des Servers in Form eines Strings wieder
        /// </summary>
        public string GetResponse
        {
            get { return this.response; }
        }

        // wird nicht benötigt
        public void init(string newPath, string url, string userName, string password) { }

        /// <summary>
        /// Setzt die "boundary", die URL an die die Anfrage geschickt werden soll
        /// und erzeugt an Hand dieser das HttpWebRequest-Objekt
        /// 
        /// Sollte in der Kindsklassen im Konstruktor aufgerufen werden.
        /// </summary>
        /// <param name="url">URL in Form eines Strings</param>
        /// <param name="fieldName">Name des Feldes an Hand dessen das Bild hochgeladen wird</param>
        protected void init(string url, string fieldName)
        {
            this.fieldName = fieldName;
            this.boundary = "--------" + DateTime.Now.ToString("MMddyyHHmmss")
                + DateTime.Now.Millisecond;

            this.request = WebRequest.Create(url) as HttpWebRequest;
            this.request.Method = "POST";
            this.request.ContentType = "multipart/form-data; boundary=" + this.boundary;
            this.request.Accept = "text/html, */*";
            this.request.UserAgent = "STUploader";
            this.request.AllowWriteStreamBuffering = true;

            // Den Expectheader deaktivieren...
            // TODO: Wozu ist der eigentlich. Irgendwas mit Proxy?
            ServicePointManager.Expect100Continue = false;
        }

        /// <summary>
        /// Gibt den Inhalt einer Datei in Form eines byte-Arrays wieder.
        /// </summary>
        /// <param name="file">Dateipfad</param>
        /// <returns>Datei in Form eines byte-Arrays</returns>
        protected byte[] GetFileContent(string file)
        {
            byte[] content = null;

            using (FileStream stream = File.OpenRead(file))
            {
                content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }

            return content;
        }

        /// <remarks>
        /// <seealso cref="ST.Upload.Upload.SendPostRequest(string path)">Upload.SendPostRequest(string path)</seealso>
        /// </remarks>
        /// <param name="path"></param>
        public abstract void SendPostRequest(string path);

        /// <summary>
        /// Versendet den Request an Hand des übergebenen POST-Headers sowie des
        /// Dateiinhaltes in Form eines byte-Arrays.
        /// </summary>
        /// <param name="postData">POST-Header</param>
        /// <param name="fileContent">Dateiinhalt</param>
        public void SendPostRequest(byte[] postData, byte[] fileContent)
        {
            // Das Ende des Posts
            byte[] endPostData = Encoding.ASCII.GetBytes("\r\n--" + this.boundary + "--\r\n");

            // Hier packen wir den PostHeader und den Dateiinhalt rein.
            // Das Postende wird seperat verschickt
            byte[] requestArray = new byte[postData.Length + fileContent.Length];

            // Daten in das requestArray kopieren
            postData.CopyTo(requestArray, 0);
            fileContent.CopyTo(requestArray, postData.Length - 1);

            // Hier berechnen wir die Content-Länge aus den beiden Arrays
            this.request.ContentLength = requestArray.Length + endPostData.Length;

            // Request senden
            using (Stream s = this.request.GetRequestStream())
            {
                s.Write(requestArray, 0, requestArray.Length);
                s.Write(endPostData, 0, endPostData.Length);
                s.Flush();
            }

            // und zuletzt die Antwort/Response lesen
            using (StreamReader reader = new StreamReader(this.request.GetResponse().GetResponseStream()))
            {
                this.response = reader.ReadToEnd();
            }
        }
    }
}