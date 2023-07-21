using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Country
    {
        [JsonProperty("country")]
        public string Name { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        //Matches don't give the same JsonProperty name for the fifaCode
        [JsonProperty("code")]
        private string Code { set { FifaCode = value; } }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        public override string ToString()
        {
            return $"{Name} ({FifaCode})";
        }
    }
}
