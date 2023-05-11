using Microsoft.AspNetCore.Mvc;
using BetterRxSolution.Models;
using BetterRxSolution.Services;

namespace BetterRxSolution.Controllers;

[ApiController]
[Route("[controller]")]
public class NpiRegistryController : ControllerBase
{
    private readonly INpiRegistryService _npiRegistryService;


    public NpiRegistryController(INpiRegistryService npiRegistryService)
    {
        _npiRegistryService = npiRegistryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(
        string firstName = null,
        string lastName = null,
        string taxonomyDescription = null,
        string city = null,
        string state = null,
        int zip = 0)
    {
        try
        {
            var providers = await _npiRegistryService.GetProviders(firstName,
            lastName,
            taxonomyDescription,
            city,
            state,
            zip);

            return Ok(providers);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
