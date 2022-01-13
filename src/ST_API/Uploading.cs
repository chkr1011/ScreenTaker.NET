using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Screentaker.Uploader;

namespace Screentaker
{
    /// <summary>
    /// Bietet Methoden zum Upload von Images
    /// </summary>
    public class Uploading
    {
        #region Public Methods

        /// <summary>
        /// Lädt eine Datei zu einem Provider hoch und liefert den Ergebnistext zurück
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public string Upload(string Filename, UploadType Provider)
        {
            try
            {
                if ((Provider == UploadType.DirectUpload) || (Provider == UploadType.Imageshack))
                {
                    #region Upload zu Hostingdienst

                    Uploader.UploadFactory _UploadFactory = UploadFactory.GetInstance;
                    Upload _CurrentUpload = _UploadFactory.createUpload(Provider);

                    _CurrentUpload.SendPostRequest(Filename);

                    //Ergebnis zurückliefern
                    string _Result = _CurrentUpload.GetResponse;

                    _UploadFactory = null;
                    _CurrentUpload = null;

                    return _Result;

                    #endregion
                }
                else
                {
                    #region Upload zu FTP-Server

                    string _CurrentFTPServer = STSystem.Settings.UserSettings.GetDataString("FTPServer");
                    string _CurrentFTPDir = STSystem.Settings.UserSettings.GetDataString("FTPDir");
                    string _CurrentFTPPass = STSystem.Settings.UserSettings.GetDataString("FTPPass");
                    string _CurrentFTPUser = STSystem.Settings.UserSettings.GetDataString("FTPUser");

                    string[] fileArray = Filename.Split(new char[] { '\\' });
                    string newFile = fileArray[fileArray.Length - 1];

                    Upload upload = UploadFactory.GetInstance.createUpload(UploadType.FtpUpload);

                    try
                    {
                        upload.init(newFile, _CurrentFTPServer + "/" + _CurrentFTPDir,
                            _CurrentFTPUser, _CurrentFTPPass);

                        upload.SendPostRequest(Filename);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }

                    return upload.GetResponse;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                return "Der Screenshot konnte nicht hochgeladen werden.\r\nMöglicherweise ist keine Internetverbindung aufgebaut.\r\n\r\n" + ex.Message;
            }
        }

        /// <summary>
        /// Lädt ein Image hoch und gibt das Ergebnis formatiert wieder zurück
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="Provider"></param>
        /// <returns></returns>
        public string FormatResult(string UploadResult, Uploader.UploadType Provider, ref string FileLink)
        {
            string _Result = string.Empty;

            try
            {
                if (Provider == UploadType.Imageshack)
                {
                    #region ImageShack

                    #region Daten einlesen

                    byte[] _DataBuffer = UTF8Encoding.UTF8.GetBytes(UploadResult);

                    MemoryStream _ResultBuffer = new MemoryStream(_DataBuffer.Length);
                    _ResultBuffer.Write(_DataBuffer, 0, _DataBuffer.Length);
                    _ResultBuffer.Position = 0;

                    //Einlesen der XML-Datei
                    XmlDocument _XMLResult = new XmlDocument();
                    _XMLResult.Load(_ResultBuffer);
                    _ResultBuffer.Close();
                    _ResultBuffer.Dispose();

                    _ResultBuffer = null;
                    _DataBuffer = null;

                    XmlElement _RootElement = _XMLResult.DocumentElement;

                    #endregion

                    #region Einträge verarbeiten

                    _Result = "\r\n";
                    _Result += "Link:\t\t" + _RootElement["ad_link"].InnerText + "\r\n";
                    _Result += "Screenshot:\t" + _RootElement["image_link"].InnerText + "\r\n";
                    _Result += "Thumbnail:\t" + _RootElement["thumb_link"].InnerText + "\r\n";
                    _Result += "\r\n";
                    _Result += "Forum-URL:\t[URL=" + _RootElement["ad_link"].InnerText + "]Screentaker.NET Screenshot[/URL]\r\n";
                    _Result += "Forum-IMG:\t[IMG]" + _RootElement["image_link"].InnerText + "[/IMG]\r\n";
                    _Result += "\r\n";
                    _Result += "Thumbnail:\t" + _RootElement["thumb_exists"].InnerText + "\r\n";
                    _Result += "Servername:\t" + _RootElement["server"].InnerText + "\r\n";
                    _Result += "Dateiname:\t" + _RootElement["image_name"].InnerText + "\r\n";
                    _Result += "Auflösung:\t" + _RootElement["resolution"].InnerText + " Pixel\r\n";
                    _Result += "Dateigröße:\t" + _RootElement["filesize"].InnerText + " Byte\r\n";


                    FileLink = _RootElement["image_link"].InnerText;
                    #endregion

                    #endregion
                }

                if (Provider == UploadType.DirectUpload)
                {
                    #region DirectUpload

                    //Provider = DirectUpload
                    string _cKeyWordA = "Ihr Bild wurde erfolgreich auf directupload hochgeladen!";
                    string _cKeyWordB = "<a href=\"http://www.globalcounter.net\" target=\"_blank\">GlobalCounter.net";

                    #region Prüfen ob die Daten gültig sind

                    if (UploadResult.IndexOf(_cKeyWordA) == -1)
                    {
                        _Result = "\r\nEs ist ein Fehler aufgetreten. Die Daten konnten nicht ausgewertet werden!";
                        return _Result;
                    }

                    #endregion

                    string _ResultBuffer = UploadResult.Substring(UploadResult.IndexOf(_cKeyWordA) + _cKeyWordA.Length,
                        UploadResult.Length - UploadResult.IndexOf(_cKeyWordA) - _cKeyWordA.Length);

                    _ResultBuffer = _ResultBuffer.Substring(0, _ResultBuffer.IndexOf(_cKeyWordB));

                    //Auswerten der Links
                    int _CurrentStart = 0;
                    int _CurrentLenght = 0;

                    #region Einträge verarbeiten

                    _CurrentStart = _ResultBuffer.IndexOf("<a href=\"") + 9;
                    _CurrentLenght = _ResultBuffer.Substring(_CurrentStart).IndexOf("\" target=\"_blank\">");

                    string _AdLink = _ResultBuffer.Substring(_CurrentStart, _CurrentLenght);

                    _ResultBuffer = _ResultBuffer.Substring(_CurrentStart + _CurrentLenght);
                    _CurrentStart = _ResultBuffer.IndexOf("<img src=\"") + 10;
                    _CurrentLenght = _ResultBuffer.Substring(_CurrentStart).IndexOf("\" border=\"1\">");

                    string _ThumbLink = _ResultBuffer.Substring(_CurrentStart, _CurrentLenght);

                    _ResultBuffer = _ResultBuffer.Substring(_CurrentStart + _CurrentLenght);
                    _CurrentStart = _ResultBuffer.IndexOf("<img src=\"") + 10;
                    _CurrentLenght = _ResultBuffer.Substring(_CurrentStart).IndexOf("\" border=\"1\">");

                    string _ScreenLink = _AdLink.Substring(0, _AdLink.IndexOf("/file/")) + "/images/" + Generators.ShortDate + "/" +
                        _ThumbLink.Substring(_ThumbLink.IndexOf("/temp/") + 6);

                    //Ausgabe des Ergebnisses
                    _Result = "\r\n";
                    _Result += "Link:\t\t" + _AdLink + "\r\n";
                    _Result += "Screenshot:\t" + _ScreenLink + "\r\n";
                    _Result += "Thumbnail:\t" + _ThumbLink + "\r\n";
                    _Result += "\r\n";
                    _Result += "Forum-URL:\t[URL=" + _AdLink + "]Screentaker.NET Screenshot[/URL]\r\n";
                    _Result += "Forum-IMG:\t[IMG]" + _ScreenLink + "[/IMG]";

                    FileLink = _ScreenLink;

                    #endregion

                    #endregion
                }

                if (Provider == UploadType.FtpUpload)
                {
                    #region FTP-Upload

                    if (UploadResult.IndexOf("226") < 0)
                    {
                        _Result = "\r\nDie Datei konnte nicht auf den FTP-Server übertragen werden.\r\n\r\n" +
                            "Möglicher Grund:\r\n" + UploadResult;
                    }
                    else
                    {
                        #region Einträge verarbeiten

                        string _FTPLink = UploadResult.Substring(UploadResult.IndexOf("ftp://"));
                        string _ScreenLink = _FTPLink.Replace("ftp://", "http://");

                        _Result = "\r\n";
                        _Result += "FTP-Link:\t\t" + _FTPLink + "\r\n";
                        _Result += "Screenshot:\t" + _ScreenLink + "\r\n";
                        _Result += "\r\n";
                        _Result += "Forum-URL:\t[URL=" + _ScreenLink + "]Screentaker.NET Screenshot[/URL]\r\n";
                        _Result += "Forum-IMG:\t[IMG]" + _ScreenLink + "[/IMG]";

                        FileLink = _ScreenLink;
                        return _Result;

                        #endregion

                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                _Result = "\r\nWährend des Uploads ist ein Fehler aufgetreten!\r\n\r\n" +
                "Beschreibung: " + ex.Message + "\r\n\r\nMöglicherweise gibt es Probleme durch den Provider. Versuchen Sie es später nocheinmal.";
            }

            return _Result;
        }

        /// <summary>
        /// Führt einen Completten Updateprozess durch
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="Provider"></param>
        /// <param name="FileLink"></param>
        /// <returns></returns>
        public string UploadEx(string Filename, Uploader.UploadType Provider, ref string FileLink)
        {
            string _Buffer = Upload(Filename, Provider);
            return FormatResult(_Buffer, Provider, ref FileLink);
        }

        #endregion
    }
}
