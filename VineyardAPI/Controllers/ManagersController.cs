using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineyardAPI.Interfaces.Services;

namespace VineyardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("ids")]
        public async Task<IActionResult> GetAllIdsOfManagersAsync()
        {
            try
            {
                var managerIds = await _managerService.GetIdsOfManagersAsync();

                return Ok(managerIds);
            } catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
            
        }

        [HttpGet("taxnumbers")]
        public async Task<IActionResult> GetAllTaxNunmbersFromManagersAsync([FromQuery] bool sorted)
        {
            try
            {
                var taxNumbers = await _managerService.GetTaxNumbersOrderedAsync(sorted);

                return Ok(taxNumbers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet("totalarea")]
        public async Task<IActionResult> GetManagersTotalAdministratedAreaAsync()
        {
            try
            {
                var administratedAreaByManager = await _managerService.GetManagersTotalAdministratedAreaAsync();

                return Ok(administratedAreaByManager);

            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
         }

    }
}
