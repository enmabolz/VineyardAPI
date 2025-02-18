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
            try
            {
                var areas = await _grapeRepository.GetTotalAreaByGrapeAsync();

                return areas;
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem with the database or the Server.", ex);
            }
        }
    }
}
