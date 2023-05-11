using System;
using BetterRxSolution.Models;


namespace BetterRxSolution.Services
{
	public interface INpiRegistryService
	{
        Task<IEnumerable<Provider>> GetProviders(string firstName,
            string lastName,
            string taxonomyDescription,
            string city,
            string state,
            int zip);
    }
}
