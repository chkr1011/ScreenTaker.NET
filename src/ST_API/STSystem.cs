using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Net;

using Screentaker.Forms;

namespace Screentaker
{
    /// <summary>
    /// Liefert Systemspezifische Methoden
    /// </summary>
    public static class STSystem
    {
        public const string AppTitle = "Screentaker.NET";
        public const string AppVersion = "1.2.0.86";
        public const string AppVersionAd = "Beta 1";

        public static STSettings _Settings = null;
        private static STForm _Controller = null;

        #region Hotkeys

        public static HotkeyHandling.HOTKEY CurrentHKFull;
        public static HotkeyHandling.HOTKEY CurrentHKCurr;
        public static HotkeyHandling.HOTKEY CurrentHKDef;
        public static HotkeyHandling.HOTKEY CurrentHKUpload;

        #endregion

        #region Enums

        /// <summary>
        /// Stellt alle Möglichkeiten für die Hilfe bereit
        /// </summary>
        public enum HelpRequestIDs
        {
            webupdate,
            editing,
            history,
            qualitywizard,
            uploader,
            Main,
            config,
            Donation
        }

        /// <summary>
        /// Liste aller Fenster die nur in 1 Instanz angezeigt werden dürfen
        /// </summary>
        public enum SingledWindows
        {
            Settings,
            About,
            History,
            Update
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liefert zurück ob der Client zugriff auf das Internet hat.
        /// </summary>
        public static bool IsOnline
        {
            get
            {
                try
                {
                    WebClient _TestClient = new WebClient();
                    _TestClient.DownloadData("http://www.google.de");
                    _TestClient.Dispose();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Controller des ST
        /// </summary>
        public static STForm STController
        {
            get
            {
                return _Controller;
            }

            set
            {
                _Controller = value;
            }
        }

        /// <summary>
        /// Einstellungen rund um den Screentaker
        /// </summary>
        public static STSettings Settings
        {
            get
            { return _Settings; }

            set
            { _Settings = value; }
        }

        /// <summary>
        /// Liefert den Pfad des Cache-Verzeichnisses zurück
        /// </summary>
        public static string CacheDirectory
        {
            get
            {
                string _ResultDirectory = WorkingDirectory + @"Cache\";

                if (!Directory.Exists(_ResultDirectory))
                {
                    Directory.CreateDirectory(_ResultDirectory);
                }

                return _ResultDirectory;
            }
        }

        /// <summary>
        /// Liefert das aktuelle Arbeitsverzeichnis zurück
        /// </summary>
        public static string WorkingDirectory
        {
            get
            {
                FileInfo _Result = new FileInfo(Application.ExecutablePath);
                return _Result.Directory.FullName + @"\";
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Führt alle Vorgänge aus die beim beenden ausgeführt werden müssen
        /// </summary>
        public static void Shutdown()
        {
            _Controller.TrayIcon.Visible = false;

            STSystem.DeleteCache();
            HotkeyHandling.UnregisterAll(_Controller);

            while (Application.OpenForms.Count > 0)
            {
                Application.OpenForms[0].Close();
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// Enorm wichtige Methode die alle Komponenten für den ST initialisiert
        /// </summary>
        public static void Initialize()
        {
            Application.EnableVisualStyles();
            ExceptionHandler.Subscribe();

            _Settings = new STSettings(AppVersion);
            _Settings.Migrate();

            History.Lenght = STSystem.Settings.UserSettings.GetDataInt("HistoryLenght");

            #region Hotkeys auslesen

            CurrentHKFull = HotkeyHandling.Generate(Settings.UserSettings.GetDataString("hotkeycompscreen"));
            CurrentHKCurr = HotkeyHandling.Generate(Settings.UserSettings.GetDataString("hotkeycurrscreen"));
            CurrentHKDef = HotkeyHandling.Generate(Settings.UserSettings.GetDataString("hotkeydefscreen"));
            CurrentHKUpload = HotkeyHandling.Generate(Settings.UserSettings.GetDataString("HotkeyUpload"));

            #endregion
        }

        /// <summary>
        /// Liefert einen Dateinamen für eine neue Datei im Cache zurück
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static string GetCachedFile(string Extension)
        {
            return CacheDirectory + Generators.LongDate + Extension;
        }

        /// <summary>
        /// Liefert einen Dateinamen für eine neue Datei im Cache zurück. *.dat - Datei.
        /// </summary>
        /// <returns></returns>
        public static string GetCachedFile()
        {
            return GetCachedFile(".dat");
        }

        /// <summary>
        /// Löscht das Cacheverzeichnis
        /// </summary>
        public static void DeleteCache()
        {
            try
            {
                if (Directory.Exists(CacheDirectory))
                {
                    Directory.Delete(CacheDirectory, true);
                    Directory.CreateDirectory(CacheDirectory);
                }
            }
            catch { }
        }

        /// <summary>
        /// Liefert zurück ob eine Neuere Version wirklich neuer ist als die aktuelle
        /// </summary>
        /// <param name="Current"></param>
        /// <param name="Newer"></param>
        /// <returns></returns>
        public static bool CheckVersion(string Current, string Newer)
        {
            try
            {
                string[] _NewVersionInf = Newer.Split('.');
                string[] _CurrentVersionInf = Current.Split('.');

                //Fehlerprüfungen
                if (_NewVersionInf.Length != _CurrentVersionInf.Length)
                {
                    return false;
                }

                //Versionen vergleichen
                bool _VersionIsNewer = false;
                for (int _CurrentIndex = 0; _CurrentIndex < Newer.Length; _CurrentIndex++)
                {
                    int _CurrentValue = Convert.ToInt32(_CurrentVersionInf[_CurrentIndex]);
                    int _NewValue = Convert.ToInt32(_NewVersionInf[_CurrentIndex]);

                    if (_NewValue > _CurrentValue)
                    {
                        _VersionIsNewer = true;
                        break;
                    }
                    else if (_NewValue < _CurrentValue)
                    {
                        break;
                    }
                }

                return _VersionIsNewer;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Animiert das angegebene Fenster dem ST Standard entsprechend
        /// Muss im Event FormLoad aufgerufen werden
        /// </summary>
        /// <param name="Target"></param>
        public static void AnimateWindow(Form Target)
        {
            Win32API.User32.AnimateWindow(Target.Handle.ToInt32(), 100, 16);
        }

        /// <summary>
        /// Öffnet die Hilfewebseite und öffnet eine bestimmte
        /// HTML-Datei
        /// </summary>
        /// <param name="AreaId"></param>
        public static void ProcessHelpRequest(HelpRequestIDs ID)
        {
            switch (ID)
            {
                case HelpRequestIDs.Donation:
                    Process.Start("http://czaplewski.name/screentaker/donate.html");
                    break;

                case HelpRequestIDs.Main:
                    Process.Start("http://czaplewski.name/screentaker/");
                    break;

                default:
                    Process.Start("http://czaplewski.name/screentaker/dokumentation/" + Convert.ToString(ID) + ".html");
                    break;
            }
        }

        /// <summary>
        /// Liefert einen Dateinamen zurück, der bisher nicht verwendet wird. Sollte
        /// dabei keine Endung angegeben werden werden alle Endungen berücksichtigt.
        /// Falls eine Datei bereits existiert wird sie aufaddiert. Dabei sind maximal
        /// 999 Dateien möglich!
        /// Falls in den Dateien Lücken zu finden sind wird dennoch die letze Datei verwendet!
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string GetUnusedFilename(string dir, string fileName, string extension)
        {
            //Liste der vorhandenen Dateinamen erstellen
            ArrayList _ExistingFiles = new ArrayList();

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            foreach (FileInfo _CurrentFile in new DirectoryInfo(dir).GetFiles(fileName + "*"))
            {
                _ExistingFiles.Add((extension == string.Empty)
                    ? _CurrentFile.Name.Substring(0, _CurrentFile.Name.Length - 4)
                    : _CurrentFile.Name);
            }

            for (int _CurrentIndex = 0; _CurrentIndex != 999; _CurrentIndex++)
            {
                string _NewFile = fileName + Generators.FillNumber(_CurrentIndex, 999) + extension;

                //Prüfen ob die Datei existiert
                bool _Exists = false;
                foreach (string _CurrentValue in _ExistingFiles)
                {
                    if (_CurrentValue == _NewFile)
                    {
                        _Exists = true;
                    }
                }

                if (!_Exists)
                {
                    return _NewFile;
                }
            }

            return string.Empty;
        }

        #endregion
    }
}
