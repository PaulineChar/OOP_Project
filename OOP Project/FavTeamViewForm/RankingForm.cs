using DAL;
using DAL.Models;
using DAL.Repositories;
using DAL.State;
using System.Drawing.Printing;
using System.Globalization;
using UI_Windows_Forms;
using UI_Windows_Forms.Properties;
using UI_Windows_Forms.UserControllers;

namespace UI
{
    public partial class RankingForm : Form
    {
        private bool IsMatchRankingLoaded = false;
        private Match[] matches;
        private string fifaCode;
        private string currentSort;
        private List<GridUC> elements;
        private List<MatchUC> matchElements;
        private PrintDocument printDocument;

        public RankingForm()
        {
            this.FormClosing += rankingForm_FormClosing!;
            FileManager.LoadAllSettings();
            StartAll();
        }

        private void StartAll()
        {
            elements = new List<GridUC>();
            matchElements = new List<MatchUC>();
            currentSort = "GoalsDesc";
            //matchSort = "Desc";
            IsMatchRankingLoaded = false;
            //Language
            Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);

            //Initialize components
            InitializeComponent();
            Initialize();
        }



        #region Event handlers

        private void tspSettings_Click(object sender, EventArgs e)
        {
            List<string> previousSettings = new List<string>() { State.Language, State.Championship, State.FifaCode, State.IsLocal };
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.UpdateWithCurrentSettings();
            var settings = settingsForm.previousSettings;
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                int action = FileManager.ChangeSettings(settings[0], settings[1]);
                NextAction(action, previousSettings);
            }

        }

        private void NextAction(int action, List<string> previousSettings)
        {
            switch (action)
            {
                case 0:
                    return;
                case 1: //refresh the page
                    Controls.Clear();
                    StartAll();
                    return;
                case 2: //Change all the settings: choose new favorite team
                    bool isOK = Initialization.ChangeChampionship();
                    if (isOK)
                    {
                        //Refreshes the table
                        Controls.Clear();
                        StartAll();
                    }
                    else
                    {
                        //the change was cancelled
                        State.Language = previousSettings[0];
                        State.Championship = previousSettings[1];
                        State.FifaCode = previousSettings[2];
                        State.IsLocal = previousSettings[3];
                    }

                    return;
                case 3:
                    MessageBox.Show("Something happened while changing the settings", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

            }
        }

        private void rankingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm closeForm = new CloseForm(State.Language);
            if (closeForm.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            /*Graphics screen = Graphics.FromImage(rankingImage1);
			screen.CopyFromScreen(tcRanking.Location.X + this.Location.X + 13, tcRanking.Location.Y + this.Location.Y + 45, 0, 0, imageSize);
*/
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            TabPage page1;
            TabPage page2;
            Size imageSize = tpPlayerRanking.Size;
            int selectedIndex = tcRanking.SelectedIndex;
            if (selectedIndex == 0)
            {
                page1 = tpPlayerRanking;
                page2 = tpMatchRanking;

            }
            else
            {
                page1 = tpMatchRanking;
                page2 = tpPlayerRanking;
            }


            Bitmap rankingImage1 = new Bitmap(imageSize.Width, imageSize.Height/*, graphics*/);
            Bitmap rankingImage2 = new Bitmap(imageSize.Width, imageSize.Height/*, graphics2*/);

            page1.DrawToBitmap(rankingImage1, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = imageSize.Width,
                Height = imageSize.Height
            });
            tcRanking.SelectedIndex = selectedIndex == 0 ? 1 : 0;
            page2.DrawToBitmap(rankingImage2, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = imageSize.Width,
                Height = imageSize.Height
            });
            tcRanking.SelectedIndex = selectedIndex;

            e.Graphics.DrawImage(rankingImage1, 0, 0);
            e.Graphics.DrawImage(rankingImage2, 0, imageSize.Height / 4 * 3);
        }

        private void tcRanking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsMatchRankingLoaded && tcRanking.SelectedIndex == 1)
            {
                FillMatchRanking();
            }
        }

        private void csmiCardsAsc_Click(object sender, EventArgs e)
        {
            if (currentSort == "CardsAsc")
                return;
            flpGridContainer.Controls.Clear();
            SortAndAddToPanel(false, false);
            currentSort = "CardsAsc";
        }

        private void csmiCardsDesc_Click(object sender, EventArgs e)
        {
            if (currentSort == "CardsDesc")
                return;
            flpGridContainer.Controls.Clear();
            SortAndAddToPanel(false, true);
            currentSort = "CardsDesc";
        }

        private void cmsiGoalsAsc_Click(object sender, EventArgs e)
        {
            if (currentSort == "GoalsAsc")
                return;
            flpGridContainer.Controls.Clear();
            SortAndAddToPanel(true, false);
            currentSort = "GoalsAsc";
        }

        private void csmiGoalsDesc_Click(object sender, EventArgs e)
        {
            if (currentSort == "GoalsDesc")
                return;
            flpGridContainer.Controls.Clear();
            SortAndAddToPanel(true, true);
            currentSort = "GoalsDesc";
        }

        private void cmsiDesc_Click(object sender, EventArgs e)
        {
            if (currentSort != "Desc")
                SortMatches();
        }

        private void cmsiAsc_Click(object sender, EventArgs e)
        {
            if (currentSort != "Asc")
                SortMatches();
        }

        #endregion

        #region Data and grids

        /*
         * 
         */
        private async void Initialize()
        {

            LoadingUC loadingUC = ShowLoading();
            //get settings
            if (State.Championship == null || State.FifaCode == null)
            {
                MessageBox.Show("An error occurred while fetching the settings. Try restarting the application.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get matches data and update variables
            try
            {
                matches = null;
                if (State.IsLocal == "0")
                    matches = await RequestController.GetMatchesData(State.Championship, State.FifaCode);
                else
                    matches = RequestController.GetJsonMatches(State.Championship, State.FifaCode);
            }
            catch
            {
                MessageBox.Show(Resources.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matches == null)
            {
                MessageBox.Show(Resources.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fifaCode = State.FifaCode;

            LoadPlayerRanking();
            StopLoading(loadingUC);
        }


        private void LoadPlayerRanking()
        {
            //Get players
            List<Player> players = PlayerRepository.GetAndUpdatePlayersFromMatches(matches, fifaCode);

            //Update the favorites
            UpdateFavorites(players);

            //Fill the grid
            FillPlayerRanking(players);
        }

        private void UpdateFavorites(List<Player> players)
        {
            List<string> settings = State.FavPlayers.ToList();
            if (settings == null)
            {
                MessageBox.Show("There was an error with you settings. Did you modify them from outside the application?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (string name in settings)
            {
                var player = players.Find(p => p.Name == name);
                player.Favorite = true;
            }
        }

        /*
         * Fills the FlowLayoutPanel with the information to create a grid
         */
        private void FillPlayerRanking(List<Player> players)
        {
            GridUC gridUC;
            //List<GridUC> elements = new List<GridUC>();

            //Fill with players sorted by goals from most to least goals
            //(and least to most yellow cards if equal)
            foreach (Player player in players)
            {
                gridUC = new GridUC();
                gridUC.CreateRow(player);
                elements.Add(gridUC);
            }

            SortAndAddToPanel(true, true);

        }

        private void SortAndAddToPanel(bool byGoal, bool descending)
        {
            GridUC gridUC;
            //Header
            for (int i = 0; i < 4; i++)
            {
                gridUC = new GridUC();
                gridUC.CreateHeader();
                flpGridContainer.Controls.Add(gridUC);
            }

            SortData(byGoal, descending);

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].SetRank(i + 1);
            }
            flpGridContainer.Controls.AddRange(elements.ToArray());
        }

        private void FillMatchRanking()
        {
            MatchUC matchUC = new MatchUC();
            flpMatchContainer.Size = new Size(1376, 705);

            matchUC.CreateHeader();
            flpMatchContainer.Controls.Add(matchUC);

            foreach (Match match in matches)
            {
                matchUC = new MatchUC();
                matchUC.UpdateRow(match);
                matchElements.Add(matchUC);
            }

            SortMatches();

            flpMatchContainer.Controls.AddRange(matchElements.ToArray());

            IsMatchRankingLoaded = true;
        }

        private void SortMatches()
        {
            if (currentSort == "Desc")
            {
                currentSort = "Asc";
                matchElements.Sort((m1, m2) => m1.GetAttendance() > m2.GetAttendance() ? 1 : m1.GetAttendance() < m2.GetAttendance() ? -1 : 0);
            }
            else
            {
                currentSort = "Desc";
                matchElements.Sort((m1, m2) => m1.GetAttendance() < m2.GetAttendance() ? 1 : m1.GetAttendance() > m2.GetAttendance() ? -1 : 0);
            }

        }

        private void SortData(bool byGoal, bool descending)
        {
            if (byGoal)
            {
                elements.Sort((p1, p2) => SortByGoal(p1, p2, descending));
            }
            else
            {
                elements.Sort((p1, p2) => SortByYellowCard(p1, p2, descending));
            }
        }

        //I am so sorry for these 2 functions
        private int SortByGoal(GridUC p1, GridUC p2, bool descending)
        {
            int result = (p1.GetGoals() > p2.GetGoals()) ? -1 : (p1.GetGoals() < p2.GetGoals()) ? 1 : (p1.GetYellowCards() < p2.GetYellowCards()) ? -1 : (p1.GetYellowCards() > p1.GetYellowCards()) ? 1 : 0;
            return descending ? result : -result;
        }

        private int SortByYellowCard(GridUC p1, GridUC p2, bool descending)
        {
            int result = (p1.GetYellowCards() > p2.GetYellowCards()) ? -1 : (p1.GetYellowCards() < p2.GetYellowCards()) ? 1 : (p1.GetGoals() < p2.GetGoals()) ? -1 : (p1.GetGoals() > p1.GetGoals()) ? 1 : 0;
            return descending ? result : -result;
        }

        private LoadingUC ShowLoading()
        {
            LoadingUC loadingUC = new LoadingUC(State.Language);
            loadingUC.Location = new Point
            {
                X = (ClientSize.Width - loadingUC.Size.Width) / 2,
                Y = (ClientSize.Height - loadingUC.Size.Height) / 2
            };
            this.Controls.Add(loadingUC);
            loadingUC.Show();
            loadingUC.BringToFront();
            return loadingUC;
        }

        private void StopLoading(LoadingUC loadingUC)
        {
            loadingUC.Dispose();
        }

        #endregion
    }
}
