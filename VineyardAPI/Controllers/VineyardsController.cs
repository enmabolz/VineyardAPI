using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineyardAPI.Interfaces.Services;

namespace VineyardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VineyardsController : ControllerBase
    {
        private readonly IVineyardService _vineyardService;

        public VineyardsController(IVineyardService vineyardService)
        {
            _vineyardService = vineyardService;
        }

        [HttpGet("managers")]
        public async Task<IActionResult> GetVineyardsWithManagersAsync()
        {
            try
            {
                var vineyardsWithManagers = await _vineyardService.GetVineyardsWithManagersAsync();

                return Ok(vineyardsWithManagers);
            } catch (Exception ex) 
            { 
                return StatusCode(500, new { message = ex.Message }); 
            }
        }
    }
}
