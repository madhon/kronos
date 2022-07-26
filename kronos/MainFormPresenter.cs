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

        public void OnAddActivity(object? sender, EventArgs e)
        {
            if (sender == null) throw new ArgumentNullException(nameof(sender));

            if (View.Activity.Equals("ARRIVED", StringComparison.OrdinalIgnoreCase))
            {
                lastActTime = DateTime.UtcNow;
                var arrived = TimeSpan.FromSeconds(0);
                AddLineToLog(arrived, lastActTime, lastActTime, "Arrived");
                return;
            }

            var currentTime = DateTime.UtcNow;
            var activityDuration = currentTime - lastActTime;
            totalDuration += activityDuration;

            AddLineToLog(activityDuration, lastActTime, currentTime, View.Activity);

            if (!View.Activity.EndsWith("**", StringComparison.Ordinal))
            {
                UpdateTotalDuration();
            }

            lastActTime = currentTime;

            View.Activity = string.Empty;
        }

        protected override void OnViewLoad(object? sender, EventArgs e)
        {
            View.Time = string.Empty;
            lastActTime = DateTime.Now;
        }

        private void AddLineToLog(TimeSpan duration, DateTime startTime, DateTime endTime, string activity)
        {
            var durationString = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, duration.Hours.ToString(), duration.Minutes.ToString());
            var message = string.Format(CultureInfo.CurrentCulture, Resources.ActLogF, durationString, startTime.ToShortTimeString(), endTime.ToShortTimeString(), activity, Environment.NewLine);
            View.ActivityLog += message;
        }

        private void UpdateTotalDuration() => View.Time = string.Format(CultureInfo.CurrentCulture, Resources.DurationF, totalDuration.Hours.ToString(), totalDuration.Minutes.ToString());
    }
}