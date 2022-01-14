using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Screentaker
{
    /// <summary>
    /// Bietet Zugriff auf Extended-INI-Dateien die im ST verwendet werden
    /// </summary>
    public class PropertyFile : IDisposable
    {
        public const string DefaultDataBlock = "Properties";
        public const string DefaultHeaderVersion = "1.0";
        
        #region Internals

        private string _Filename = string.Empty;
        private List<NamedValue> _InternalValues = new List<NamedValue>();

        #endregion

        #region Properties

        /// <summary>
        /// Der Name dieses Wertekontainers
        /// </summary>
        public string HeaderName
        {
            get
            { return GetString("Header", "Name"); }

            set
            { AddValue("Header", "Name", value); }
        }

        /// <summary>
        /// Liefert zurück ob Werte geändert wurden. Die Datei wird nur Physikalisch
        /// geschrieben wenn auch Werte verändert wurden.
        /// </summary>
        public bool ContentModified
        {
            get
            {
                foreach (NamedValue _CurrentValue in _InternalValues)
                {
                    if (_CurrentValue.Modified)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Definiert ob diese Datei für lesende und schreibende Zugriffe freigegeben ist
        /// </summary>
        public bool HeaderReadOnly
        {
            get
            { return GetBool("Header", "ReadOnly"); }

            set
            { SetValue("Header", "ReadOnly", value); }
        }

        /// <summary>
        /// Definiert die HeaderVersion dieser Datei. Diese ist nötig um später ältere (inkompatible)
        /// Versionen dieser Datei zu identifizieren
        /// </summary>
        public string HeaderVersion
        {
            get
            { return GetString("Header", "Version"); }

            set
            { SetValue("Header", "Version", value); }
        }

        /// <summary>
        /// Migrationsversion dieser Datei
        /// </summary>
        public string HeaderMigrationVersion
        {
            get
            { return GetString("Header", "MigrationVersion"); }

            set
            { SetValue("Header", "MigrationVersion", value); }
        }
        
        #endregion

        #region Contructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="NowRefresh"></param>
        public PropertyFile(string Filename, bool NowRefresh)
        {
            _Filename = Filename;

            if (NowRefresh)
            {
                RefreshContentFromFile();
            }

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Entfernt alle Werte aus der Datei
        /// </summary>
        public void Clear()
        {
            _InternalValues.Clear();
        }

        /// <summary>
        /// List alle Werte neu ein
        /// </summary>
        /// <param name="Source"></param>
        public void RefreshContent(Stream Source)
        {
            if (Source == null)
            {
                return;
            }

            using (StreamReader _INIReader = new StreamReader(Source))
            {
                _InternalValues.Clear();

                string _CurrentDataLine = string.Empty;
                string _CurrentBlock = string.Empty;

                while (_INIReader.EndOfStream == false)
                {
                    _CurrentDataLine = _INIReader.ReadLine();

                    //Ungültige Zeile
                    if ((_CurrentDataLine == string.Empty) || (_CurrentDataLine.Substring(0, 1) == "#"))
                    {
                        continue;
                    }

                    //Kopfzeile
                    if (_CurrentDataLine.Substring(0, 1) == "[")
                    {
                        _CurrentBlock = _CurrentDataLine.Substring(1, _CurrentDataLine.IndexOf("]") - 1);
                        continue;
                    }

                    NamedValue _NewValue = new NamedValue();
                    _NewValue.Read(_CurrentDataLine, _CurrentBlock);
                    _InternalValues.Add(_NewValue);
                }


                _INIReader.Close();
            }
        }

        /// <summary>
        /// Aktualisert den Inhalt der Datei an Hand des angegebenen Dateinamens
        /// </summary>
        public void RefreshContentFromFile()
        {
            if(File.Exists(_Filename) == false)
            {
                return;
            }

            FileStream _SourceStream = new FileStream(_Filename, FileMode.Open, FileAccess.Read);
            RefreshContent(_SourceStream);
        }

        /// <summary>
        /// Speichert diese Einstellungen in einer bestimmten Datei
        /// </summary>
        public void SaveContent()
        {
            //Kontent nur speichern wenn Änderungen vorliegen
            if (ContentModified == false)
            {
                return;
            }

            using (StreamWriter _INIWriter = new StreamWriter(_Filename, false))
            {

                foreach (string _CurrentBlock in GetAllBlocks())
                {
                    _INIWriter.Write("[" + _CurrentBlock + "]\r\n");

                    foreach (NamedValue _CurrentValue in GetAllValues(_CurrentBlock))
                    {
                        _INIWriter.Write(_CurrentValue.Write() + "\r\n");
                    }

                    _INIWriter.Write("\r\n");
                }

                _INIWriter.Close();
            }
        }

        /// <summary>
        /// Liefert alle vorhandenen Blöcke
        /// </summary>
        /// <returns></returns>
        public string[] GetAllBlocks()
        {
            List<string> _ResultBuffer = new List<string>();

            foreach (NamedValue _CurrentValue in _InternalValues)
            {
                bool _ValueExists = false;
                foreach (string _CurrentBufferBlock in _ResultBuffer)
                {
                    if (_CurrentBufferBlock.ToUpper() == _CurrentValue.Block.ToUpper())
                    {
                        _ValueExists = true;
                        break;
                    }
                }

                if (_ValueExists == false)
                {
                    _ResultBuffer.Add(_CurrentValue.Block);
                }
            }

            return _ResultBuffer.ToArray();
        }

        /// <summary>
        /// Liefert alle Werte die Innerhalb eines Block sind
        /// </summary>
        /// <param name="FromBlock"></param>
        /// <returns></returns>
        public NamedValue[] GetAllValues(string FromBlock)
        {
            List<NamedValue> _ResultBuffer = new List<NamedValue>();

            foreach (NamedValue _CurrentValue in _InternalValues)
            {
                if (_CurrentValue.Block.ToUpper() == FromBlock.ToUpper())
                {
                    _ResultBuffer.Add(_CurrentValue);
                }
            }

            return _ResultBuffer.ToArray();
        }

        /// <summary>
        /// Speichert einen bestimmten Wert in der Datei
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <param name="Value"></param>
        public void SetValue(string Block, string ValueName, object Value)
        {
            foreach (NamedValue _CurrentValue in _InternalValues)
            {
                if (_CurrentValue.Block.ToUpper() == Block.ToUpper())
                {
                    if (_CurrentValue.Name.ToUpper() == ValueName.ToUpper())
                    {
                        //Nur den Wert ändern falls er wirklich anders ist
                        if (_CurrentValue.Value != Value)
                        {
                            _CurrentValue.Value = Value;
                        }

                        return;
                    }
                }
            }

            //Wert neu anlegen
            NamedValue _NewValue = new NamedValue();
            _NewValue.Block = Block;
            _NewValue.Name = ValueName;
            _NewValue.Value = Value;

            _InternalValues.Add(_NewValue);
        }

        /// <summary>
        /// Setzt einen Wert im Standard-Settings Bereich
        /// </summary>
        /// <param name="ValueName"></param>
        /// <param name="NewValue"></param>
        public void SetDataValue(string ValueName, object NewValue)
        {
            SetValue(DefaultDataBlock, ValueName, NewValue);
        }

        /// <summary>
        /// Fügt der Datei eine neue Einstellung hinzu
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <param name="Value"></param>
        public void AddValue(string Block, string ValueName, object Value)
        {
            SetValue(Block, ValueName, Value);
        }

        /// <summary>
        /// Fügt einen neuen Wert im Datenbereich der Datei hinzu
        /// </summary>
        /// <param name="ValueName"></param>
        /// <param name="NewValue"></param>
        public void AddDataValue(string ValueName, object NewValue)
        {
            AddValue(DefaultDataBlock, ValueName, NewValue);
        }

        /// <summary>
        /// Liefert einen bestimmten Wert aus einem Block zurück
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public object GetValue(string Block, string ValueName)
        {
            foreach (NamedValue _CurrentValue in _InternalValues)
            {
                if (_CurrentValue.Block.ToUpper() == Block.ToUpper())
                {
                    if (_CurrentValue.Name.ToUpper() == ValueName.ToUpper())
                    {
                        return _CurrentValue.Value;
                    }
                }
            }

            //Eintrag nicht gefunden
            return null;
        }

        /// <summary>
        /// Liefert zurück ob in einem bestimmten Block ein bestimmter Wert existiert
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public bool ValueExists(string Block, string ValueName)
        {
            if (GetValue(Block, ValueName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Liefert zurück ob ein bestimmter Wert im Bereich der Einstellungen vorliegend ist
        /// </summary>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public bool DataValueExists(string ValueName)
        {
            return ValueExists(DefaultDataBlock, ValueName);
        }

        /// <summary>
        /// Liefert einen bestimmten Wert als String zurück
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public string GetString(string Block, string ValueName)
        {
            string _ResultBuffer = Convert.ToString(GetValue(Block, ValueName));
            return NamedValue.DeFormatStringValue(_ResultBuffer);
        }

        /// <summary>
        /// Liefert einen bestimmten Wert als Int zurück
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public int GetInt(string Block, string ValueName)
        {
            return Convert.ToInt32(GetValue(Block, ValueName));
        }

        /// <summary>
        /// Liefert einen bestimmten Wert bei den Properties als Int zurück
        /// </summary>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public int GetDataInt(string ValueName)
        {
            return GetInt(DefaultDataBlock, ValueName);
        }

        /// <summary>
        /// Liefert den Wert einer bestimmten Property als String zurück
        /// </summary>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public string GetDataString(string ValueName)
        {
            return GetString(DefaultDataBlock, ValueName);
        }

        /// <summary>
        /// Liefert einen bestimmten Wert als Boolean zurück
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public bool GetBool(string Block, string ValueName)
        {
            return Convert.ToBoolean(GetValue(Block, ValueName));
        }

        /// <summary>
        /// Liefert einen Wert aus dem Datenbereich als Boolean zurück
        /// </summary>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public bool GetDataBool(string ValueName)
        {
            return GetBool(DefaultDataBlock, ValueName);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Verwendeten Resourcen freigeben
        /// </summary>
        public void Dispose()
        {
            _InternalValues.Clear();
            _InternalValues = null;

            _Filename = null;
        }

        #endregion
    }
}
