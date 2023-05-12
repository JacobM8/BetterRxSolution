using System;
using Newtonsoft.Json;

namespace BetterRxSolution.Models.NpiResponse
{
    public class Basic
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("credential")]
        public string Credential { get; set; }

        [JsonProperty("sole_proprietor")]
        public string SoleProprietor { get; set; }
    }
}
