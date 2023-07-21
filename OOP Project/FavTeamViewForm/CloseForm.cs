using System.Globalization;

namespace UI_Windows_Forms
{
    public partial class CloseForm : Form
    {
        public CloseForm(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();
        }

        public CloseForm(string language, bool settingsChange) : this(language)
        {
            lbMess.Text = Properties.Resources.ConfirmSettings;
        }

        private void CloseForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {

                DialogResult = DialogResult.Cancel;

            }
        }
    }
}
