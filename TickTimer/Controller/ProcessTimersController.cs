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

        //THIS ALSO NEEDS A DAO CONNECTION! That way when I kill a timer, it can autosave. 
        //Actually, it SHOULD autosave, say... every five seconds? Maybe user-defined?

        //A list of ProcessTimers that trackes the currently tracked processes defined by the user.
        public List<ProcessTimer> ProcessTimers = new List<ProcessTimer>();
        public List<string> TrackedProcesses = new List<string>();
        private static ProcessTimersController INSTANCE = null;
        private string CurrentActiveProcess = "";
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
            //Need to make sure we account for every possibility.
            //So if the user switches from one tracked process to another, we need to kill the old timer, and start the new one.
            //And if the user switches from an untracked process to a tracked one, we need to start the new timer.
            //If the user switches from a tracked process to an inactive one, we need to kill the old timer.
            if (IsTrackedProcess(NewActiveProcess))
            {
                //Okay, this now starts the timer, but how do we ensure it keeps track of which timers have been started? Otherwise stopping the timers is gonna be paain
                //Right now, if a timer is started, and then another process is clicked, there's no way of knowing if an active timer _should_ be stopped.
                //So save the current activity as a "placeholder process"
                StartTimer(NewActiveProcess);
            }
        }

        //Lets the controller know whether or not a process is currently tracked or not.
        private Boolean IsTrackedProcess(string ProcessName)
        {
            foreach(ProcessTimer PT in ProcessTimers)
            {
                if (PT.GetProcessName().Equals(ProcessName)) { return true; }
            }
            return false;
        }

        public Boolean PlaceHolderIsTrackedProcess(string CheckedProcess)
        {
            if (this.TrackedProcesses.Contains(CheckedProcess)) { return true; }

            return false;
        }

        //Adds a process to the list of actively tracked processes
        private void AddProcess(string ProcessName)
        {
            if (TrackedProcesses.Contains(ProcessName))
            {
                throw new Exception("This process has already been added to the list!");
            }

            ProcessTimers.Add(new ProcessTimer(ProcessName));
            TrackedProcesses.Add(ProcessName);
            Console.WriteLine("Process : " + ProcessName + " added!");
        }

        //Adds processes to the list of actively tracked processes.
        public void AddProcesses(List<string> Processes)
        {
            foreach(string s in Processes)
            {
                AddProcess(s);
            }
        }

        //Removes a process from the list of actively tracked processes.
        private void RemoveProcess(string ProcessName)
        {
            foreach (ProcessTimer pt in ProcessTimers)
            {
                if (pt.Equals(ProcessName))
                {
                    ProcessTimers.Remove(pt);
                    TrackedProcesses.Remove(ProcessName);
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

        public List<string> AllTrackedProcesses()
        {
            return this.TrackedProcesses;
        }

        //Placeholder asynchronous method. Might not be necessary
        public async Task ProcessActive(string ProcessName)
        {
            await Task.Run(() => StartTimer(ProcessName));
        }

        //Placeholder asynchronous method. Might not be necessary
        public async Task ProcessInactive(string ProcessName)
        {
            await Task.Run(() => KillTimer(ProcessName));
        }
    }
}
