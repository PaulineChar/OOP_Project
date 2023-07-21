using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PlayEvent
    {
        [JsonProperty("type_of_event")]
        public string Type { get; set; }

        [JsonProperty("player")]
        public string PlayerName { get; set; }
    }
}
