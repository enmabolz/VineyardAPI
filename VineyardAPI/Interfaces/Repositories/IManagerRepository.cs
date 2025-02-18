using VineyardAPI.Models;

namespace VineyardAPI.Interfaces.Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();

    }
}
