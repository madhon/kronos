namespace Kronos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Microsoft.AppCenter.Analytics;

    public partial class BaseForm : Form
    {
        private bool _viewLogged = false;
        private DateTime _openTime = DateTime.UtcNow;

        public BaseForm()
        {
            InitializeComponent();
        }

        public void SetDetermineAvailability(Control control, bool associate) => availabilityExtender.SetDetermineAvailability(control, associate);

        [EditorBrowsable] public string AppCenterFormName { get; set; } = string.Empty;

        /// <summary>
        /// Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            _openTime = DateTime.UtcNow;

            base.OnLoad(e);
        }

        /// <summary>
        /// Raises the <see cref="E:Closed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            LogPageView();

            base.OnClosed(e);
        }

        private void LogPageView()
        {
            if (this.DesignMode || _viewLogged)
            {
                return;
            }

            Analytics.TrackEvent("FormUseDuration", new Dictionary<string, string> {
                { "Duration", (DateTime.UtcNow - _openTime).TotalMilliseconds.ToString() }
            });

            _viewLogged = true;
        }

    }
}
