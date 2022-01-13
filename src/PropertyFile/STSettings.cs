using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Threading;

namespace Screentaker
{
    public class STSettings
    {
        #region Internals

        private PropertyFile _UserSettings = null;
        private PropertyFile _SystemSettings = null;
        private string _MigrationVersion = string.Empty;

        #endregion

        public delegate void UpdateInformationReceivedDelegate(PropertyFile Data);
        public event UpdateInformationReceivedDelegate UpdateInformationReceived;
        
        #region Constructor
            
        /// <summary>
        /// Initialisiert beide Einstellungsdateien. Dabei werden diese neu angelegt falls sie nicht
        /// existieren, oder eingelesen falls Sie existieren und mirgriert falls sie veraltet sind.
        /// </summary>
        /// <param name="NewMigrationVersion"></param>
        public STSettings(string NewMigrationVersion)
        {
            _MigrationVersion = NewMigrationVersion;

            #region Systemeinstellungen einlesen

            _SystemSettings = new PropertyFile("Screentaker.ini", false);

            if (File.Exists("Screentaker.ini") == false)
            { CreateDefaultSystemSettings(); }
            else
            { _SystemSettings.RefreshContentFromFile(); }

            #endregion

            #region Benutzereinstellungen einlesen

            string _UserprofilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
                @"\Screentaker.NET.ini";

            //Falls das Programm portable genutzt wird die entsprechende Configuratio neu einlesen
            if (_SystemSettings.GetDataBool("UseNoUserprofiles"))
            {
                _UserprofilePath = "PortableConfig.ini";
            }

            _UserSettings = new PropertyFile(_UserprofilePath, false);

            if (File.Exists(_UserprofilePath) == false)
            { CreateDefaultUserSettings(); }
            else
            { _UserSettings.RefreshContentFromFile(); }

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// MigrationVersion der Benutzereinstellungen und Systemeinstellungen
        /// </summary>
        public string MigrationVersion
        {
            get
            { return _MigrationVersion; }

            set
            { _MigrationVersion = value; }
        }

        /// <summary>
        /// Bietet Zugriff auf Benutzerbezogene Einstellungen
        /// </summary>
        public PropertyFile UserSettings
        {
            get
            { return _UserSettings; }

            set
            { _UserSettings = value; }
        }

        /// <summary>
        /// Bietet Zugriff auf NICHT Benutzerbezogene Einstellungen
        /// </summary>
        public PropertyFile SystemSettings
        {
            get
            { return _SystemSettings; }

            set
            { _SystemSettings = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Diese Methode Migriert FALLS NÖTIG alle Einstellungen. Daher IMMER beim Programmstart aufrufen
        /// </summary>
        public void Migrate()
        {
            string _SystemConfigVersion = _SystemSettings.HeaderMigrationVersion;
            string _UserConfigVersion = _UserSettings.HeaderMigrationVersion;

            #region Systemeinstellungen migrieren falls nötig

            if (_SystemConfigVersion != _MigrationVersion)
            {
                //Einstellungen migrieren
                NamedValue[] _OldValues = _SystemSettings.GetAllValues(PropertyFile.DefaultDataBlock);
                CreateDefaultSystemSettings();

                foreach(NamedValue _CurrentValue in _OldValues)
                {
                    if (_SystemSettings.DataValueExists(_CurrentValue.Name))
                    {
                        _SystemSettings.SetDataValue(_CurrentValue.Name, _CurrentValue.Value);
                    }
                }

                _SystemSettings.SaveContent();
            }
            

            #endregion

            #region Benutzereinstellungen falls nötig migrieren

            if (_UserConfigVersion != _MigrationVersion)
            {
                //Einstellungen migrieren
                NamedValue[] _OldValues = _UserSettings.GetAllValues(PropertyFile.DefaultDataBlock);
                CreateDefaultUserSettings();

                foreach (NamedValue _CurrentValue in _OldValues)
                {
                    if (_UserSettings.DataValueExists(_CurrentValue.Name))
                    {
                        _UserSettings.SetDataValue(_CurrentValue.Name, _CurrentValue.Value);
                    }
                }

                _UserSettings.SaveContent();
            }

            #endregion
        }

        #region Updateinformationen beziehen

        /// <summary>
        /// Liefert den Inhalt einer Extended-INI-File zurück die Informationen über ein
        /// mögliches Update enthält. Sobald die Daten verfügbar sind wird dies über das 
        /// Event UpdateInformationreceived mitgeteilt.
        /// </summary>
        /// <returns></returns>
        public void RequestUpdateInformation()
        {
            try
            {
                Thread _DataDownloader = new Thread(new ThreadStart(DownloadData));
                _DataDownloader.Priority = ThreadPriority.Normal;
                _DataDownloader.Start();
            }
            catch
            {
               //Bisher nichts
            }
        }

        private void DownloadData()
        {
            WebClient _InformationDownloader = new WebClient();
            Uri _TargetUri = new Uri(_SystemSettings.GetDataString("WebExchangeURL"));

            _InformationDownloader.DownloadDataCompleted += new DownloadDataCompletedEventHandler(_InformationDownloader_DownloadDataCompleted);
            _InformationDownloader.DownloadDataAsync(_TargetUri);
        }

        /// <summary>
        /// Der Download wurde fertiggestellt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _InformationDownloader_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                if (UpdateInformationReceived != null)
                {
                    byte[] _ResultData = e.Result;
                    MemoryStream _BufferStream = new MemoryStream(_ResultData.Length);

                    //Daten in einen MemoryStream schreiben. Nachdem die Daten geschrieben
                    //wurden muss die Position wieder auf 0 gesetzt werden, da das 
                    //XMLDocument an der entsprechenden Position beginnt zu lesen!!
                    _BufferStream.Write(_ResultData, 0, _ResultData.Length);
                    _BufferStream.Position = 0;

                    PropertyFile _UpdateInformation = new PropertyFile(string.Empty, false);
                    _UpdateInformation.RefreshContent(_BufferStream);
                    _BufferStream.Close();

                    ISynchronizeInvoke _ReceivedIvoke = UpdateInformationReceived.Target as ISynchronizeInvoke;
                    _ReceivedIvoke.Invoke(UpdateInformationReceived, new object[1] { _UpdateInformation });

                    ((WebClient)sender).Dispose();
                }
            }
            catch (Exception ex)
            {
                //BUG!
                
            }
        }

        #endregion

        /// <summary>
        /// Erstellt für diese Version spezifische neue Systemeinstellungen
        /// </summary>
        public void CreateDefaultSystemSettings()
        {
            _SystemSettings.Clear();

            _SystemSettings.HeaderMigrationVersion = _MigrationVersion;
            _SystemSettings.HeaderName = "Screentaker.NET_SystemConfig";
            _SystemSettings.HeaderVersion = PropertyFile.DefaultHeaderVersion;
            _SystemSettings.HeaderReadOnly = false;
            
            _SystemSettings.AddDataValue("UseNoUserprofiles", false);
            _SystemSettings.AddDataValue("WebExchangeURL", "http://doneltomato.do.funpic.de/WebExchange.ini");
            
            //_SystemSettings.AddDataValue("WebExchangeURL", "http://czaplewski.name/screentaker/webexchange.ini");

            _SystemSettings.SaveContent();
        }

        /// <summary>
        /// Erstellt für diese Version spezifische Benutzereinstellungen
        /// </summary>
        public void CreateDefaultUserSettings()
        {
            _UserSettings.Clear();

            _UserSettings.HeaderMigrationVersion = _MigrationVersion;
            _UserSettings.HeaderName = "Screentaker.NET_UserConfig";
            _UserSettings.HeaderVersion = PropertyFile.DefaultHeaderVersion;
            _UserSettings.HeaderReadOnly = false;

            _UserSettings.SetDataValue("ExternalToolName", "Microsoft Paint (Konfigurierbar!)");
            _UserSettings.SetDataValue("ExternalToolFile", "mspaint.exe");
            _UserSettings.SetDataValue("HistoryLenght", 10);
            _UserSettings.SetDataValue("HistoryEnabled", true);
            _UserSettings.SetDataValue("HomeDir", "Screenshots");
            _UserSettings.SetDataValue("CloseOnAction", true);
            _UserSettings.SetDataValue("AutoUpdate", true);
            _UserSettings.SetDataValue("HotkeyCompScreen", "PrintScreen;False;False;False");
            _UserSettings.SetDataValue("HotkeyCurrScreen", "PrintScreen;True;False;False");
            _UserSettings.SetDataValue("HotkeyDefScreen", "PrintScreen;False;False;True");
            _UserSettings.SetDataValue("AlwaysOpenMaximized", true);
            _UserSettings.SetDataValue("CloseOnURLLink", false);
            _UserSettings.SetDataValue("HistoryTakeEdited", true);
            _UserSettings.SetDataValue("HistoryTakeSized", true);
            _UserSettings.SetDataValue("AutoShowScreen", true);
            _UserSettings.SetDataValue("AutoNumerate", true);
            _UserSettings.SetDataValue("DefaultFilename", "Screenshot_");
            _UserSettings.SetDataValue("AutoSaveScreen", false);
            _UserSettings.SetDataValue("AutoCompressFiletype", "PNG");
            _UserSettings.SetDataValue("QualityAutocompress", 100);
            _UserSettings.SetDataValue("NoLoadAfterEdit", false);
            _UserSettings.SetDataValue("UploadFormat", "PNG");
            _UserSettings.SetDataValue("UseTraymenuIcons", true);
            _UserSettings.SetDataValue("HotkeyUpload", "U;True;True;False");
            _UserSettings.SetDataValue("HotkeyUploadProvider", "ImageShack.us");
            _UserSettings.SetDataValue("ShowSize", false);
            _UserSettings.SetDataValue("AutoCopyToClipboard", false);
            _UserSettings.SetDataValue("FTPServer", string.Empty);
            _UserSettings.SetDataValue("FTPUser", string.Empty);
            _UserSettings.SetDataValue("FTPDir", string.Empty);
            _UserSettings.SetDataValue("FTPPass", string.Empty);

            _UserSettings.SaveContent();
        }

        #endregion

    }
}
