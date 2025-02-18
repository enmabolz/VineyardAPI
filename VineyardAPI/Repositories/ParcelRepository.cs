using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Models;

namespace VineyardAPI.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly VineyardContext _context;

        public ParcelRepository(VineyardContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Parcel>> GetAllParcelsAsync()
        {
            return await _context.Parcels.ToListAsync();
        }
    }
}
