namespace Kronos
{
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private DateTime lastActTime;
        private TimeSpan totalDuration;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = string.Empty;
            lastActTime = DateTime.Now;
        }

        private void OnAddActivity(object sender, EventArgs e)
        {
            if (txtAct.Text.ToUpper() == "ARRIVED")
            {
                lastActTime = DateTime.Now;
                TimeSpan arrived = lastActTime - lastActTime;
                AddLineToLog(arrived, lastActTime, lastActTime, "Arrived");
                return;
            }

            DateTime currTime = DateTime.Now;
            TimeSpan activityDuration = currTime - lastActTime;
            totalDuration += activityDuration;

            AddLineToLog(activityDuration, lastActTime, currTime, txtAct.Text);

            if (!txtAct.Text.EndsWith("**"))
            {
                UpdateTotalDuration();
            }

            lastActTime = currTime;

            txtAct.Text = string.Empty;
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            string durationSring = string.Format("{0} h {1} min", duration.Hours, duration.Minutes);
            string message = string.Format("{0}\t\t({1} - {2})\t{3}{4}", durationSring, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            txtActLog.Text += message;
        }

        private void UpdateTotalDuration()
        {
            lblTime.Text = string.Format("{0} h {1} min", totalDuration.Hours, totalDuration.Minutes);
        }

        private void OnTxtActKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnAddActivity(sender, e);
            }
        }
    }
}
