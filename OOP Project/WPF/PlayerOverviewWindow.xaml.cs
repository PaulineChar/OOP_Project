using DAL.Models;
using DAL.State;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using WPF.Properties;
using WPF.User_controls;

namespace WPF
{
	/// <summary>
	/// Interaction logic for PlayerOverviewWindow.xaml
	/// </summary>
	public partial class PlayerOverviewWindow : Window
	{
        private const string PICTURE_PATH = "../../../Properties/Images/";

        public PlayerOverviewWindow(PlayersUC player, Match match, bool isSelected, string fifaCode)
		{
            Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);
            InitializeComponent();
			if(isSelected)
			{
				ChangeColor();
			}
			UpdateOverview(player, match, fifaCode);
		}

		private void UpdateOverview(PlayersUC player, Match match, string fifaCode)
		{
			lbShirtNumber.Content = player.shirtnumber;
			lbName.Content = player.name;
			switch(player.position)
			{
				case "Defender":
					lbPosition.Content = Properties.Resources.Defender;
					break;
				case "Goalie":
					lbPosition.Content = Properties.Resources.Goalie;
					break;
				case "Forward":
					lbPosition.Content = Properties.Resources.Forward;
					break;
				case "Midfield":
					lbPosition.Content = Properties.Resources.Midfield;
					break;
			}
			if (File.Exists(PICTURE_PATH + player.name + ".png"))
			{
                imagePlayer.Source = new BitmapImage(
                    new Uri($"{PICTURE_PATH}{player.name}.png", UriKind.Relative));
            }

			lbCaptain.Content = player.captain ? Properties.Resources.Yes : Properties.Resources.No;
			GetEvents(match, fifaCode);
		}

		private void GetEvents(Match match, string fifaCode)
		{
			int goals = 0;
			int yellowCards = 0;
			if(fifaCode == match.HomeTeamCode.FifaCode)
			{
				foreach(var matchEvent in match.HomeTeamEvent)
				{
					if (matchEvent.PlayerName == (string)lbName.Content)
					{
						if(matchEvent.Type.Contains("goal"))
							goals++;
						else if(matchEvent.Type.Contains("yellow"))
							yellowCards++;
					}
				}
			}
			else
			{
				foreach (var matchEvent in match.AwayTeamEvent)
				{
					if (matchEvent.PlayerName == (string)lbName.Content)
					{
						if (matchEvent.Type.Contains("goal"))
							goals++;
						else if (matchEvent.Type.Contains("yellow"))
							yellowCards++;
					}
				}
			}

			lbGoals.Content = goals;
			lbYellowcards.Content = yellowCards;
		}

		private void ChangeColor()
		{
			grid.Background = Brushes.LightBlue;
		}


		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
