using System;
using BetterRxSolution.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BetterRxSolution.Services
{
	public class NpiRegistryService : INpiRegistryService
	{
        private readonly IHttpClientFactory _clientFactory;

        public NpiRegistryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Provider>> GetProviders(
            string firstName,
            string lastName,
            string taxonomyDescription,
            string city,
            string state,
            int zip)
        {
            var baseUrl = "https://npiregistry.cms.hhs.gov/api/?number=&enumeration_type=&use_first_name_alias=&organization_name=&address_purpose=&country_code=&limit=50&skip=&version=2.1";
            var url = baseUrl;

            if (!string.IsNullOrEmpty(firstName))
                url += $"&first_name={firstName}";
            if (!string.IsNullOrEmpty(lastName))
                url += $"&last_name={lastName}";
            if (!string.IsNullOrEmpty(taxonomyDescription))
                url += $"&taxonomy_description={taxonomyDescription}";
            if (!string.IsNullOrEmpty(city))
                url += $"&city={city}";
            if (!string.IsNullOrEmpty(state))
                url += $"&state={state}";
            if (zip != 0)
                url += $"&postal_code={zip}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                if (responseStream.Contains("Errors"))
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseStream);

                    throw new ArgumentException(errorResponse.Errors?[0].Description);
                }

                var data = JsonConvert.DeserializeObject<IEnumerable<Provider>>(responseStream);
                return data;
            }

            return null;
        }
    }
}

