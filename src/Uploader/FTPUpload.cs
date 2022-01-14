using System.Net;
using System.IO;

namespace Screentaker.Uploader
{
    /// <summary>
    /// Diese recht klein gehaltene Klasse ist für einen einfachen FTP-Upload zuständig.
    /// 
    /// Sie kann wie folgt aufgerufen werden:
    /// <example>
    /// Upload upload = UploadFactory.GetInstance.createUpload(UploadType.FtpUpload);
    /// upload.init("bar.png", "127.0.0.1", "user", "passwd");
    /// upload.SendPostRequest(@"e:\home\Witi\Desktop\foo.png");
    /// Console.WriteLine(upload.GetResponse);
    /// 
    /// Bei einem erfolgreichen Upload schickt der Server einen "226 Transfer complete."
    /// </example>
    /// 
    /// </summary>
    public class FtpUpload : Upload
    {
        /// <summary>
        /// FtpRequest
        /// </summary>
        private FtpWebRequest request;
        /// <summary>
        /// URL
        /// </summary>
        private string url;

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

        /// <summary>
        /// Konstruktor
        /// </summary>
        public FtpUpload() {} //  bleibt auf Grund des Designs der UploadFactory leer

        /// <summary>
        /// init-Methode, die den Namen der Datei, den Hostname bzw. IP des Servers, sowie die
        /// Login-Daten bestehend aus dem Usernamen und dem Password erwartet.
        /// 
        /// newPath kann auch ein existierender Pfad auf dem Server sein.
        /// <example>"path/to/foo.png"</example>
        /// Existiert der Pfad nicht, wirft die Methode SendPostRequest eine System.Net.WebExceptions
        /// </summary>
        /// <param name="newPath">Neuer Name bzw. Pfad der Datei</param>
        /// <param name="url">Hostname bzw. IP-Adresse</param>
        /// <param name="userName">Benutzername</param>
        /// <param name="password">Passwort</param>
        public void init(string newPath, string url, string userName, string password)
        {
            this.url = "ftp://" + url + "/" + newPath;

            this.request = WebRequest.Create(this.url) as FtpWebRequest;
            // Upload
            this.request.Method = WebRequestMethods.Ftp.UploadFile;
            // Binärmodus
            this.request.UseBinary = true;
            // Passivmodus
            this.request.UsePassive = true;
            // Logindaten
            this.request.Credentials = new NetworkCredential(userName, password);

        }

        /// <summary>
        /// Lädt die angegebene Datei auf den FTP-Server hoch.
        /// 
        /// Wer der Upload nicht erfolgreich wird eine System.Net.WebException geworfen
        /// </summary>
        /// <param name="path">Der Pfad zur Datei</param>
        public void SendPostRequest(string path)
        {
            byte[] fileContent = this.GetFileContent(path);

            // Request senden
            using (Stream s = this.request.GetRequestStream())
            {
                s.Write(fileContent, 0, fileContent.Length);
                s.Flush();
            }

            // und zuletzt die Antwort/Response lesen
			this.response = (this.request.GetResponse() as FtpWebResponse).StatusDescription +  " " + this.url;
            
            /*using (StreamReader reader = new StreamReader(this.request.GetResponse().GetResponseStream()))
            {
                this.response = reader.ReadToEnd();
            }*/


        }

        /// <summary>
        /// Gibt den Inhalt einer Datei in Form eines byte-Arrays wieder.
        /// </summary>
        /// <param name="file">Dateipfad</param>
        /// <returns>Datei in Form eines byte-Arrays</returns>
        private byte[] GetFileContent(string file)
        {
            byte[] content = null;

            using (FileStream stream = File.OpenRead(file))
            {
                content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
            }

            return content;
        }
    }
}