using System;
using System.Text.Json.Serialization;

namespace BetterRxSolution.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("Errors")]
        public List<Error>? Errors { get; set; }
    }


    public class Error
	{
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("field")]
        public string? Field { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }
}

