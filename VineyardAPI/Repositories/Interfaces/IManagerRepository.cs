using VineyardAPI.Models;

namespace VineyardAPI.Repositories.Interfaces;

public interface IManagerRepository
{
    Task<IEnumerable<Manager>> GetAllManagersAsync();
    Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();

}

