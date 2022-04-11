using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TickTimer.Controller
{
    class ProcessMonitor
    {
        private static ProcessMonitor INSTANCE = null;
        private List<string> RunningPrograms = new List<string>();
        private ProcessTimersController PTC = ProcessTimersController.GetInstance();
        private Process[] ProcessList;
        private string CurrentProcess = "";


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public string ActiveWindow()
        {
            this.ProcessList = Process.GetProcesses();

            IntPtr ActiveWindowHandle = GetForegroundWindow();

            foreach (Process process in ProcessList)
            {
                if (process.MainWindowHandle.Equals(ActiveWindowHandle))
                {
                    //IF THE ACTIVE WINDOW HAS CHANGED!
                    if (ActiveWindowChanged(process.ProcessName)) 
                    {
                        Console.WriteLine("THE ACTIVE WINDOW HAS CHANGED!");
                        PTC.ActiveWindowChanged(process.ProcessName);
                    } 
                    return process.ProcessName;
                }
            }
            return "No active window";
        }

        private Boolean ActiveWindowChanged(string CheckProcess)
        {
            if (this.CurrentProcess.Equals(CheckProcess)) return false;

            this.CurrentProcess = CheckProcess;
            return true;
        }

        public string ActiveProcess()
        {
            return this.CurrentProcess;
        }

        private ProcessMonitor() {
            FetchProcesses();
        }

        public void FetchProcesses()
        {
            this.ProcessList = Process.GetProcesses();
            this.RunningPrograms.Clear();

            foreach (Process p in ProcessList)
            {
                if (!RunningPrograms.Contains(p.ProcessName))
                {
                    RunningPrograms.Add(p.ProcessName);
                }
                
            }
        }

        public string[] ProcessStrings()
        {
            return this.RunningPrograms.ToArray();
        }

        public void PrintProcesses()
        {
            foreach(string s in RunningPrograms)
            {
                Console.WriteLine(s);
            }
        }

        public static ProcessMonitor GetInstance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new ProcessMonitor();
            }
            return INSTANCE;
        }
    }
}
