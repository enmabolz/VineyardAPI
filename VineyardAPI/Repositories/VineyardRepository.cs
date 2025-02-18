using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Interfaces.Repositories;

namespace VineyardAPI.Repositories
{
    public class VineyardRepository : IVineyardRepository
    {
        private readonly VineyardContext _context;

        public VineyardRepository(VineyardContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync()
        {
            var vineyardsWithManagers = await _context.Vineyards
                    .Include(v => v.Parcels)
                    .ThenInclude(p => p.Manager) 
                    .Select(v => new
                    {
                        VineyardName = v.Name,
                        Managers = v.Parcels.Select(p => p.Manager.Name).Distinct().OrderBy(m => m).ToList()                     })
                    .ToDictionaryAsync(v => v.VineyardName, v => v.Managers);

            return vineyardsWithManagers;
        }
    }
}
