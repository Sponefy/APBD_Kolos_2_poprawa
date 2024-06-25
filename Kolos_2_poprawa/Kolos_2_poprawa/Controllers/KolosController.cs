using Kolos_1_poprawa.Dtos;
using Kolos_2_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos_2_poprawa.Controllers;


[ApiController]
[Route("api/clients")]
public class KolosController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public KolosController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    
    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var result = await _rentalService.GetClient(clientId);

        if (result == null)
        {
            return BadRequest("Client does not exist");
        }

        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddRental(AddRentalDto rentalDto)
    {
        var result = await _rentalService.AddRental(rentalDto);

        if (result == 0)
        {
            return BadRequest("Auto o takim Id nie istnieje");
        }
        
        return Ok();
    }
    
}