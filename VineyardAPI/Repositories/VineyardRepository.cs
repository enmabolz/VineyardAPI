using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Repositories.Interfaces;

namespace VineyardAPI.Repositories;

public class VineyardRepository(VineyardContext _context) : IVineyardRepository
{
    public async Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync()
    {
        var vineyardsWithManagers = await _context.Vineyards
                .Include(v => v.Parcels)
                .ThenInclude(p => p.Manager)
                .Select(v => new
                {
                    VineyardName = v.Name,
                    Managers = v.Parcels.Select(p => p.Manager.Name).Distinct().OrderBy(m => m).ToList()
                })
                .ToDictionaryAsync(v => v.VineyardName, v => v.Managers);

        return vineyardsWithManagers;
    }
}

