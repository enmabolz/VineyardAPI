using VineyardAPI.Models;

namespace VineyardAPI.Repositories
{
    public interface IGrapeRepository
    {
        Task<IEnumerable<Grape>> GetAllGrapesAsync(); 
    }
}
