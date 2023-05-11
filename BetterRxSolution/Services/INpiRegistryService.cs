using System;
using BetterRxSolution.Models.NpiResponse;


namespace BetterRxSolution.Services
{
	public interface INpiRegistryService
	{
        Task<ProviderResponse> GetProviders(string firstName,
            string lastName,
            string taxonomyDescription,
            string city,
            string state,
            int zip);
    }
}
