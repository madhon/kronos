using System;
using System.Windows.Forms;

namespace Kronos
{
    public partial class MainForm : Form
    {
        private DateTime LastActTime;
        private TimeSpan totalDuration;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = "";
            LastActTime = DateTime.Now;
        }

        private void OnAddActivity(object sender, EventArgs e)
        {
            if (txtAct.Text.ToUpper() == "ARRIVED")
            {
                LastActTime = DateTime.Now;
                TimeSpan arrived = LastActTime - LastActTime;
                AddLineToLog(arrived, LastActTime, LastActTime, "Arrived");
                return;
            }

            DateTime currTime = DateTime.Now;
            TimeSpan activityDuration = currTime - LastActTime;
            totalDuration += activityDuration;

            AddLineToLog(activityDuration, LastActTime, currTime, txtAct.Text);

            if (!txtAct.Text.EndsWith("**"))
                UpdateTotalDuration();
                        
            LastActTime = currTime;

            txtAct.Text = "";
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            string durationSring = String.Format("{0} h {1} min", duration.Hours, duration.Minutes);
            string message = String.Format("{0}\t\t({1} - {2})\t{3}{4}", durationSring, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            txtActLog.Text += message;
        }

        private void UpdateTotalDuration()
        {
            lblTime.Text = String.Format("{0} h {1} min", totalDuration.Hours, totalDuration.Minutes);
        }

        private void txtAct_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
                OnAddActivity(sender, e);
        }

    }
}
