using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers;

[Route("api/v1/[controller]s")]
[ApiController]
public class StartController : ControllerBase
{
    public StartController()
    {
        
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok("Selam Dünyalı");
    }
}
