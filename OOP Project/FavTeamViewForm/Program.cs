using DAL;
using UI;
using UI_Windows_Forms;

namespace FavTeamViewForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Checks if the settings file has to be created: initialization.
            if(Initialization.CheckSettings())
                Application.Run(new RankingForm());
            
        }
    }
}