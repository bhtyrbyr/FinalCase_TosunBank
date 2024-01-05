using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/v1/[controller]s")]
[ApiController]
public class StartController : ControllerBase
{
    public StartController()
    {
        
    }

    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok("Selam Dünyalı");
    }
}
