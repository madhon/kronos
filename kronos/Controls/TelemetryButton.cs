namespace Kronos.Controls;

using System;
using System.ComponentModel;
using System.Windows.Forms;

public class TelemetryButton : Button
{
    [EditorBrowsable]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string EventName { get; set; } = string.Empty;

    [EditorBrowsable]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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