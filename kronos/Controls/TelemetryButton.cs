namespace Kronos.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class TelemetryButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable]
        public string EventName { get; set; } = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable]
        public bool IsTimed { get; set; }

        protected override void OnClick(EventArgs e)
        {
            var startTime = DateTime.UtcNow;
            base.OnClick(e);

            if (IsTimed)
            {
                var duration = (DateTime.UtcNow - startTime).TotalMilliseconds;
            }
        }
    }
}