using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MatchRepository
    {
        public static Team GetTeamFromMatch(Match match, string fifaCode)
        {
            if (match.HomeTeamCode.FifaCode == fifaCode)
            {
                return match.HomeTeamStatistics;
            }
            return match.AwayTeamStatistics;
        }

        public static PlayEvent[] GetPlayEventFromMatch(Match match, string fifaCode)
        {
            
            if (match.HomeTeamCode.FifaCode == fifaCode)
            {
                return match.HomeTeamEvent;
            }
            return match.AwayTeamEvent;
            
        }


        
		public static List<int> GetAllInfo(Match[] matches, string fifaCode)
		{
            int wins = 0;
            int losses = 0;
            int goalsScored = 0;
            int goalsConceded = 0;

            foreach(var match in matches)
            {
                if(match.HomeTeamCode.FifaCode.Equals(fifaCode))
                {
					goalsScored += match.HomeTeamCode.Goals;
					goalsConceded += match.AwayTeamCode.Goals;
					if (match.AwayTeamCode.Goals > match.HomeTeamCode.Goals)
						losses++;
					else if (match.AwayTeamCode.Goals < match.HomeTeamCode.Goals)
						wins++;
				}
                else
                {
					goalsScored += match.AwayTeamCode.Goals;
					goalsConceded += match.HomeTeamCode.Goals;
					if (match.AwayTeamCode.Goals > match.HomeTeamCode.Goals)
						wins++;
					else if (match.AwayTeamCode.Goals < match.HomeTeamCode.Goals)
						losses++;
				}
            }

            return new() { wins, losses,  goalsScored, goalsConceded };
		}
	}
}
