using System;
using Newtonsoft.Json;

namespace BetterRxSolution.Models.NpiResponse
{
    public class ProviderResult
    {
        [JsonProperty("created_epoch")]
        public string CreatedEpoch { get; set; }

        [JsonProperty("enumeration_type")]
        public string EnumerationType { get; set; }

        [JsonProperty("last_updated_epoch")]
        public string LastUpdatedEpoch { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }

        [JsonProperty("practiceLocations")]
        public List<object> PracticeLocations { get; set; }

        [JsonProperty("basic")]
        public Basic Basic { get; set; }
    }
}
