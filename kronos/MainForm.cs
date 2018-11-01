namespace Kronos
{
    using System;
    using System.Windows.Forms;
    using JetBrains.Annotations;

    internal partial class MainForm : Form, IMainFormView
    {
        [UsedImplicitly]
        private readonly MainFormPresenter presenter;
        
        public MainForm()
        {
            InitializeComponent();
            presenter = new MainFormPresenter(this);

            InvokeInitialize(EventArgs.Empty);
        }

        public event EventHandler Initialize;

        public event EventHandler AddActivity = delegate { };

        public string Activity
        {
            get => txtAct.Text;
            set => txtAct.Text = value;
        }

        public string ActivityLog
        {
            get => txtActLog.Text;
            set => txtActLog.Text = value;
        }

        public string Time
        {
            get => lblTime.Text;
            set => lblTime.Text = value;
        }

        public void InvokeInitialize(EventArgs e) => Initialize.RaiseEvent(this, e);

        private void OnAddActivity(object sender, EventArgs e) => AddActivity.RaiseEvent(sender, e);

        private void OnTxtActKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnAddActivity(sender, e);
            }
        }
    }
}