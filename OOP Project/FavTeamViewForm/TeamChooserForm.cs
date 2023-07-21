using DAL;
using DAL.Models;
using DAL.Repositories;
using DAL.State;
using System.Globalization;
using UI_Windows_Forms;
using UI_Windows_Forms.Properties;

namespace UI
{
    public partial class TeamChooserForm : Form
    {
        /*        private static List<PlayerUC> AllPlayersList = new List<PlayerUC>();
                private static List<PlayerUC> FavoritePlayers = new List<PlayerUC>();*/
        private static List<PlayerUC> SelectedPlayers;
        private bool canClose;
        private bool first;


        public TeamChooserForm(bool firstTime)
        {
            SelectedPlayers = new List<PlayerUC>();

            Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(State.Language);
            InitializeComponent();
            canClose = false;
            first = firstTime;
        }


        private async void TeamChooserForm_Load(object sender, EventArgs e)
        {
            Visible = true;
            await LoadCountries();
            if (!first)
            {
                DisableCountry();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (flpFavPlayers.Controls.Count != 3)
            {
                //sorry
                if (State.Language == "fr")
                {
                    MessageBox.Show("Vous devez sélectionner 3 joueurs !", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You need to select 3 favorite players!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.None;
            }
            else
            {
                canClose = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //gets the fifa code of the selected team
            GetTeamPreference();
            string fifaCode = State.FifaCode;

            //Changes the enabled panel
            pnlCountry.Enabled = false;
            pnlContainer2.Enabled = true;

            //Loads the players through the matches
            LoadMatches(fifaCode);

        }

        private async Task LoadCountries()
        {
            LoadingUC loadingUC = ShowLoading();
            Country[] countriesData = null;
            int tries = 0;

            while (countriesData == null && tries < 5)
            {
                try
                {
                    if (State.IsLocal == "0")
                        countriesData = await RequestController.GetCountriesData(State.Championship);
                    else
                        countriesData = RequestController.GetJsonCountries(State.Championship);
                }
                catch
                {
                }
            }

            if (countriesData == null)
            {
                MessageBox.Show(Resources.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var country in countriesData)
            {
                cbCountries.Items.Add($"{country.Name} ({country.FifaCode})");
            }

            // Select the first item
            cbCountries.SelectedIndex = 0;


            StopLoading(loadingUC);
        }

        /*
         * returns the fifa code of the selected team
         */
        public void GetTeamPreference()
        {
            string[] selected = cbCountries.SelectedItem.ToString().Split(" (");
            var temp = selected[1].Split(")");
            State.FifaCode = temp[0]; //fifa code
        }

        /*
         * fetches countries' data from the DAL
         */



        private async void LoadMatches(string fifaCode)
        {
            LoadingUC loadingUC = ShowLoading();

            Match[] matchesData;
            try
            {
                //Gets matches from the API played by the selected team
                if (State.IsLocal == "0")
                    matchesData = await RequestController.GetMatchesData(State.Championship, State.FifaCode);
                else
                    matchesData = RequestController.GetJsonMatches(State.Championship, State.FifaCode);
            }
            catch
            {
                MessageBox.Show(Resources.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (matchesData == null)
            {
                MessageBox.Show(Resources.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Gets all playerUCs from the matches and adds them to the "all players" FlowLayoutPanel
            PlayerUC playerUC;

            Team team = MatchRepository.GetTeamFromMatch(matchesData[0], fifaCode);
            foreach (var player in team.StartingPlayers)
            {
                playerUC = new PlayerUC(player, State.Language);
                PlayerUCInitialize(playerUC);

            }
            foreach (var player in team.Substitutes)
            {
                playerUC = new PlayerUC(player, State.Language);
                PlayerUCInitialize(playerUC);
            }
            StopLoading(loadingUC);
        }



        /*
         * Adds event handlers, the ContextMenuStrip 
         * !and load the new PlayerUC in the AllPlayers FlowLayoutPanel
         */
        private void PlayerUCInitialize(PlayerUC playerUC)
        {
            playerUC.MouseDown += PlayerUC_MouseDown;
            playerUC.DragEnter += PlayerUC_DragEnter;
            playerUC.DragDrop += PlayerUC_DragDrop;

            foreach (Control control in playerUC.Controls)
            {
                control.MouseDown += PlayerUC_MouseDown;
                control.DragEnter += PlayerUC_DragEnter;
                control.DragDrop += PlayerUC_DragDrop;
            }
            playerUC.ContextMenuStrip = cmsFromAllPlayers;
            flpAllPlayers.Controls.Add(playerUC);
        }




        private void cmsiAddFavorite_Click(object sender, EventArgs e)
        {
            var playerUC = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PlayerUC;
            AddTo(playerUC, flpAllPlayers, flpFavPlayers, cmsFromFavoritePlayers, true);
        }

        private void UpdateLabels()
        {
            int favCount = flpFavPlayers.Controls.Count;
            lbCountFav.Text = $"{favCount}/3";
            if (favCount > 3)
            {
                lbError.Visible = true;
                lbCountFav.ForeColor = Color.Red;
            }
            else
            {
                lbError.Visible = false;
                if (favCount < 3)
                {
                    lbCountFav.ForeColor = Color.Red;
                }
                else
                {
                    lbCountFav.ForeColor = Color.Green;
                }
            }

        }

        private void cmsiAddAllPlayers_Click(object sender, EventArgs e)
        {
            var playerUC = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PlayerUC;
            AddTo(playerUC, flpFavPlayers, flpAllPlayers, cmsFromAllPlayers, false);

        }

        private void AddTo(PlayerUC playerUC, FlowLayoutPanel fromFlp, FlowLayoutPanel toFlp, ContextMenuStrip newCms, bool favVisible)
        {
            if (!SelectedPlayers.Contains(playerUC))
            {
                SelectedPlayers.Add(playerUC);
            }


            foreach (PlayerUC pUC in SelectedPlayers)
            {
                if (!toFlp.Controls.Contains(pUC))
                {
                    fromFlp.Controls.Remove(pUC);
                    pUC.ContextMenuStrip = newCms;
                    pUC.BackColor = Color.FromArgb(192, 255, 192);
                    pUC.SetFavorite(favVisible);
                    toFlp.Controls.Add(pUC);

                }
                else
                {
                    pUC.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
            SelectedPlayers.Clear();
            UpdateLabels();
        }

        public void PlayerUC_MouseDown(object? sender, EventArgs e)
        {
            PlayerUC pUC;
            if (sender is PlayerUC)
                pUC = (PlayerUC)sender;
            else
            {
                pUC = ((Control)sender).Parent as PlayerUC;
            }

            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (pUC.DoDragDrop(pUC, DragDropEffects.Move) == DragDropEffects.None)
                {
                    PlayerUC_Click(pUC, e);
                }
                /*else
                {
                    DragDropEffects x = pUC.DoDragDrop(pUC, DragDropEffects.Move);
                    if (x == DragDropEffects.None)
                        PlayerUC_Click(pUC, e);
                }*/
            }
            else
            {
                pUC.ContextMenuStrip.Show();
            }

        }

        public void PlayerUC_DragDrop(object sender, DragEventArgs e)
        {
            PlayerUC playerUC = (PlayerUC)e.Data.GetData(typeof(PlayerUC));

            /*playerUC.AllowDrop = true;
            foreach (Control control in playerUC.Controls)
            {
                control.DragEnter += PlayerUC_DragEnter;
                control.DragOver += PlayerUC_DragDrop;
            }*/

            if (sender is PlayerUC)
            {
                if ((PlayerUC)sender == playerUC)
                {
                    PlayerUC_Click(playerUC, e);
                    e.Effect = DragDropEffects.None;
                    return;
                }

                if (flpFavPlayers.Contains((PlayerUC)sender))
                {
                    AddTo(playerUC, flpAllPlayers, flpFavPlayers, cmsFromFavoritePlayers, true);
                }
                else
                {
                    AddTo(playerUC, flpFavPlayers, flpAllPlayers, cmsFromAllPlayers, false);
                }
            }
            else //sender is FlowLayoutPanel
            {
                if (((FlowLayoutPanel)sender).Tag.ToString() == "Fav")
                {
                    if (!flpFavPlayers.Contains(playerUC))
                        AddTo(playerUC, flpAllPlayers, flpFavPlayers, cmsFromFavoritePlayers, true);
                    else
                    {
                        PlayerUC_Click(playerUC, e);
                    }
                }
                else
                {
                    if (!flpAllPlayers.Contains(playerUC))
                        AddTo(playerUC, flpFavPlayers, flpAllPlayers, cmsFromAllPlayers, false);
                    else
                    {
                        PlayerUC_Click(playerUC, e);
                    }
                }
            }

        }

        public void PlayerUC_DragEnter(object sender, DragEventArgs e)
        {
            var playerUC = (PlayerUC)e.Data.GetData(typeof(PlayerUC));
            if (sender is PlayerUC && playerUC == (PlayerUC)sender)
            {
                e.Effect = DragDropEffects.None;
            }

            else
            {
                e.Effect = DragDropEffects.Move;
            }

        }

        private static void PlayerUC_Click(object sender, EventArgs e)
        {
            PlayerUC playerUC = sender as PlayerUC;

            if (playerUC.BackColor == Color.Plum)
            {
                playerUC.BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                playerUC.BackColor = Color.Plum;
                SelectedPlayers.Add(playerUC);
            }
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

        public void GetSettings()
        {
            GetTeamPreference();

            int i = 0;
            foreach (PlayerUC player in flpFavPlayers.Controls.OfType<PlayerUC>())
            {
                State.FavPlayers[i] = player.GetName();
                i++;
            }

        }

        public void DisableCancel()
        {
            btnCancel.Enabled = false;
        }

        private void teamChooserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose)
            {
                State.FavPlayers = new string[3];
                int i = 0;
                foreach (PlayerUC player in flpFavPlayers.Controls)
                {
                    State.FavPlayers[i] = player.GetName();
                    i++;
                }
                return;
            }

            CloseForm closeForm = new CloseForm(State.Language);
            if (closeForm.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        internal void DisableCountry()
        {
            for (int i = 0; i < cbCountries.Items.Count; i++)
            {
                if (cbCountries.Items[i].ToString().Contains(State.FifaCode))
                {
                    cbCountries.SelectedIndex = i;
                    i = cbCountries.Items.Count;
                    btnConfirm.PerformClick();
                }
            }
        }
    }
}
