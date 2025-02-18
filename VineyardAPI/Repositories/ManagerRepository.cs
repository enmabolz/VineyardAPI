using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Models;

namespace VineyardAPI.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly VineyardContext _context;

        public ManagerRepository(VineyardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync()
        {
            var administratedAreaByManager = await _context.Managers
                .Include (m => m.Parcels)
                .Select(m => new
                {
                    ManagerName = m.Name,
                    TotalArea = m.Parcels.Sum(p => p.Area)  
                })
                .ToDictionaryAsync(m => m.ManagerName, m => m.TotalArea);  

            return administratedAreaByManager;
        }
    }
}
