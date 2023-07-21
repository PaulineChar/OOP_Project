using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Windows_Forms.UserControllers
{
	public partial class MatchUC : UserControl
	{
		public MatchUC()
		{
			InitializeComponent();
		}

		#region Getter

		internal int GetAttendance()
			=> int.Parse(lbVisitors.Text);

		#endregion

		public void UpdateRow(Match match)
		{
			lbLocation.Text = match.Location;
			lbVisitors.Text = match.Attendance.ToString();
			lbHomeTeam.Text = $"{match.HomeTeamCode.Name} - {match.HomeTeamCode.FifaCode}";
			lbAwayTeam.Text = $"{match.AwayTeamCode.Name} - {match.AwayTeamCode.FifaCode}";
		}

		public void CreateHeader()
		{
			lbLocation.BackColor = lbHomeTeam.BackColor = Color.DarkGray;
			lbVisitors.BackColor = lbAwayTeam.BackColor = Color.Silver;
		}
	}
}
