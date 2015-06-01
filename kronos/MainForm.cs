namespace Kronos
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;
    using Kronos.Properties;

    internal partial class MainForm : Form
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
            if (txtAct.Text.ToUpperInvariant() == "ARRIVED")
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

            if (!txtAct.Text.EndsWith("**", StringComparison.OrdinalIgnoreCase))
            {
                UpdateTotalDuration();
            }

            lastActTime = currTime;

            txtAct.Text = string.Empty;
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            string durationSring = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, duration.Hours, duration.Minutes);
            string message = string.Format(CultureInfo.CurrentCulture, Resources.ActLogF, durationSring, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            txtActLog.Text += message;
        }

        private void UpdateTotalDuration()
        {
            lblTime.Text = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, totalDuration.Hours, totalDuration.Minutes);
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
