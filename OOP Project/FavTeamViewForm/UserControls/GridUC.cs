using DAL.Models;
using DAL.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Windows_Forms.Properties;

namespace UI_Windows_Forms
{
    public partial class GridUC : UserControl
    {
        string PICTURE_PATH = "../../../../DAL/Images/";

        public GridUC()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(State.Language);
            InitializeComponent();
            lbName.BringToFront();
        }

        #region Getters and setters
        public int GetGoals()
            => int.Parse(lbGoal.Text);

        public int GetYellowCards()
            => int.Parse(lbYellowCard.Text);

        public void SetRank(int i)
            => lbRank.Text = i.ToString();


        #endregion
        public void CreateHeader()
        {
            this.Size = new Size(Width, 40);

            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            BackColor = Color.LightBlue;
        }



        public void CreateRow(Player player)
        {
            if (player.Captain)
            {
                pbCaptain.Visible = true;
            }

            if (player.Favorite)
            {
                pbFavorite.Visible = true;
                BackColor = Color.LemonChiffon;
            }

            lbName.Text = player.Name;
            lbAppearance.Text = player.appearances.ToString();
            lbGoal.Text = player.goals.ToString();
            lbYellowCard.Text = player.yellowCards.ToString();
            lbNumber.Text = $"N°{player.ShirtNumber}";

            //picture
            if (File.Exists(PICTURE_PATH + player.Name + ".jpg"))
            {
                pbPicture.Image = Image.FromFile(PICTURE_PATH + player.Name + ".jpg");
            }
        }
    }
}
