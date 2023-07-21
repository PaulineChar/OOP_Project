using System.Dynamic;

namespace DAL.State
{
    public class FileManager
    {
        private const string SETTINGS_PATH = "../../../../settings.txt";

        //Checks wether the settings file exists
        public static bool IsSettingCreated()
        {
            return File.Exists(SETTINGS_PATH);
        }

        //creates the settings file
        //@param:
        //returns true if the file has been successfully created
        public static bool CreateSetting()
        {
            List<string> settings = new() { State.Language, State.Championship, State.FifaCode};
            foreach(string player in State.FavPlayers)
            {
                settings.Add(player);
            }
            settings.Add(State.DisplayMode);
            settings.Add(State.IsLocal);
            using (StreamWriter s = File.CreateText(SETTINGS_PATH))
            {
                if (s != null)
                {
                    for (int i = 0; i < settings.Count - 1; i++)
                    {
                        s.Write($"{settings[i]};");
                    }
                    s.WriteLine($"{settings[settings.Count - 1]}");
                }

                else
                {
                    return false;
                }
            }

            return true;
        }

        //Reads the settings file and updates the State class
        public static void LoadAllSettings()
        {
            if (!File.Exists(SETTINGS_PATH))
            {
                return;
            }
            string[] settings = File.ReadAllLines(SETTINGS_PATH);
            if (settings == null || settings.Length == 0)
            {
                return;
            }

            var temp = settings[0].Split(';').ToList();
            State.Language = temp[0];
            State.Championship = temp[1];
            State.FifaCode = temp[2];
            State.FavPlayers = new string[3] { temp[3], temp[4], temp[5] };
            State.DisplayMode = temp[6];
            State.IsLocal = temp[7];
        }

        /*
         * 0 if nothing changed
         * 1 if language changed
         * 2 if championship changed (and maybe also language)
         * 3 if error
         */
        public static int ChangeSettings(string language, string championship)
        {
            int result = 0;
            
            if (State.Language != language)
            {
                result = 1;
            }

            if (State.Championship != championship)
            {
                result = 2;
            }

            if (result != 0 && !CreateSetting())
            {
                result = 4;
            }

            return result;
        }
    }
}