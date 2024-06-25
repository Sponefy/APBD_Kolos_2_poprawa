using Kolos_2_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos_2_poprawa.Controllers;


[ApiController]
[Route("api/kolos")]
public class KolosController : ControllerBase
{
    private readonly IKolosService _kolosService;

    public KolosController(IKolosService kolosService)
    {
        _kolosService = kolosService;
    }
    
    
    
}