using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
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
    }
}
