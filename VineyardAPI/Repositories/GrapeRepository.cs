using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Models;
using VineyardAPI.Repositories.Interfaces;

namespace VineyardAPI.Repositories;

public class GrapeRepository(VineyardContext _context) : IGrapeRepository
{
    public async Task<IEnumerable<Grape>> GetAllGrapesAsync()
        => await _context.Grapes.ToListAsync();
    
    public async Task<Dictionary<string, int>> GetTotalAreaByGrapeAsync()
    {
        var areas = await _context.Grapes
            .Include(g => g.Parcels)
            .Select(g => new
            {
                GrapeName = g.Name,
                TotalArea = g.Parcels.Sum(p => p.Area)
            })
            .ToDictionaryAsync(g => g.GrapeName, g => g.TotalArea);

        return areas;
    }
}

