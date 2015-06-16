namespace Kronos
{
    using System;
    using System.Globalization;
    using Kronos.Properties;

    internal class MainFormPresenter
    {
        private readonly IMainFormView view;

        private DateTime lastActTime;
        private TimeSpan totalDuration;

        public MainFormPresenter(IMainFormView view)
        {
            this.view = view;
        }

        public void OnLoad()
        {
            this.view.Time = string.Empty;
            this.lastActTime = DateTime.Now;
        }

        public void OnAddActivity()
        {
            if (this.view.Activity.ToUpperInvariant() == "ARRIVED")
            {
                this.lastActTime = DateTime.Now;
                TimeSpan arrived = this.lastActTime - this.lastActTime;
                this.AddLineToLog(arrived, this.lastActTime, this.lastActTime, "Arrived");
                return;
            }

            DateTime currTime = DateTime.Now;
            TimeSpan activityDuration = currTime - this.lastActTime;
            this.totalDuration += activityDuration;

            this.AddLineToLog(activityDuration, this.lastActTime, currTime, this.view.Activity);

            if (!this.view.Activity.EndsWith("**", StringComparison.OrdinalIgnoreCase))
            {
                this.UpdateTotalDuration();
            }

            this.lastActTime = currTime;

            this.view.Activity = string.Empty;
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            string durationSring = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, duration.Hours, duration.Minutes);
            string message = string.Format(CultureInfo.CurrentCulture, Resources.ActLogF, durationSring, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            this.view.ActivityLog += message;
        }

        private void UpdateTotalDuration()
        {
            this.view.Time = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, this.totalDuration.Hours, this.totalDuration.Minutes);
        }
    }
}