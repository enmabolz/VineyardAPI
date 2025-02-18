using VineyardAPI.Models;

namespace VineyardAPI.Interfaces.Repositories
{
    public interface IGrapeRepository
    {
        Task<IEnumerable<Grape>> GetAllGrapesAsync();
        Task<Dictionary<string, int>> GetTotalAreaByGrapeAsync();
    }
}
