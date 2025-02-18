using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Models.Entities;
using VineyardAPI.Repositories.Interfaces;

namespace VineyardAPI.Repositories;

public class ManagerRepository(VineyardContext _context) : IManagerRepository
{
    public async Task<IEnumerable<Manager>> GetAllManagersAsync()
        => await _context.Managers.ToListAsync();
    

    public async Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync()
    {
        var administratedAreaByManager = await _context.Managers
            .Include(m => m.Parcels)
            .Select(m => new
            {
                ManagerName = m.Name,
                TotalArea = m.Parcels.Sum(p => p.Area)
            })
            .ToDictionaryAsync(m => m.ManagerName, m => m.TotalArea);

        return administratedAreaByManager;
    }

}
