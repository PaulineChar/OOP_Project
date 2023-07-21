using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Windows_Forms.Properties;

namespace UI
{
	public partial class PlayerUC : UserControl
	{
		string PICTURE_PATH = "../../../../DAL/Images/";
		Player _player;
		public PlayerUC(Player player, string language)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

			_player = player;
			InitializeComponent();
			UpdatePlayerUC();
		}

		internal string GetName()
		{
			return lbName.Text;
		}

		internal void SetFavorite(bool favVisible)
		{
			pbFav.Visible = favVisible;
		}

		private void UpdatePlayerUC()
		{
			//captain
			if (_player.Captain)
				pbCaptain.Visible = true;

			//number
			lbNumber.Text = _player.ShirtNumber.ToString();

			//name
			lbName.Text = _player.Name;

			//position
			switch (_player.Position)
			{
				case "Midfield":
					lbPosition.Text = Resources.Midfield;
					break;
				case "Goalie":
					lbPosition.Text = Resources.Goalie;
					break;
				case "Forward":
					lbPosition.Text = Resources.Forward;
					break;
				case "Defender":
					lbPosition.Text = Resources.Defender;
					break;
			}

			//picture
			if (File.Exists(PICTURE_PATH + _player.Name + ".jpg"))
			{
				pbPlayer.Image = Image.FromFile(PICTURE_PATH + _player.Name + ".jpg");
			}

		}


	}
}
