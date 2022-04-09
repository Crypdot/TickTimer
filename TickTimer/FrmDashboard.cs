using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TickTimer.Model;
using TickTimer.Controller;


//THIS COULD BE USEFUL! COULD MAKE A MESSAGE THROWING BOX THINGY CONTROLLER! MessageBox.Show("WOW!");

namespace TickTimer
{
    public partial class FrmDashboard : Form
    {
        private ProcessTimer TestProcess = new ProcessTimer("Test Process");
        private ProcessMonitor pm = ProcessMonitor.GetInstance();        
        private List<string> CurrentSelections = new List<string>();
        private int MAX_THREADS = 5;
        public FrmDashboard()
        {
            InitializeComponent();
            UpdateList();
        }
        public void ChangeMaxThreads(int NewVal)
        {
            this.MAX_THREADS = NewVal;
        }

        private void UpdateList()
        {
            Task.Run(() => pm.FetchProcesses()).Wait();
            pm.PrintProcesses();

            ProcessCheckList.BeginUpdate();
            ProcessCheckList.Items.Clear();
            ProcessCheckList.Items.AddRange(pm.ProcessStrings());
            ProcessCheckList.EndUpdate();
        }

        private void BtnStartTimer_Click(object sender, EventArgs e)
        {

            PTC.AddProcesses(CurrentSelections);

        }

        private void BtnStopTimer_Click(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += Tmr_Tick;
            tmr.Start();

            /*
            TestProcess.ProcessTimerStop();
            ProcessTimer.Text = TestProcess.GetProcessTime().ToString();
            */
        }

        //THIS NEEDS TO BE MOVED INTO ITS OWN CLASS. MAYBE HANDLED BY PROCESSMONITOR? OR DIRECTLY IN THE TIMERS CONTROLLER
        private void Tmr_Tick(object sender, EventArgs e)
        {
            string title = pm.ActiveWindow();

            Console.WriteLine("THE TITLE OF THE CURRENTLY RUNNING APPLICATION IS THIS ===> " + title);
            
        }

        private void BtnRefreshList_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ProcessCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox temp = (CheckedListBox)sender;

            if(temp == null) { return; }

            if(temp.CheckedItems.Count >= MAX_THREADS) { e.NewValue = CheckState.Unchecked; }

        }

        private void CurrentThings()
        {
            Console.WriteLine("These are the current selections that you added -> ");
            foreach(string s in CurrentSelections)
            {
                Console.WriteLine(s);
            }
        }

        private void BtnAddProcess_Click(object sender, EventArgs e)
        {
            foreach (string s in ProcessCheckList.CheckedItems)
            {
                if (!CurrentSelections.Contains(s))
                {
                    CurrentSelections.Add(s);
                }
            }
            CurrentThings();
        }
    }
}
