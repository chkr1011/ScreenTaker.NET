namespace Screentaker.Uploader
{
    /// <summary>
    /// Klassen mit Uploadfunktionalität sollten dieses Interface implementieren
    /// </summary>
    public interface Upload
    {

        /// <summary>
        /// Wird aktuell nur vom FTP-Upload benutzt (TODO, unschönes Design).
        /// 
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
        void init(string newPath, string url, string userName, string password);
        /// <summary>
        /// Lädt die übergebene Datei auf den Server hoch
        /// </summary>
        /// <param name="f">Der Pfad zur hochzuladenen Datei</param>
        void SendPostRequest(string path);

        /// <summary>
        /// Gibt die Antwort des Servers zurück.
        /// 
        /// Bei Imageshack bspw handelt es sich um eine Antwort im XML-Format, die wie folgt aussieht:
        /// <code>
        /// <?xml version="1.0" encoding="iso-8859-1"?><links>
        ///     <image_link>http://img513.imageshack.us/img513/9819/testof8.jpg</image_link>
        ///     <thumb_link>http://img513.imageshack.us/img513/9819/testof8.th.jpg</thumb_link>
        ///     <ad_link>http://img513.imageshack.us/my.php?image=testof8.jpg</ad_link>
        ///     <thumb_exists>yes</thumb_exists>
        ///     <total_raters>0</total_raters>
        ///     <ave_rating>0.0</ave_rating>
        ///     <image_location>img513/9819/testof8.jpg</image_location>
        ///     <thumb_location>img513/9819/testof8.th.jpg</thumb_location>
        ///     <server>img513</server>
        ///     <image_name>testof8.jpg</image_name>
        ///     <done_page>http://img513.imageshack.us/content.php?page=done&amp;l=img513/9819/testof8.jpg</done_page>
        ///     <resolution>550x445</resolution>
        ///     <filesize>36395</filesize>
        ///     <image_class>r</image_class>
        /// </links>
        /// </code>
        /// </summary>
        /// <returns>Die Antwort des Servers in Form eines String</returns>
        string GetResponse
        {
            get;
        }
    }
}
