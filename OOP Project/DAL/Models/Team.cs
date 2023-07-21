using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Team
    {
        [JsonProperty("starting_eleven")]
        public Player[] StartingPlayers { get; set; }

        [JsonProperty("substitutes")]
        public Player[] Substitutes { get; set; }
            
    }
}
