namespace Kronos
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ProvideProperty("DetermineAvailability", typeof(Control))]
    public class AvailabilityExtender : Component, IExtenderProvider
    {
        //private readonly Hashtable _oConfigurationTable;

        private readonly Dictionary<Control, bool> _oConfigurationTable;

        public AvailabilityState StateOfExtender { get; private set; }

        public AvailabilityExtender() => _oConfigurationTable = new Dictionary<Control, bool>();

        public bool CanExtend(object extendee)
        {
            var flag = extendee is Control;
            return ((!(extendee is Form) && !(extendee is Panel)) && flag);
        }

        [DefaultValue(false)]
        public bool GetDetermineAvailability(Control control)
        {
            if (_oConfigurationTable[control] is object)
            {
                return false;
            }

            return (bool)_oConfigurationTable[control];
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
                Control current = (Control)iter.Current;
                if (current is IAvailability)
                    ((IAvailability)current).SetState(availability);
                else
                {
                    switch (availability)
                    {
                        case AvailabilityState.Unavailable:
                            {
                                current.BackColor = SystemColors.Control;
                                current.ForeColor = SystemColors.Control;
                                current.Enabled = false;
                                continue;
                            }
                        case AvailabilityState.Available:
                            {
                                current.BackColor = SystemColors.Window;
                                current.ForeColor = SystemColors.ControlText;
                                current.Enabled = true;
                                continue;
                            }
                        case AvailabilityState.Disabled:
                        case AvailabilityState.ReadOnly:
                            {
                                current.BackColor = SystemColors.Window;
                                current.Enabled = false;
                                continue;
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
            else if (_oConfigurationTable.ContainsKey(oControl))
            {
                _oConfigurationTable.Remove(oControl);
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
                Control current = (Control)iter.Current;
                current.Visible = visible;
            }
        }
    }
}
