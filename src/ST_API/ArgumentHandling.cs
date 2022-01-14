using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Screentaker
{
    /// <summary>
    /// Liefert alle nötigen Komponenten um Argumente auszuwerten
    /// </summary>
    public class ArgumentHandling
    {
        #region Enums

        /// <summary>
        /// Liste aller Verfügbaren Argumente (Keys)
        /// Diese Werden aber mit - angegeben (-upl)
        /// </summary>
        public enum ArgTypes
        {
            upl, //Upload - ImageShack          
            sfc, //Show Fullscreen
            scc, //Show Currentscreen
            i,    //Tray ausblenden
            g //Grab: cw = CurrentWindow fs = Fullscreen, ss = SelectedScreen, nw = NowWindow
        }

        #endregion

        #region Interne Klassen

        /// <summary>
        /// Klasse die alle Informationen eines Arguments zusammenfasst
        /// </summary>
        public class Argument
        {
            private string _Name = string.Empty;
            private string[] _Values = new string[0];

            /// <summary>
            /// Liefert zurück ob ein bestimmter Parameter gesetzt wurde
            /// </summary>
            /// <param name="SearchValue"></param>
            /// <returns></returns>
            public bool ValueExists(string SearchValue)
            {
                foreach (string _CurrentValue in _Values)
                {
                    if (_CurrentValue.ToLower() == SearchValue.ToLower())
                    {
                        return true;
                    }
                }

                return false;
            }


            /// <summary>
            /// Werte dieses Arguments. Sie werden durch ein Leerzeichen voneinander getrennt
            /// </summary>
            public string[] Values
            {
                set
                {
                    _Values = value;
                }

                get
                {
                    return _Values;
                }
            }

            /// <summary>
            /// Der Name dieses Arguments.. Quasi der Key
            /// </summary>
            public string Name
            {
                get
                {
                    return _Name;
                }

                set
                {
                    if (value.Length < 1)
                    {
                        return;
                    }

                    if (Convert.ToString(value).Substring(0, 1) == "-")
                    {
                        _Name = value.Substring(1);
                    }
                    else
                    {
                        _Name = value;
                    }
                }
            }

            /// <summary>
            /// Liefert das Argument dieses Arguments zurück
            /// </summary>
            public ArgTypes ArgType
            {
                get
                {
                    return (ArgTypes)Enum.Parse(typeof(ArgTypes), _Name);
                }
            }

            /// <summary>
            /// Anzahl der vorhandenen Werte
            /// </summary>
            public int ValueCount
            {
                get
                {
                    return _Values.Length;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Liefert ein Array aus strings zurück die alle Werte für ein Argument enthalten
        /// Dabei ist string[0] der Name des Arguments und alle folgenden sind die Parameter
        /// </summary>
        /// <param name="Argument"></param>
        /// <returns></returns>
        public static Argument[] GetArguments(string[] ArgList)
        {
            ArrayList _ReturnArguments = new ArrayList();
            string _AllValues = string.Empty;

            #region Fehlerprüfungen

            if (ArgList.Length < 2)
            {
                return new Argument[0];
            }

            #endregion

            #region Argumente Zusammenfassen

            for (int _CurrentIndex = 0; _CurrentIndex != ArgList.Length; _CurrentIndex++)
            {
                _AllValues += ArgList[_CurrentIndex] + " ";
            }

            #endregion

            #region Argumente zusammenstellen

            string[] _Buffer = _AllValues.Split('-');

            foreach (string _CurrentArgument in _Buffer)
            {
                if (_CurrentArgument != string.Empty)
                {
                    string[] _CurrentValues = _CurrentArgument.Split(' ');

                    Argument _NewArg = new Argument();
                    _NewArg.Name = _CurrentValues[0];

                    //Setzen der Werte
                    string[] _ValuesBuffer = new string[(_CurrentValues.Length - 2)];
                    for (int _CurrentVIndex = 0; _CurrentVIndex < (_CurrentValues.Length - 2); _CurrentVIndex++)
                    {
                        _ValuesBuffer[_CurrentVIndex] = _CurrentValues[_CurrentVIndex + 1];
                    }
                    _NewArg.Values = _ValuesBuffer;

                    //Neues Argument hinzufügen
                    _ReturnArguments.Add(_NewArg);
                }
            }

            #endregion

            #region Umwandeln der Arrays

            Argument[] _ResultBuffer = new Argument[_ReturnArguments.Count];
            for (int _CurrentIndex = 0; _CurrentIndex < _ReturnArguments.Count; _CurrentIndex++)
            {
                _ResultBuffer[_CurrentIndex] = (Argument)_ReturnArguments[_CurrentIndex];
            }

            #endregion

            return _ResultBuffer;
        }

        #endregion
    }
}
