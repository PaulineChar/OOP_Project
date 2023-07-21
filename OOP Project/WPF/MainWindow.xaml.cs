using DAL;
using DAL.Models;
using DAL.State;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WPF.Properties;
using WPF.User_controls;

namespace WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	//TODO Loading animations
	public partial class MainWindow : Window
    {
		private static Country[] countries = null;
		private static List<Tuple<Country, Match>> opposingCountries = new();
		private static List<PlayersUC> selectedPlayers = new();
		private static List<PlayersUC> opposingPlayers = new();
		private TeamOverviewWindow teamOverviewWindow = null;
		private PlayerOverviewWindow playerOverviewWindow = null;
		private Settings settingsWindow = null;
		private bool ignoreEvent;
		private string selectedFifaCode = "";
		private bool error = false;
		private int animCount = 0;

		private Storyboard loadingStoryboard;
		private LinearGradientBrush loadingBrush;
		private Storyboard buttonSelectedStoryboard = new Storyboard();
        private Storyboard buttonOpposingStoryboard = new Storyboard();

        public MainWindow()
        {
			var isOk = Initialization.Start();
			if(isOk)
			{
                Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);
                InitializeComponent();
                ResizeWindow();
                ignoreEvent = true;
            }
        }

		private void ResizeWindow()
		{
			if (State.DisplayMode == "fullscreen")
				this.WindowState = WindowState.Maximized;
			else
			{
				this.WindowState = WindowState.Normal;
				string[] temp = State.DisplayMode.Split("x");
				this.Width = int.Parse(temp[0]);
				this.Height = int.Parse(temp[1]);
			}
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateLoadingStoryboard();
			StartLoadingAnimation();

			if (countries == null)
			{
				//fill the countries array and the combobox
				await LoadCountries();
			}
			if (countries == null)
				return;

			await Setup(false);

            StopLoadingAnimation();
			CreateButtonStoryboards();
		}

        private async Task Setup(bool isChange)
		{
            CleanSelected();
            CleanOpposing();
            string initialOpposingFifaCode = "";
			string initialSelectedFifaCode = selectedFifaCode;
			if(isChange)
			{
				//get fifa code
                initialOpposingFifaCode = opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode;
			}
			var temp = new List<PlayersUC>(selectedPlayers);
			selectedFifaCode = countries[cbSelectedTeam.SelectedIndex].FifaCode;
			//Fill the "opposingCountries" array
			//Fill the "Opposing" combobox
			if(!isChange)
				await LoadAndUpdateOpposing(State.FifaCode);
			else
			{
				await LoadAndUpdateOpposing(selectedFifaCode);
			}
			if (error)
				return;

			//switch, no need to create them again
			if (isChange && countries[cbSelectedTeam.SelectedIndex].FifaCode == initialOpposingFifaCode)
			{
				selectedPlayers = opposingPlayers;
				foreach (var player in selectedPlayers)
				{
					player.ChangeColor(true);
				}
			}
			else
			{
				//Selected
				CreatePlayersUC(countries[cbSelectedTeam.SelectedIndex].FifaCode, true);
			}

			if (isChange && opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode == initialSelectedFifaCode)
			{
				opposingPlayers = temp;
				foreach(var player in opposingPlayers)
				{
					player.ChangeColor(false);
				}
			}
			else
			{
				//Opposing
				/*CleanPlayersUC();*/
				CreatePlayersUC(opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode, false);
			}
	
			//Scores
			UpdateScores(opposingCountries[cbOpposingTeam.SelectedIndex]);

			//Place them on the field
			if (isChange)
			{
				CleanSelected();
				CleanOpposing();
			}
			//selected
			PlaceSelectedPlayers();
			//opposing				
			PlaceOpposingPlayers();
		}

		private void UpdateScores(Tuple<Country, Match> opposing)
		{
			int selectedScore;
			int opposingScore;
			if (opposing.Item2.AwayTeamCode.FifaCode == opposing.Item1.FifaCode)
			{
				opposingScore = opposing.Item2.AwayTeamCode.Goals;
				selectedScore = opposing.Item2.HomeTeamCode.Goals;
			}
			else
			{
				opposingScore = opposing.Item2.HomeTeamCode.Goals;
				selectedScore = opposing.Item2.AwayTeamCode.Goals;
			}
			lbScore.Content = $"{selectedScore} : {opposingScore}";
		}

		private void PlaceOpposingPlayers()
		{
			int nbDefender = 0;
			int nbMidField = 0;
			int nbForward = 0;
			foreach (var player in opposingPlayers)
			{
				switch (player.position)
				{
					case ("Goalie"):
						gridOpposingGoalie.Children.Add(player);
						break;
					case ("Defender"):
						if (nbDefender < 4)
						{
							Grid.SetRow(player, nbDefender);
							gridOpposingDefender.Children.Add(player);
							nbDefender++;
						}
						else //has to be place in the MidField
						{
							Grid.SetRow(player, nbMidField);
							gridOpposingMidfieldAndForward.Children.Add(player);
							nbMidField++;
						}
						break;
					case ("Midfield"):
						if (nbMidField < 5)
						{
							Grid.SetRow(player, nbMidField);
							gridOpposingMidfieldAndForward.Children.Add(player);
							nbMidField++;
						}
						else //weird but has to be placed as a defender
						{
							Grid.SetRow(player, nbDefender);
							gridOpposingDefender.Children.Add(player);
							nbDefender++;
						}
						break;
					case ("Forward"):
						if (nbForward < 1)
						{
							gridOpposingForward.Children.Add(player);
							nbForward++;
						}
						else //is in the midfield. I guess they can't be too much for this zone
						{
							Grid.SetRow(player, nbMidField);
							gridOpposingMidfieldAndForward.Children.Add(player);
							nbMidField++;
						}
						break;
				}
			}
		}

		private void PlaceSelectedPlayers()
		{
			int nbDefender = 0;
			int nbMidField = 0;
			int nbForward = 0;
			List<PlayersUC> defenders = new List<PlayersUC>();
            List<PlayersUC> midfielders = new List<PlayersUC>();
            List<PlayersUC> forwards = new List<PlayersUC>();

            GetPositions(defenders, midfielders, forwards);

			foreach(PlayersUC defender in defenders)
			{
                if (nbDefender < 4)
                {
                    Grid.SetRow(defender, nbDefender);
                    gridSelectedDefender.Children.Add(defender);
                    nbDefender++;
                }
                else //has to be place in the MidField
                {
                    Grid.SetRow(defender, nbMidField);
                    gridSelectedMidfieldAndForward.Children.Add(defender);
                    nbMidField++;
                }
            }
			foreach(PlayersUC midfielder in midfielders)
			{

                if(nbDefender < 4) //weird but has to be placed as a defender
                {
                    Grid.SetRow(midfielder, nbDefender);
                    gridSelectedDefender.Children.Add(midfielder);
                    nbDefender++;
                }
                else //in the midfield gird
                {
                    Grid.SetRow(midfielder, nbMidField);
                    gridSelectedMidfieldAndForward.Children.Add(midfielder);
                    nbMidField++;
                }
            }
			foreach(PlayersUC forward in forwards) 
			{
                if (nbForward < 1)
                {
                    gridSelectedForward.Children.Add(forward);
                    nbForward++;
                }
                else //is in the midfield
                {
                    Grid.SetRow(forward, nbMidField);
                    gridSelectedMidfieldAndForward.Children.Add(forward);
                    nbMidField++;
                }
            }
		}

		//Separate players depending on their position (except goalie)
        private void GetPositions(List<PlayersUC> defenders, List<PlayersUC> midfielders, List<PlayersUC> forwards)
        {
            foreach (PlayersUC player in selectedPlayers)
            {
                switch (player.position)
                {
                    case ("Goalie"):
                        gridSelectedGoalie.Children.Add(player);
                        break;
                    case ("Defender"):
                        defenders.Add(player);
                        break;
                    case ("Midfield"):
                        midfielders.Add(player);
                        break;
                    case ("Forward"):
                        forwards.Add(player);
                        break;
                }
            }
        }

        private void CreatePlayersUC(string fifaCode, bool isSelectedTeam)
		{
			if(isSelectedTeam)
			{
				selectedPlayers.Clear();
			}
			else
			{
				opposingPlayers.Clear();
			}
			Match match = opposingCountries[cbOpposingTeam.SelectedIndex].Item2;
			PlayersUC pUC;
			if (match.AwayTeamCode.FifaCode ==  fifaCode)
			{
				foreach(var player in match.AwayTeamStatistics.StartingPlayers)
				{
					
					if(isSelectedTeam)
					{
						pUC = new PlayersUC(player.ShirtNumber, player.Name, player.Position, player.Captain, true);

						pUC.MouseDown += PUC_MouseDown;

						selectedPlayers.Add(pUC);
					}
					else
					{
						pUC = new PlayersUC(player.ShirtNumber, player.Name, player.Position, player.Captain, false);

						pUC.MouseDown += PUC_MouseDown;
						opposingPlayers.Add(pUC);
					}
				}
			}
			else
			{
				foreach (var player in match.HomeTeamStatistics.StartingPlayers)
				{
					if (isSelectedTeam)
					{
						pUC = new PlayersUC(player.ShirtNumber, player.Name, player.Position, player.Captain, true);

						pUC.MouseDown += PUC_MouseDown;
						selectedPlayers.Add(pUC);
					}
					else
					{
						pUC = new PlayersUC(player.ShirtNumber, player.Name, player.Position, player.Captain, false);
						
						pUC.MouseDown += PUC_MouseDown;
						opposingPlayers.Add(pUC);
					}
				}
			}
		}

		private async void PUC_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Animation
			CreatePlayerUCAnimation(sender as PlayersUC);
			await Task.Delay(300);

			string fifaCode;
			if((sender as PlayersUC)!.IsSelected())
			{
				if(opposingCountries[cbOpposingTeam.SelectedIndex].Item2.HomeTeamCode.FifaCode == opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode)
				{
					fifaCode = opposingCountries[cbOpposingTeam.SelectedIndex].Item2.AwayTeamCode.FifaCode;
				}
				else
				{
					fifaCode = opposingCountries[cbOpposingTeam.SelectedIndex].Item2.HomeTeamCode.FifaCode;
				}
			}
			else
			{
				fifaCode = opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode;
			}
			playerOverviewWindow = new PlayerOverviewWindow(sender as PlayersUC,
				opposingCountries[cbOpposingTeam.SelectedIndex].Item2,
				(sender as PlayersUC)!.IsSelected(), 
				fifaCode);

			//var location = (sender as PlayersUC)!.PointToScreen(new Point(0, 0));
			
			playerOverviewWindow.ShowDialog();
		}


        private async Task LoadAndUpdateOpposing(string fifaCode)
		{
			//Fills the list
			Match[] matches;
			try
			{
                if (State.IsLocal == "0")
                    matches = await RequestController.GetMatchesData(State.Championship, fifaCode);
                else
                    matches = RequestController.GetJsonMatches(State.Championship, fifaCode);
			}
			catch
			{
                MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				error = true;
				return;
            }
			
			if(matches == null)
			{
                MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				error = true;
				return;
            }

			opposingCountries.Clear();
			foreach (Match match in matches)
			{
				
				if(match.HomeTeamCode.FifaCode != fifaCode)
				{
					opposingCountries.Add(new Tuple<Country, Match>(match.HomeTeamCode, match));
				}
				else
				{
					opposingCountries.Add(new Tuple<Country, Match>(match.AwayTeamCode, match));
				}
			}
			opposingCountries.Sort((e1, e2) => string.Compare(e1.Item1.Name, e2.Item1.Name));

			ignoreEvent = true;
			//Fill the combobox
			cbOpposingTeam.Items.Clear();
			foreach(var element in opposingCountries)
			{
				cbOpposingTeam.Items.Add($"{element.Item1.Name} ({element.Item1.FifaCode})");
			}
			cbOpposingTeam.SelectedIndex = 0;
			ignoreEvent = false;
		}

		private void UpdateSelectedComboBox(Country[]? countries)
		{
			cbSelectedTeam.Items.Clear();
			foreach (var country in countries)
			{
				cbSelectedTeam.Items.Add(country);
			}
			Array.Sort(countries, (c1, c2) => string.Compare(c1.Name, c2.Name));

			//Find the selected team
			for (int i = 0; i < cbSelectedTeam.Items.Count; i++)
			{
				if (cbSelectedTeam.Items[i].ToString()!.Contains(State.FifaCode))
				{
					cbSelectedTeam.SelectedIndex = i;
					i = cbSelectedTeam.Items.Count;
				}
			}
		}

		private async Task LoadCountries()
		{
			try
			{
				countries = await RequestController.GetCountriesData(State.Championship);
			}
			catch
			{
				countries = null!;
                MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
            }

			if(countries == null)
			{
                MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
            }
			
			Array.Sort(countries, (c1, c2) => string.Compare(c1.Name, c2.Name));

			ignoreEvent = true;
			//Fill the "Selected" combobox
			UpdateSelectedComboBox(countries);
			ignoreEvent = false;
		}

		private async void TeamInfo_Click(object sender, RoutedEventArgs e)
		{
			//call team info window
			if(((Button)sender).Name == "btnInfoOpp")
			{
				StartButtonAnimation(false);
				teamOverviewWindow = new TeamOverviewWindow(opposingCountries[cbOpposingTeam.SelectedIndex].Item1, false);
			}
			else
			{
				StartButtonAnimation(true);
				List<Match> matches = new List<Match>();
				foreach(var info in opposingCountries)
				{
					matches.Add(info.Item2);
				}
				teamOverviewWindow = new TeamOverviewWindow(countries[cbSelectedTeam.SelectedIndex], true, matches.ToArray());
			}
			await Task.Delay(500);
			teamOverviewWindow.ShowDialog();
		}

        private async void cbSelectedTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//Initialization of the combobox
			if (ignoreEvent)
				return;
			//fetch new matches & fill opposingPlayers
			//fill opposing combobox
			//change selectedPlayers: if opposing team, exchange else find in match
			//place selected players
			//place opposing players
			State.FifaCode = ((Country)cbSelectedTeam.SelectedItem).FifaCode;
			State.FavPlayers = new string[3] { "", "", "" };

			StartLoadingAnimation();

			await Setup(true);

			StopLoadingAnimation();

		}

		private void cbOpposingTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(ignoreEvent)
				return;

			StartLoadingAnimation();

			//Change selectedPlayers
			CreatePlayersUC(selectedFifaCode, true);
			//Change opposingPlayers
			CreatePlayersUC(opposingCountries[cbOpposingTeam.SelectedIndex].Item1.FifaCode, false);
			//Update scores
			UpdateScores(opposingCountries[cbOpposingTeam.SelectedIndex]);
			//Place them on the field
			CleanOpposing();
			CleanSelected();
			PlaceOpposingPlayers();
			PlaceSelectedPlayers();

			StopLoadingAnimation();
		}

		private void CleanOpposing()
		{
			gridOpposingGoalie.Children.Clear();
			gridOpposingForward.Children.Clear();
			gridOpposingDefender.Children.Clear();
			gridOpposingMidfieldAndForward.Children.Clear();
		}

		private void CleanSelected()
		{
			gridSelectedGoalie.Children.Clear();
			gridSelectedForward.Children.Clear();
			gridSelectedDefender.Children.Clear();
			gridSelectedMidfieldAndForward.Children.Clear();
		}


		//If I don't do this, there is still a thread running in the background,
		//even when the window is closed
		private void Window_Closed(object sender, EventArgs e)
		{
			Application.Current.Dispatcher.InvokeShutdown();
		}

		private async void btnSettings_Click(object sender, RoutedEventArgs e)
		{
			string language = State.Language;
			string championship = State.Championship;
			string favoriteTeam = State.FifaCode;
			string displayMode = State.DisplayMode;
			settingsWindow = new Settings(State.Language, true);
			if((bool)settingsWindow.ShowDialog()!)
			{
                StartLoadingAnimation();

                //If change language, update all text
                if (State.Language != language)
					UpdateAllText();
				//If change championship, reload all comboboxes
				if(State.Championship != championship)
				{
					State.FavPlayers = new string[3] { "", "", "" };
					await LoadCountries();
					if (countries == null)
						return;
					await Setup(false);
					if (error)
						return;
				}
				//select the good team
				else if(State.FifaCode != favoriteTeam)
				{
					State.FavPlayers = new string[3] { "", "", "" };
					//Select the good team
					for (int i = 0; i < cbSelectedTeam.Items.Count; i++)
					{
						if (cbSelectedTeam.Items[i].ToString().Contains(State.FifaCode))
						{
							cbSelectedTeam.SelectedIndex = i;
							i = cbSelectedTeam.Items.Count;
						}
					}
				}
				if(State.DisplayMode != displayMode)
				{
					ResizeWindow();
				}

                StopLoadingAnimation();
            }
        }

		//luckily, I don't have a lot of text to update
		private void UpdateAllText()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);
            this.Title = Properties.Resources.MatchOverview;
			btnInfoOpp.Content = btnInfoOpp.Content = Properties.Resources.ShowInfo;
			lbSelect.Content = Properties.Resources.SelectedTeam;
			lbOpp.Content = Properties.Resources.OpposingTeam;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string message;
			if (State.Language == "fr")
				message = "Voulez-vous vraiment quitter ?";
			else
			{
				message = "Do you really want to leave?";
			}

			Confirmation confirmationWindow = new Confirmation(message, State.Language);
			var dialogResult = confirmationWindow.ShowDialog();

			if (!(bool)dialogResult)
			{
				e.Cancel = true;
			}

			//Finally update the settings
			FileManager.CreateSetting();
		}

        #region Animations

        private void StopLoadingAnimation()
        {
            loadingStoryboard.Stop(this);
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            HeaderGrid.Background = brush;
        }

        private void CreateLoadingStoryboard()
        {
            //The name has to change to be able to create it
            string eventName = "MovingStop";
            //creation of the brush
            LinearGradientBrush loadingBrush = new LinearGradientBrush();

            GradientStop stop1 = new GradientStop((Color)ColorConverter.ConvertFromString("#FF00CA86"), 0.0);
            GradientStop movingStop = new GradientStop(Color.FromRgb(255, 255, 255), 0.0);
            GradientStop stop3 = new GradientStop((Color)ColorConverter.ConvertFromString("#FF00CA86"), 1.0);

            this.RegisterName(eventName, movingStop);

            loadingBrush.GradientStops.Add(stop1);
            loadingBrush.GradientStops.Add(movingStop);
            loadingBrush.GradientStops.Add(stop3);

            this.loadingBrush = loadingBrush;

            //Animation
            DoubleAnimation loadingAnimation = new DoubleAnimation();
            loadingAnimation.From = 0.0;
            loadingAnimation.To = 1.0;
            loadingAnimation.Duration = TimeSpan.FromSeconds(1);
            loadingAnimation.RepeatBehavior = RepeatBehavior.Forever;
            loadingAnimation.AutoReverse = true;
            Storyboard.SetTargetName(loadingAnimation, eventName);
            Storyboard.SetTargetProperty(loadingAnimation, new PropertyPath(GradientStop.OffsetProperty));

            //Create the storyboard
            Storyboard loadingStoryboard = new Storyboard();
            loadingStoryboard.Children.Add(loadingAnimation);

            this.loadingStoryboard = loadingStoryboard;
        }

        private void StartLoadingAnimation()
        {
            HeaderGrid.Background = loadingBrush;

            //Begin
            loadingStoryboard.Begin(this, true);
        }


        private void CreatePlayerUCAnimation(PlayersUC player)
        {
            string eventName = $"player{animCount++}";
            this.RegisterName(eventName, player);

            //Animation
            DoubleAnimation playerAnimation = new DoubleAnimation();
            playerAnimation.From = 1.0;
            playerAnimation.To = 0.0;
            playerAnimation.Duration = TimeSpan.FromSeconds(0.15);
            playerAnimation.AutoReverse = true;
            Storyboard.SetTargetName(playerAnimation, eventName);
            Storyboard.SetTargetProperty(playerAnimation, new PropertyPath(OpacityProperty));

            //Create the storyboard
            Storyboard playerStoryboard = new Storyboard();
            playerStoryboard.Children.Add(playerAnimation);

            //Begin
            playerStoryboard.Begin(this);
        }

        private void CreateButtonStoryboards()
		{
			//selected team
			this.RegisterName("InfoSelect", btnInfoSelect);
			ColorAnimation selectedAnimation = new ColorAnimation();
			selectedAnimation.From = (Color)ColorConverter.ConvertFromString("#FFDDDDDD");
			selectedAnimation.To = Colors.LightBlue;
			selectedAnimation.Duration = TimeSpan.FromSeconds(0.25);
			selectedAnimation.AutoReverse = true;
			Storyboard.SetTargetName(selectedAnimation, "InfoSelect");
            Storyboard.SetTargetProperty(selectedAnimation, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));

			buttonSelectedStoryboard.Children.Add(selectedAnimation);

            //opposing team
            this.RegisterName("InfoOpp", btnInfoOpp);
            ColorAnimation opposingAnimation = new ColorAnimation();
            opposingAnimation.From = (Color)ColorConverter.ConvertFromString("#FFDDDDDD");
            opposingAnimation.To = Colors.IndianRed;
            opposingAnimation.Duration = TimeSpan.FromSeconds(0.25);
            opposingAnimation.AutoReverse = true;
            Storyboard.SetTargetName(opposingAnimation, "InfoOpp");
            Storyboard.SetTargetProperty(opposingAnimation, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));

            buttonOpposingStoryboard.Children.Add(opposingAnimation);
        }

        private void StartButtonAnimation(bool isSelectedTeam)
        {
			if (isSelectedTeam)
				buttonSelectedStoryboard.Begin(this);
			else
				buttonOpposingStoryboard.Begin(this);
			
        }
	

        #endregion
    }
}
