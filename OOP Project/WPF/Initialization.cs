using DAL.State;

namespace WPF
{
	public static class Initialization
    {
        public static bool Start()
        {
            Settings settings;


            //checks if the settings file is created
            if(FileManager.IsSettingCreated())
            {
                //updates the State class
                FileManager.LoadAllSettings();

                settings = new Settings("en", false);

                if (State.DisplayMode != "")
                    return true; //Go on without doing anything
				else //if the settings file has been created by the winform project
				{
					settings = new Settings(State.Language, false);

					settings.LoadCommonSettings();
				}
                
            }
            else
            {
                settings = new Settings("en", false);
            }

            settings.DisableCancel();
			if((bool)settings.ShowDialog()!)
            {
				//Create the file
				return FileManager.CreateSetting();
			}
            return false;
		}
    }
}
