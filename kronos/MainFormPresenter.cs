namespace Kronos
{
    using System;
    using System.Globalization;
    using Kronos.Properties;

    internal class MainFormPresenter : Presenter<IMainFormView>
    {
        private DateTime lastActTime;
        private TimeSpan totalDuration;

        public MainFormPresenter(IMainFormView view) : base(view)
        {
            view.AddActivity += OnAddActivity;
        }

        public void OnAddActivity(object sender, EventArgs e)
        {
            if (this.View.Activity.ToUpperInvariant() == "ARRIVED")
            {
                this.lastActTime = DateTime.Now;
                TimeSpan arrived = this.lastActTime - this.lastActTime;
                this.AddLineToLog(arrived, this.lastActTime, this.lastActTime, "Arrived");
                return;
            }

            DateTime currTime = DateTime.Now;
            TimeSpan activityDuration = currTime - this.lastActTime;
            this.totalDuration += activityDuration;

            this.AddLineToLog(activityDuration, this.lastActTime, currTime, this.View.Activity);

            if (!this.View.Activity.EndsWith("**", StringComparison.OrdinalIgnoreCase))
            {
                this.UpdateTotalDuration();
            }

            this.lastActTime = currTime;

            this.View.Activity = string.Empty;
        }

        protected override void OnViewLoad(object sender, EventArgs e)
        {
            this.View.Time = string.Empty;
            this.lastActTime = DateTime.Now;
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            string durationSring = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, duration.Hours, duration.Minutes);
            string message = string.Format(CultureInfo.CurrentCulture, Resources.ActLogF, durationSring, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            this.View.ActivityLog += message;
        }

        private void UpdateTotalDuration()
        {
            this.View.Time = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, this.totalDuration.Hours, this.totalDuration.Minutes);
        }
    }
}