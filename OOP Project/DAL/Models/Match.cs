using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Match
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("home_team")]
        public Country HomeTeamCode { get; set; }

        [JsonProperty("away_team")]
        public Country AwayTeamCode { get; set; }

        [JsonProperty("home_team_statistics")]
        public Team HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public Team AwayTeamStatistics { get; set; }

        [JsonProperty("home_team_events")]
        public PlayEvent[] HomeTeamEvent { get; set; }

        [JsonProperty("away_team_events")]
        public PlayEvent[] AwayTeamEvent { get; set; }
        

    }
}
