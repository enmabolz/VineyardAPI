using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Interfaces.Services;
using VineyardAPI.Models;

namespace VineyardAPI.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;

        public ParcelService(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<Dictionary<string, int>> GetAreaByGrapeAsync()
        {
            var parcels = await _parcelRepository.GetAllParcelsAsync();

            var area = parcels
                .GroupBy(p => p.Grape.Name)
                .Select(g => new
                {
                    Grape = g.Key,
                    TotalArea = g.Sum(p => p.Area)
                })
                .ToDictionary(g => g.Grape, g => g.TotalArea);

            return area;
        }
    }
}
