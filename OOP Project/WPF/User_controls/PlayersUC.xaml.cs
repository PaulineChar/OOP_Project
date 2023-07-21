using DAL.Models;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF.User_controls
{
	/// <summary>
	/// Interaction logic for PlayersUC.xaml
	/// </summary>
	public partial class PlayersUC : UserControl
	{
        private const string PICTURE_PATH = "../../../Properties/Images/";

        public string position { get; }
		public string name { get; }
		public long shirtnumber { get; }
		public bool captain { get; }

		public PlayersUC(long shirtNumber, string name, string position, bool captain, bool selected)
		{
			InitializeComponent();
			lbShirtNumber.Content = shirtNumber.ToString();
			lbName.Text = name;
			this.name = name;
			this.shirtnumber = shirtNumber;
			this.position = position;
			this.captain = captain;
			if(selected)
			{
				borderUC.BorderBrush = Brushes.LightBlue;
				gridUC.Background = Brushes.LightBlue;
                lbShirtNumber.Foreground = Brushes.LightBlue;
			}
            if (File.Exists(PICTURE_PATH + name + ".png"))
            {
                imagePlayer.Source = new BitmapImage(
                    new Uri($"{PICTURE_PATH}{name}.png", UriKind.Relative));
            }
        }

		internal void ChangeColor(bool isSelected)
		{
			if(isSelected)
			{
				borderUC.BorderBrush = Brushes.LightBlue;
				gridUC.Background = Brushes.LightBlue;
				lbShirtNumber.Foreground = Brushes.LightBlue;
			}
			else
			{
				borderUC.BorderBrush = Brushes.IndianRed;
				gridUC.Background = Brushes.IndianRed;
				lbShirtNumber.Foreground = Brushes.IndianRed;
			}
		}

		public bool IsSelected()
		{
			return gridUC.Background == Brushes.LightBlue;
		}
	}
}
