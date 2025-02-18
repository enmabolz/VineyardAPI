using VineyardAPI.Models.Entities;

namespace VineyardAPI.Repositories.Interfaces;

public interface IManagerRepository
{
    Task<IEnumerable<Manager>> GetAllManagersWithoutParcelsAsync();
    Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();

}

