using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Models;

namespace VineyardAPI.Repositories
{
    public class GrapeRepository : IGrapeRepository
    {
        private readonly VineyardContext _context;

        public GrapeRepository(VineyardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grape>> GetAllGrapesAsync()
        {
            return await _context.Grapes.ToListAsync();
        }

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
}
