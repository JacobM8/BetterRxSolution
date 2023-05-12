using System;
using Newtonsoft.Json;

namespace BetterRxSolution.Models.NpiResponse
{
    public class Address
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("address_purpose")]
        public string AddressPurpose { get; set; }

        [JsonProperty("address_type")]
        public string AddressType { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("telephone_number")]
        public string TelephoneNumber { get; set; }
    }
}
