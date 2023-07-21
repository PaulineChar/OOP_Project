using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.State
{
	public static class State
	{
		public static string Language { get; set; } = "";
		public static string Championship { get; set; } = "";
		public static string FifaCode { get; set; } = "";
		public static string[] FavPlayers { get; set; } = new string[3] { "", "", "" };
		public static string DisplayMode { get; set; } = "";
		public static string IsLocal { get; set; } = "1";
	}
}
