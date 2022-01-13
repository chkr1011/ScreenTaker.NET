using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

using Screentaker.Forms;

namespace Screentaker
{
    static class ScreenTaker
    {
        /// <summary>
        /// Liefert zur�ck ob das aktuelle Programm bereits ausgef�hrt wird
        /// </summary>
        /// <returns>returns true if already running</returns>
        public static bool IsRunning
        {
            get
            {
                Process[] _ALLProcesses = Process.GetProcesses();
                int _RunningCount = 0;

                foreach (Process _CurrentProcess in _ALLProcesses)
                {
                    string _Fullname = Assembly.GetExecutingAssembly().FullName;
                    string _AssemblyName = _Fullname.Substring(0, _Fullname.IndexOf(","));

                    if (_CurrentProcess.ProcessName == _AssemblyName)
                    {
                        _RunningCount++;
                    }
                }

                if (_RunningCount > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [STAThread]
        static void Main()
        {
            if (! IsRunning)
            {
                using (STForm _ScreentakerForm = new STForm())
                {
                    STSystem.Initialize();

                    STSystem.STController = _ScreentakerForm;
                    Application.Run(_ScreentakerForm);

                    STSystem.Shutdown();
                }
            }
        }
    }
}