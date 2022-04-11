﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TickTimer
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CurView.Text = "Front Page";

            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);


           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            
            CurView.Text = "Dashboard";
            this.PnlFormLoader.Controls.Clear();

            FrmDashboard FrmDashboard_Vrb = new FrmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;

            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnAnalytics.Height;
            PnlNav.Top = BtnAnalytics.Top;
            PnlNav.Left = BtnAnalytics.Left;
            BtnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnCalendar_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnCalendar.Height;
            PnlNav.Top = BtnCalendar.Top;
            PnlNav.Left = BtnCalendar.Left;
            BtnCalendar.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnContactUs_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnContactUs.Height;
            PnlNav.Top = BtnContactUs.Top;
            PnlNav.Left = BtnContactUs.Left;
            BtnContactUs.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnSettings.Height;
            PnlNav.Top = BtnSettings.Top;
            PnlNav.Left = BtnSettings.Left;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(24,30,54);
        }

        private void BtnAnalytics_Leave(object sender, EventArgs e)
        {
            BtnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnCalendar_Leave(object sender, EventArgs e)
        {
            BtnCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnContactUs_Leave(object sender, EventArgs e)
        {
            BtnContactUs.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Testing button MIN");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Testing button CLOSE");
            Application.Exit();
        }
    }
}
