using DAL;
using DAL.Models;
using DAL.State;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private bool isSubmitted;
        private bool canCancel;
        private static Country[] MenTeams = null;
        private static Country[] WomenTeams = null;
        private static List<string> settingsChoices = new() { "en", "men", "0", "0", "0" };
        private bool ignoreEvent;
		public Settings(string language, bool canCancel)
        {
			InitializeComponent();
			UpdateSettingsChoices();
			StartAll(language);
			isSubmitted = false;
            LoadCountries(settingsChoices[1]);
            
            ignoreEvent = false;
            this.canCancel = canCancel;
            if(!canCancel)
                btnCancel.IsEnabled = false;
		}

        private void UpdateSettingsChoices()
		{
			if(State.Language != "")
            {
                settingsChoices[0] = State.Language;
                settingsChoices[1] = State.Championship;
                settingsChoices[4] = State.IsLocal;
            }
            if(State.DisplayMode != "")
            {
                for(int i = 0; i < cbDisplayModes.Items.Count; i++)
                {
                    if (cbDisplayModes.Items[i].ToString().Contains(State.DisplayMode))
                    {
                        settingsChoices[3] = i.ToString();
                        i = cbDisplayModes.Items.Count;
                        ignoreEvent = true;
                        cbDisplayModes.SelectedIndex = i;
                        ignoreEvent = false;
                    }
                }
            }
            else
            {
                ignoreEvent = true;
                settingsChoices[3] = "0";
                ignoreEvent = false;
            }

		}

		private void StartAll(string language)
        {
			Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
			
            ChangeNames();
			ReloadInfo();
		}


		#region Language
		//Event handlers
		private void rbtnEnglish_Click(object sender, RoutedEventArgs e)
        {
            rbtnEnglish.IsChecked = true;
            rbtnFrench.IsChecked = false;
            ChangeLanguage("en");
        }

        private void rbtnFrench_Click(object sender, RoutedEventArgs e)
        {
            rbtnEnglish.IsChecked = false;
            rbtnFrench.IsChecked = true;
            ChangeLanguage("fr");
        }

        //Change language
        private void ChangeLanguage(string language)
        {
            ignoreEvent = true;
            RememberInfo();
            StartAll(language);
            ignoreEvent = false;
            //ReloadInfo();
        }

		private void RememberInfo()
		{
            settingsChoices[0] = (bool)rbtnEnglish.IsChecked! ? "en" : "fr";
            settingsChoices[1] = (bool)rbtnMen.IsChecked! ? "men" : "women";
            settingsChoices[2] = cbCountries.SelectedIndex.ToString();
            settingsChoices[3] = cbDisplayModes.SelectedIndex.ToString();
            settingsChoices[4] = (bool)checkBoxIsLocal.IsChecked! ? "1" : "0";
		}

        //For the app to be responsive,
        //selected values have to be reselected after initializing the components again
		private void ReloadInfo()
		{
            if (settingsChoices[0] == "fr")
            {
                rbtnFrench.IsChecked = true;
                rbtnEnglish.IsChecked = false;
            }
            if (settingsChoices[1] == "women")
            {
                rbtnWomen.IsChecked = true;
                rbtnMen.IsChecked = false;
            }
            if (settingsChoices[4] == "1")
                checkBoxIsLocal.IsChecked = true;

            cbCountries.SelectedIndex = int.Parse(settingsChoices[2]);
            cbDisplayModes.SelectedIndex = int.Parse(settingsChoices[3]);
		}

        private void ChangeNames()
        {
            this.Title = Properties.Resources.Settings;
            gbLanguage.Header = Properties.Resources.Language;
            gbChampionship.Header = Properties.Resources.Championship;
            rbtnMen.Content = Properties.Resources.Men;
            rbtnWomen.Content = Properties.Resources.Women;
            gbDisplayMode.Header = Properties.Resources.DispMode;
            gbFavTeam.Header = Properties.Resources.FavTeam;
            cbDisplayModes.Items[0] = Properties.Resources.Fullscreen;
            gbLocal.Header = Properties.Resources.Local;
            checkBoxIsLocal.Content = Properties.Resources.Yes;
            btnCancel.Content = Properties.Resources.Cancel;
            btnConfirm.Content = Properties.Resources.Confirm;
        }

		#endregion


		#region Championship
		//Envent handlers
		private void rbtnWomen_Click(object sender, RoutedEventArgs e)
        {
            rbtnWomen.IsChecked = true;
            rbtnMen.IsChecked = false;
            cbCountries.Items.Clear();
            settingsChoices[1] = "women";
            LoadCountries("women");
        }

        private void rbtnMen_Click(object sender, RoutedEventArgs e)
        {
            rbtnWomen.IsChecked = false;
            rbtnMen.IsChecked = true;
            cbCountries.Items.Clear();
            settingsChoices[1] = "men";
            LoadCountries("men");  
        }

		//Fetch data
		private async void LoadCountries(string championship)
		{
            Country[] countriesData;

			//LoadingUC loadingUC = ShowLoading();

			if (MenTeams != null && championship == "men")
                countriesData = MenTeams;
            else if(championship == "women" && WomenTeams != null)
                countriesData = WomenTeams;
            else
            {
                try
                {
                    if (settingsChoices[4] == "0")
                        countriesData = await RequestController.GetCountriesData(championship);
                    else
                        countriesData = RequestController.GetJsonCountries(championship);
                }
                catch
                {
                    MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    countriesData = null!;
                    return;
                }

                if(countriesData == null)
                {
                    MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
				
                Array.Sort(countriesData, (c1,c2) => string.Compare(c1.Name,c2.Name));
				if (championship == "men" && MenTeams == null)
                { 
                    MenTeams = countriesData;
                }
                else
                {
                    WomenTeams = countriesData;
				}
			}

            cbCountries.SelectedIndex = 0;

            for (int i = 0; i < countriesData.Length; i++)
			{
                //Select the favorite team
                if (settingsChoices[1] == championship && countriesData[i].FifaCode == State.FifaCode)
                {
                    cbCountries.SelectedIndex = i;
                    settingsChoices[2] = i.ToString();
                }
                cbCountries.Items.Add($"{countriesData[i].Name} ({countriesData[i].FifaCode})");
			}

			//StopLoading(loadingUC);
		}

		#endregion


		#region Event handlers
		//Listens to key presses
		private void settingsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
				isSubmitted = true;

                string message;
                if (State.Language == "fr")
                    message = "Etes-vous sûrs ?";
                else
                    message = "Are you sure?";

                Confirmation confirmation = new Confirmation(message, State.Language);

                if ((bool)confirmation.ShowDialog()!)
                    DialogResult = true;
            }
            else if(e.Key == Key.Escape)
            {
                if(canCancel)
                    DialogResult = false;
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
			DialogResult = false;
		}

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            isSubmitted = true;
            string message;
            if (State.Language == "fr")
                message = "Etes-vous sûrs ?";
            else
                message = "Are you sure?";

            Confirmation confirmation = new Confirmation(message, State.Language);

            if ((bool)confirmation.ShowDialog()!)
                DialogResult = true;
            
        }

		private void settingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (isSubmitted)
            {
                PushSettings();
                return;
            }

			string message;
			if (settingsChoices[0] == "fr")
				message = "Voulez-vous vraiment quitter ?";
			else
			{
				message = "Do you really want to leave?";
			}
			Confirmation confirmationWindow = new Confirmation(message, settingsChoices[0]);
			var dialogResult = confirmationWindow.ShowDialog();

			if (!(bool)dialogResult)
			{
				e.Cancel = true;
			}
			
            
		}

		#endregion

		public void DisableCancel()
		{
			canCancel = false;
			btnCancel.IsEnabled = false;
		}

        public void LoadCommonSettings()
        {
            if (State.Language == "fr")
            {
                rbtnEnglish.IsChecked = false;
                rbtnFrench.IsChecked = true;
            }
            if (State.Championship == "women")
            {
                rbtnMen.IsChecked = false;
                rbtnWomen.IsChecked = true;
            }
            for (int i = 0; i < cbCountries.Items.Count; i++)
            {
                if (cbCountries.Items[i].ToString().Contains(State.FifaCode))
                {
                    cbCountries.SelectedIndex = i;
                    i = cbCountries.Items.Count - 1;
                }
            }
            if(State.IsLocal == "1")
                checkBoxIsLocal.IsChecked = true;
        }


        public void PushSettings()
        {
            State.Language = settingsChoices[0];
            State.Championship = settingsChoices[1];
            State.IsLocal = settingsChoices[4];
            

            //Extract fifa code
            var temp = cbCountries.SelectedItem.ToString()!.Split(" (");
            temp = temp[1].Split(")");
            if (State.FavPlayers !=  new string[3]{ "", "", ""} && State.FifaCode != temp[0])
                State.FavPlayers = new string[3] { "", "", "" };

            State.FifaCode = temp[0];

            //get display mode
            if (settingsChoices[3] == "0")
                State.DisplayMode = "fullscreen";
            else
            {
                var mode = cbDisplayModes.Items[int.Parse(settingsChoices[3])].ToString().Split(": ");

				State.DisplayMode = mode[1];
            }
		}

		private void cbDisplayModes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
            if (ignoreEvent)
                return;
            settingsChoices[3] = cbDisplayModes.SelectedIndex.ToString();
		}

        private void checkBoxIsLocal_Unchecked(object sender, RoutedEventArgs e)
        {
            settingsChoices[4] = "0";
        }

        private void checkBoxIsLocal_Checked(object sender, RoutedEventArgs e)
        {
            settingsChoices[4] = "1";
        }
    }
}
