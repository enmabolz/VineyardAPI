﻿using Microsoft.AspNetCore.Mvc;
using VineyardAPI.Services.Interfaces;

namespace VineyardAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VineyardsController(IVineyardService _vineyardService) : ControllerBase
{
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
