using Microsoft.EntityFrameworkCore;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Interfaces.Services;

namespace VineyardAPI.Services
{
    public class GrapeService : IGrapeService
    {
        
        private readonly IGrapeRepository _grapeRepository;

        public GrapeService(IGrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        public async Task<Dictionary<string, int>> GetAreaByGrapeAsync()
        {
            var areas = await _grapeRepository.GetTotalAreaByGrapeAsync();

           
            return areas;
        }
    }
}
