using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTimer.Model
{
    class ProcessTimer
    {
        private DateTime startTime, endTime;

        private Boolean clockRunning;
        private int processClock;
        private readonly string processName;
        public ProcessTimer(string processName)
        {
            this.processName = processName;
            this.processClock = 0;
            this.clockRunning = false;
        }

        public void ProcessTimerStart()
        {
            startTime = DateTime.Now;
            clockRunning = true;
        }

        public void ProcessTimerStop()
        {
            if (!clockRunning)
            {
                Console.WriteLine("Can't stop a timer when one isn't running!");
                this.processClock = 0;
            }
            endTime = DateTime.Now;
            clockRunning = false;
            SaveTimer();                  
        }

        private void SaveTimer()
        {
            this.processClock += (int)((endTime - startTime)).TotalSeconds;
            Console.WriteLine("For the process: "+processName+": "+processClock);
        }
        
        public string GetProcessName()
        {
            return this.processName;
        }

        public int GetProcessTime()
        {
            return this.processClock;
        }

        public string GetProcessInfo()
        {
            return "Process name: " + this.processName + "\nProcess runtime: " + this.processClock;
        }
    }
}
