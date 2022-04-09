namespace TickTimer
{
    partial class FrmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessName = new System.Windows.Forms.Label();
            this.ProcessTimer = new System.Windows.Forms.Label();
            this.BtnStartTimer = new System.Windows.Forms.Button();
            this.BtnStopTimer = new System.Windows.Forms.Button();
            this.BtnRemoveProcess = new System.Windows.Forms.Button();
            this.BtnAddProcess = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefreshList = new System.Windows.Forms.Button();
            this.ProcessCheckList = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessName
            // 
            this.ProcessName.AutoSize = true;
            this.ProcessName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ProcessName.Location = new System.Drawing.Point(41, 88);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(92, 13);
            this.ProcessName.TabIndex = 0;
            this.ProcessName.Text = "PROCESS NAME";
            // 
            // ProcessTimer
            // 
            this.ProcessTimer.AutoSize = true;
            this.ProcessTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ProcessTimer.Location = new System.Drawing.Point(41, 113);
            this.ProcessTimer.Name = "ProcessTimer";
            this.ProcessTimer.Size = new System.Drawing.Size(95, 13);
            this.ProcessTimer.TabIndex = 0;
            this.ProcessTimer.Text = "PROCESS TIMER";
            // 
            // BtnStartTimer
            // 
            this.BtnStartTimer.Location = new System.Drawing.Point(12, 24);
            this.BtnStartTimer.Name = "BtnStartTimer";
            this.BtnStartTimer.Size = new System.Drawing.Size(75, 34);
            this.BtnStartTimer.TabIndex = 1;
            this.BtnStartTimer.Text = "START TIMER";
            this.BtnStartTimer.UseVisualStyleBackColor = true;
            this.BtnStartTimer.Click += new System.EventHandler(this.BtnStartTimer_Click);
            // 
            // BtnStopTimer
            // 
            this.BtnStopTimer.Location = new System.Drawing.Point(93, 24);
            this.BtnStopTimer.Name = "BtnStopTimer";
            this.BtnStopTimer.Size = new System.Drawing.Size(75, 34);
            this.BtnStopTimer.TabIndex = 1;
            this.BtnStopTimer.Text = "STOP TIMER";
            this.BtnStopTimer.UseVisualStyleBackColor = true;
            this.BtnStopTimer.Click += new System.EventHandler(this.BtnStopTimer_Click);
            // 
            // BtnRemoveProcess
            // 
            this.BtnRemoveProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRemoveProcess.Location = new System.Drawing.Point(0, 23);
            this.BtnRemoveProcess.Name = "BtnRemoveProcess";
            this.BtnRemoveProcess.Size = new System.Drawing.Size(220, 23);
            this.BtnRemoveProcess.TabIndex = 3;
            this.BtnRemoveProcess.Text = "Remove Process ";
            this.BtnRemoveProcess.UseVisualStyleBackColor = true;
            // 
            // BtnAddProcess
            // 
            this.BtnAddProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAddProcess.Location = new System.Drawing.Point(0, 0);
            this.BtnAddProcess.Name = "BtnAddProcess";
            this.BtnAddProcess.Size = new System.Drawing.Size(220, 23);
            this.BtnAddProcess.TabIndex = 3;
            this.BtnAddProcess.Text = "Add Process(es)";
            this.BtnAddProcess.UseVisualStyleBackColor = true;
            this.BtnAddProcess.Click += new System.EventHandler(this.BtnAddProcess_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProcessCheckList);
            this.panel1.Controls.Add(this.BtnRefreshList);
            this.panel1.Controls.Add(this.BtnRemoveProcess);
            this.panel1.Controls.Add(this.BtnAddProcess);
            this.panel1.Location = new System.Drawing.Point(509, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 480);
            this.panel1.TabIndex = 4;
            // 
            // BtnRefreshList
            // 
            this.BtnRefreshList.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRefreshList.Location = new System.Drawing.Point(0, 46);
            this.BtnRefreshList.Name = "BtnRefreshList";
            this.BtnRefreshList.Size = new System.Drawing.Size(220, 23);
            this.BtnRefreshList.TabIndex = 3;
            this.BtnRefreshList.Text = "Refresh List";
            this.BtnRefreshList.UseVisualStyleBackColor = true;
            this.BtnRefreshList.Click += new System.EventHandler(this.BtnRefreshList_Click);
            // 
            // ProcessCheckList
            // 
            this.ProcessCheckList.CheckOnClick = true;
            this.ProcessCheckList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProcessCheckList.FormattingEnabled = true;
            this.ProcessCheckList.Location = new System.Drawing.Point(0, 131);
            this.ProcessCheckList.Name = "ProcessCheckList";
            this.ProcessCheckList.Size = new System.Drawing.Size(220, 349);
            this.ProcessCheckList.Sorted = true;
            this.ProcessCheckList.TabIndex = 4;
            this.ProcessCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ProcessCheckList_ItemCheck);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(730, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnStopTimer);
            this.Controls.Add(this.BtnStartTimer);
            this.Controls.Add(this.ProcessTimer);
            this.Controls.Add(this.ProcessName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProcessName;
        private System.Windows.Forms.Label ProcessTimer;
        private System.Windows.Forms.Button BtnStartTimer;
        private System.Windows.Forms.Button BtnStopTimer;
        private System.Windows.Forms.Button BtnRemoveProcess;
        private System.Windows.Forms.Button BtnAddProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnRefreshList;
        private System.Windows.Forms.CheckedListBox ProcessCheckList;
    }
}