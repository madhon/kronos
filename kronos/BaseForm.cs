namespace Kronos
{
    using System.Windows.Forms;

    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public void SetDetermineAvailability(Control control, bool associate) => availabilityExtender.SetDetermineAvailability(control, associate);
    }
}
