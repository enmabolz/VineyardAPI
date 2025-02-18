using VineyardAPI.Models;

namespace VineyardAPI.Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
    }
}
