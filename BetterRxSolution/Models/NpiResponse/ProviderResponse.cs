using System;
using Newtonsoft.Json;

namespace BetterRxSolution.Models.NpiResponse
{
    public class ProviderResponse
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("results")]
        public List<ProviderResult> Results { get; set; }
    }
}
