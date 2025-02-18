using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineyardAPI.Interfaces.Services;
using VineyardAPI.Services;

namespace VineyardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        private IGrapeService _grapeService;

        public GrapesController(IGrapeService grapeService)
        {
            _grapeService = grapeService;
        }

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
}
