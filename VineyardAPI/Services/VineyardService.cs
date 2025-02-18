using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Interfaces.Services;

namespace VineyardAPI.Services
{
    public class VineyardService : IVineyardService
    {
        private readonly IVineyardRepository _vineyardRepository;

        public VineyardService(IVineyardRepository vineyardRepository) 
        {
            _vineyardRepository = vineyardRepository;
        }

        public async Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync()
        {
            return await _vineyardRepository.GetVineyardsWithManagersAsync();
        }
    }
}
