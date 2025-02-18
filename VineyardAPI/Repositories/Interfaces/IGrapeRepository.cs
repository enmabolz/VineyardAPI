using VineyardAPI.Models;

namespace VineyardAPI.Repositories.Interfaces;
public interface IGrapeRepository
{
    Task<IEnumerable<Grape>> GetAllGrapesAsync();
    Task<Dictionary<string, int>> GetTotalAreaByGrapeAsync();
}

