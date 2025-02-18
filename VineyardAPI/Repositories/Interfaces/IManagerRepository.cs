using VineyardAPI.Models.Entities;

namespace VineyardAPI.Repositories.Interfaces;

public interface IManagerRepository
{
    Task<IEnumerable<Manager>> GetAllManagersAsync();
    Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();

}

