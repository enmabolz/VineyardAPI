using VineyardAPI.Models;

namespace VineyardAPI.Interfaces.Services
{
    public interface IManagerService
    {
        Task<IEnumerable<int>> GetIdsOfManagersAsync();
        Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted);
        Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();
    }
}
