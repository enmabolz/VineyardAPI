using VineyardAPI.Models.Entities;

namespace VineyardAPI.Repositories.Interfaces;
public interface IGrapeRepository
{
    Task<IEnumerable<Grape>> GetAllGrapesWithoutIncludedParcelsAsync();
    Task<Dictionary<string, int>> GetTotalAreaByGrapeAsync();
}

