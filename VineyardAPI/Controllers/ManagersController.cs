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
            var managerIds = await _managerService.GetIdsOfManagersAsync();

            return Ok(managerIds);
        }

        [HttpGet("taxnumbers")]
        public async Task<IActionResult> GetAllTaxNunmbersFromManagersAsync([FromQuery] bool sorted)
        {
            var taxNumbers = await _managerService.GetTaxNumbersOrderedAsync(sorted);

            return Ok(taxNumbers);
        }

        [HttpGet("totalarea")]
        public async Task<IActionResult> GetManagersTotalAdministratedAreaAsync()
        {
            var administratedAreaByManager = await _managerService.GetManagersTotalAdministratedAreaAsync();

            return Ok(administratedAreaByManager);
        }

    }
}
