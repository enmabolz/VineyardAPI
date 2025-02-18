using Microsoft.AspNetCore.Mvc;
using VineyardAPI.Services.Interfaces;

namespace VineyardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GrapesController(IGrapeService _grapeService) : ControllerBase
{
    [HttpGet("area")]
    public async Task<IActionResult> GetAreaByGrapesAsync()
    {
        try
        {
            var areas = await _grapeService.GetAreaByGrapeAsync();

            return Ok(areas);
        } catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }  
    }
}
