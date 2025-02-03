namespace Kronos;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

[ProvideProperty("DetermineAvailability", typeof(Control))]
public sealed class AvailabilityExtender : Component, IExtenderProvider
{
    private readonly Dictionary<Control, bool> _oConfigurationTable = new();

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public AvailabilityState StateOfExtender { get; private set; }

    public AvailabilityExtender() { }

    public bool CanExtend(object extendee)
    {
        if (extendee is Form || extendee is Panel)
        {
            return false;
        }
        return extendee is Control;
    }

    [DefaultValue(false)]
    public bool GetDetermineAvailability(Control control)
    {
        if (!_oConfigurationTable.TryGetValue(control, out bool value))
        {
            return false;
        }
        return value;
    }

    public void IndicateAvailable()
    {
        SetAvailability(AvailabilityState.Available);
        StateOfExtender = AvailabilityState.Available;
    }

    public static void IndicateAvailable(ICollection collection) => SetAvailability(collection.GetEnumerator(), AvailabilityState.Available);

    public void IndicateDisabled()
    {
        SetAvailability(AvailabilityState.Disabled);
        StateOfExtender = AvailabilityState.Disabled;
    }

    public static void IndicateDisabled(ICollection collection) => SetAvailability(collection.GetEnumerator(), AvailabilityState.Disabled);

    public void IndicateInvisible() => SetVisibility(false);

    public void IndicateReadOnly()
    {
        SetAvailability(AvailabilityState.ReadOnly);
        StateOfExtender = AvailabilityState.ReadOnly;
    }

    public static void IndicateReadOnly(ICollection collection) => SetAvailability(collection.GetEnumerator(), AvailabilityState.ReadOnly);

    public void IndicateUnavailable()
    {
        SetAvailability(AvailabilityState.Unavailable);
        StateOfExtender = AvailabilityState.Unavailable;
    }

    public static void IndicateUnavailable(ICollection collection) => SetAvailability(collection.GetEnumerator(), AvailabilityState.Unavailable);

    public void IndicateVisible() => SetVisibility(true);

    private void SetAvailability(AvailabilityState availability) => SetAvailability(_oConfigurationTable.Keys.GetEnumerator(), availability);

    private static void SetAvailability(IEnumerator iter, AvailabilityState availability)
    {
        while (iter.MoveNext())
        {
            var current = (Control)iter.Current!;
            if (current is IAvailability)
            {
                ((IAvailability)current).SetState(availability);
            }
            else
            {
                switch (availability)
                {
                    case AvailabilityState.Unavailable:
                    {
                        current.BackColor = SystemColors.Control;
                        current.ForeColor = SystemColors.Control;
                        current.Enabled = false;
                        break;
                    }
                    case AvailabilityState.Available:
                    {
                        current.BackColor = SystemColors.Window;
                        current.ForeColor = SystemColors.ControlText;
                        current.Enabled = true;
                        break;
                    }
                    case AvailabilityState.Disabled:
                    case AvailabilityState.ReadOnly:
                    {
                        current.BackColor = SystemColors.Window;
                        current.Enabled = false;
                        break;
                    }
                }
            }
        }
    }

    public void SetDetermineAvailability(Control oControl, bool value)
    {
        if (value)
        {
            _oConfigurationTable[oControl] = true;
        }
        else
        {
            if (_oConfigurationTable.ContainsKey(oControl))
            {
                _oConfigurationTable.Remove(oControl);
            }
        }
    }

    private void SetVisibility(bool visible)
    {
        SetVisibility(_oConfigurationTable.Keys.GetEnumerator(), visible);
    }

    private static void SetVisibility(IEnumerator iter, bool visible)
    {
        while (iter.MoveNext())
        {
            var current = (Control)iter.Current!;
            current.Visible = visible;
        }
    }
}