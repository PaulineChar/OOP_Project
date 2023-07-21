using DAL;
using DAL.Models;
using DAL.Repositories;
using DAL.State;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF
{
	/// <summary>
	/// Interaction logic for TeamOverviewWindow.xaml
	/// </summary>
	public partial class TeamOverviewWindow : Window
    {
        private Brush brush = Brushes.LightBlue;
        private Country team;
		private Match[]? matches;
        public TeamOverviewWindow(Country team, bool isSelected)
        {
            this.team = team;
			Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);

            InitializeComponent();
            if(isSelected)
            {
                ChangeColor();
            }
			matches = null;
			Fill(matches);
		}


		public TeamOverviewWindow(Country team, bool isSelected, Match[] _matches)
        {
			this.team = team;
			InitializeComponent();
			if (isSelected)
			{
				ChangeColor();
			}
			matches = _matches;
			Fill(matches);
		}

		private async void Fill(Match[]? matches)
		{
			await FillLabels(team, matches);
		}

		private void ChangeColor()
		{
			teamOverviewWindow.Background = brush;
		}

		private async Task FillLabels(Country team, Match[]? matches)
		{
            lbName.Content = team.Name;
            lbFifaCode.Content = team.FifaCode;
			if(matches == null)
			{
				try
				{
                    if (State.IsLocal == "0")
                        matches = await RequestController.GetMatchesData(State.Championship, team.FifaCode);
                    else
                        matches = RequestController.GetJsonMatches(State.Championship, team.FifaCode);
				}
				catch
				{
                    MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
			}
			if (matches == null)
			{
                MessageBox.Show(Properties.Resources.Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
			}

            lbGames.Content = matches.Count().ToString();

            List<int> overview = MatchRepository.GetAllInfo(matches, team.FifaCode);
            lbWins.Content = overview[0];
            lbLosses.Content = overview[1];
            lbDraws.Content = matches.Count() - overview[0] - overview[1];

            lbGoalsScored.Content = overview[2];
            lbGoalsConceded.Content = overview[3];
            lbGoalsDifference.Content = overview[2] - overview[3];
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

	}
}
