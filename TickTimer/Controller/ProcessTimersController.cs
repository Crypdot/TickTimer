using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TickTimer.Model;

namespace TickTimer.Controller
{
    class ProcessTimersController
    {
        public List<ProcessTimer> ProcessTimers = new List<ProcessTimer>();
        public List<string> AddedProcesses = new List<string>();
        private static ProcessTimersController INSTANCE = null;
        private string CurrentActiveProcess;
        private ProcessTimersController() {}

        public static ProcessTimersController GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ProcessTimersController();
            }
            return INSTANCE;
        }

        public void ActiveWindowChanged(string NewActiveProcess)
        {
            this.CurrentActiveProcess = NewActiveProcess;

            if (IsTrackedProcess(NewActiveProcess))
            {
                //Okay, this now starts the timer, but how do we ensure it keeps track of which timers have been started? Otherwise stopping the timers is gonna be paain
                //Right now, if a timer is started, and then another process is clicked, there's no way of knowing if an active timer _should_ be stopped.
                StartTimer(NewActiveProcess);
            }
        }

        private Boolean IsTrackedProcess(string ProcessName)
        {
            foreach(ProcessTimer PT in ProcessTimers)
            {
                if (PT.GetProcessName().Equals(ProcessName)) { return true; }
            }
            return false;
        }


        private void AddProcess(string ProcessName)
        {
            if (AddedProcesses.Contains(ProcessName))
            {
                throw new Exception("This process has already been added to the list!");
            }

            ProcessTimers.Add(new ProcessTimer(ProcessName));
            AddedProcesses.Add(ProcessName);
            Console.WriteLine("Process : " + ProcessName + " added!");
        }

        public void AddProcesses(List<string> Processes)
        {
            foreach(string s in Processes)
            {
                AddProcess(s);
            }
        }

        private void RemoveProcess(string ProcessName)
        {
            foreach (ProcessTimer pt in ProcessTimers)
            {
                if (pt.Equals(ProcessName))
                {
                    ProcessTimers.Remove(pt);
                    AddedProcesses.Remove(ProcessName);
                    return;
                }
            }
            Console.WriteLine("Couldn't find the process named: " + ProcessName);
        }

        public void RemoveProcesses(List<string> Processes)
        {
            foreach(string s in Processes)
            {
                RemoveProcess(s);
            }
        }

        private void StartTimer(string ProcessName)
        {
            try
            {
                ProcessTimer temp = ProcessTimers.Find(e => e.GetProcessName() == ProcessName);
                temp.ProcessTimerStart();
                Console.WriteLine("Process timer started successfully.");
            }
            catch
            {
                Console.WriteLine("Couldn't find the process: " + ProcessName);
            }
        }
        private void KillTimer(string ProcessName)
        {
            try
            {
                ProcessTimer temp = ProcessTimers.Find(e => e.GetProcessName() == ProcessName);
                temp.ProcessTimerStop();
                Console.WriteLine("Process timer stopped successfully.");
            }
            catch
            {
                Console.WriteLine("Couldn't find the process: " + ProcessName);
            }
        }

        public List<string> TrackedProcesses()
        {
            return this.AddedProcesses;
        }

        public async Task ProcessActive(string ProcessName)
        {
            await Task.Run(() => StartTimer(ProcessName));
        }

        public async Task ProcessInactive(string ProcessName)
        {
            await Task.Run(() => KillTimer(ProcessName));
        }
    }
}
