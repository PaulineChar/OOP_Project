using DAL.State;
using System.Globalization;
using UI_Windows_Forms;

namespace UI
{
    public partial class SettingsForm : Form
    {
        private bool CanCancel = true;
        string language;
        bool canClose;
        public List<string> previousSettings;
        public SettingsForm()
        {
            previousSettings = new List<string>();
            if (FileManager.IsSettingCreated())
            {
                language = State.Language;
            }
            else
            {
                language = "en";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            canClose = false;
            InitializeComponent();
        }

        public void PushSettings()
        {
            previousSettings.Add(State.Language);
            previousSettings.Add(State.Championship);
            previousSettings.Add(State.IsLocal);
            State.Language = rbtnEnglish.Checked ? "en" : "fr";
            State.Championship = rbtnMen.Checked ? "men" : "women";
            State.IsLocal = checkBoxIsLocal.Checked ? "1" : "0";
        }

        //Disables the cancel option.
        //Used for the settings creation during the first opening of the application.
        public void DisableCancel()
        {
            CanCancel = false;
            btnCancel.Enabled = false;
            ControlBox = false;
        }

        //Listens to the key press
        //"Enter" key is like pressing the "Confirm" button
        //"Escape" key is like pressing the "Cancel" button
        private void SettingsForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                CloseForm closeForm = new CloseForm(language, true);
                if (closeForm.ShowDialog() == DialogResult.OK)
                {
                    canClose = true;
                    //PushSettings();
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (CanCancel)
                {
                    PushSettings();
                    DialogResult = DialogResult.Cancel;

                }
                else
                {
                    MessageBox.Show("Initial settings need to be given", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateWithCurrentSettings()
        {
            if (State.Championship == null || State.Language == null)
            {
                MessageBox.Show("There was an error with you settings. Did you modify them from outside the application?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Checking the correct buttons
            else if (State.Language == "fr")
            {
                rbtnFrench.Checked = true;
            }


            if (State.Championship == "women")
                rbtnWomen.Checked = true;

            if (State.IsLocal == "1")
                checkBoxIsLocal.Checked = true;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm closeForm;
            if (canClose)
            {
                PushSettings();
                return;
            }
            closeForm = new CloseForm(language);

            if (closeForm.ShowDialog() == DialogResult.Cancel)
                e.Cancel = true;
            else
            {
                DialogResult = DialogResult.Cancel;
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CloseForm closeForm = new CloseForm(language, true);
            if (closeForm.ShowDialog() == DialogResult.OK)
            {
                canClose = true;
                //PushSettings();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
