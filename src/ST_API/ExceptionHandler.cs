using System;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Screentaker
{
    /// <summary>
    /// Diese Klasse ist für das Exception-Handling zuständig.
    /// Mit der Methode Subscribe werden die nicht aufgefangenen Exceptionevents abonniert.
    /// 
    /// DAZU MUSS DAS TRACE-FLAG BEIM KOMPILIEREN GESETZT WERDEN
    /// </summary>
    class ExceptionHandler
    {
        #region Contructor

        private ExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ConsoleException);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sollte die Konsole ein Exception werfen (bspw. wenn die Form noch nicht initialisiert wurde)
        /// wird sie von dieser Methode aufgefangen.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">Enthält u.a. ein Exception-Objekt</param>
        private void ConsoleException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = args.ExceptionObject as Exception;
            this.ShowException(e);
        }
        /// <summary>
        /// Sollte die Form eine Exception werfen, wird sie von dieser Methode aufgefangen.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">Enthält u.a. das Exception-Objekt</param>
        private void ThreadException(object sender, ThreadExceptionEventArgs args)
        {
            Exception e = args.Exception;
            this.ShowException(e);
        }
        /// <summary>
        /// Diese Methode schreibt die Exception in ein Errorlog,
        /// zeigt dem Benutzer eine Fehlermeldung an und beendet das Programm.
        /// </summary>
        /// <param name="e"></param>
        private void ShowException(Exception e)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(STSystem.WorkingDirectory + @".\error.log")));

            Trace.Write(STSystem.AppTitle);
            Trace.WriteLine(" (v" + STSystem.AppVersion + ")");
            Trace.WriteLine("\r\n");
            Trace.Indent();
            Trace.WriteLine("Exception: " + e.Message);
            Trace.WriteLine(e.GetType());
            Trace.WriteLine("Stack Trace: " + e.StackTrace);
            Trace.WriteLine("\r\n");
            Trace.WriteLine("Workingdir: " + STSystem.WorkingDirectory);

            Trace.Close();

            MessageBox.Show(
                "Das Programm wurde auf Grund eines fatalen Fehlers beendet!\n" +
                "Bei einem Fehlerbericht fügen Sie bitte die Datei error.log hinzu.",
                "Programm angehalten\r\n\r\nUm die Qualitätsansprüche dieses Programms zu erhalten" +
                "teilen Sie uns bitte diese Daten, sowie eine kurze Fehlerbeschreibung mit. Adressen" +
                "finden Sie im Infofenster dieses Programms.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button1);

            Process.GetCurrentProcess().Kill();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Diese Methode abonniert die nicht aufgefangenen Exceptionevents.
        /// </summary>
        public static void Subscribe()
        {
            new ExceptionHandler();
        }

        #endregion
    }
}