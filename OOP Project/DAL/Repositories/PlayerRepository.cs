using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlayerRepository
    {
        public static List<Player> ExtractPlayersFromMatch(Match match, string fifaCode)
        {
            Team team = MatchRepository.GetTeamFromMatch(match, fifaCode);
            List<Player> players = team.StartingPlayers.ToList();
            foreach (Player player in team.Substitutes)
            {
                players.Add(player);
            }

            return players;
        }

        public static List<Player> GetAndUpdatePlayersFromMatches(Match[] matches, string fifaCode)
        {
            //Get players
            List<Player> players = ExtractPlayersFromMatch(matches[0], fifaCode);
            List<Player> appeardInTheMatch;
            Team team = MatchRepository.GetTeamFromMatch(matches[0], fifaCode);

            //Update players
            PlayEvent[] playEvents;
            foreach (Match match in matches)
            {
                appeardInTheMatch = team.StartingPlayers.ToList();
                //starting players
                foreach(Player pl in appeardInTheMatch)
                {
                    var p = players.First(x => x.Name == pl.Name);
                    p.appearances++;
                }

                //goals, yellow cards and substitutions "in"
                playEvents = MatchRepository.GetPlayEventFromMatch(match, fifaCode);
                foreach(var playEvent in  playEvents)
                {
                    if(playEvent.Type.Contains("goal"))
                    {
                        var p = players.First(p => p.Name == playEvent.PlayerName);
                        p.goals++;
                    }
                    else if(playEvent.Type == "yellow-card")
                    {
                        var p = players.First(p => p.Name == playEvent.PlayerName);
                        p.yellowCards++;
                    }
                    else if(playEvent.Type == "substitution-in")
                    {
                        var p = players.First(p => p.Name == playEvent.PlayerName);
                        if (!appeardInTheMatch.Contains(p))
                        {
                            p.appearances++;
                            appeardInTheMatch.Add(p);
                        }
                    }
                }

                
            }

            return players;
        }
    }
}
