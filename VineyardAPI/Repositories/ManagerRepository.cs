using Microsoft.EntityFrameworkCore;
using VineyardManager.Data;
using VineyardManager.Models;

namespace VineyardManager.Repositories
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
