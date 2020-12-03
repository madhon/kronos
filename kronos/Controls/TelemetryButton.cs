namespace Kronos.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Microsoft.AppCenter.Analytics;

    public class TelemetryButton : Button
    {
        [EditorBrowsable] public string EventName { get; set; } = string.Empty;

        [EditorBrowsable] public bool IsTimed { get; set; }

        protected override void OnClick(EventArgs e)
        {
            var startTime = DateTime.UtcNow;
            base.OnClick(e);

            if (IsTimed)
            {
                Analytics.TrackEvent(EventName, new Dictionary<string, string>
                {
                    {"Duration", (DateTime.UtcNow - startTime).TotalMilliseconds.ToString()}
                });
            }
        }
    }
}