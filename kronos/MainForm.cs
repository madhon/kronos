namespace Kronos
{
    using System;
    using System.Windows.Forms;

    internal partial class MainForm : Form, IMainFormView
    {
        private readonly MainFormPresenter presenter;
        
        public MainForm()
        {
            InitializeComponent();
            presenter = new MainFormPresenter(this);
        }

        public string Activity
        {
            get { return txtAct.Text; }
            set { txtAct.Text = value; }
        }

        public string ActivityLog
        {
            get { return txtActLog.Text; }
            set { txtActLog.Text = value; }
        }

        public string Time
        {
            get { return lblTime.Text; }
            set { lblTime.Text = value; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            presenter.OnLoad();
        }

        private void OnAddActivity(object sender, EventArgs e)
        {
            presenter.OnAddActivity();
        }
        
        private void OnTxtActKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnAddActivity(sender, e);
            }
        }
    }
}