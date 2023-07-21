using DAL.State;
using UI;

namespace UI_Windows_Forms
{
    public class Initialization
    {
        public static bool CheckSettings()
        {
            if (!FileManager.IsSettingCreated())
            {  
                return CreateSettings(false);
            }
            else
            {
                FileManager.LoadAllSettings();
                if (State.FavPlayers[0] == "")
                    return CreateSettings(true);
            }
            return true;
        }

        private static bool CreateSettings(bool isLoaded)
        {
            bool continueCreation;

            if (!isLoaded)
            {
                //Language and championship
                
                SettingsForm settingsForm = new SettingsForm();
                //Initial settings need to be given
                settingsForm.DisableCancel();

                if (settingsForm.ShowDialog() == DialogResult.Cancel)
                {
                    return false;
                }
                //Fifa code and the 3 favorite players
                continueCreation = GetTeam(true, false);
            }
            else

            {
                continueCreation = GetTeam(false, false);
            }


            
            if(!continueCreation)
            {
                return false;
            }

            //Create the file
            if(!FileManager.CreateSetting())
            {
                MessageBox.Show("Error");
                return false;
            }
            return true;
        }

        public static bool GetTeam(bool firstTime, bool change)
        {
            TeamChooserForm teamChooserForm = new TeamChooserForm(firstTime||change);
            teamChooserForm.DisableCancel();

            if (teamChooserForm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public static bool ChangeChampionship()
        {
            bool continueUpdate = GetTeam(false, true);

            //Create the file
            if (continueUpdate && !FileManager.CreateSetting())
            {
                MessageBox.Show("Error");
            }
            return continueUpdate;
        }
    }
}
