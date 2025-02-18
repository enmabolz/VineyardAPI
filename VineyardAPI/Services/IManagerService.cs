using VineyardAPI.Models;

namespace VineyardAPI.Services
{
    public interface IManagerService
    {
        Task<IEnumerable<int>> GetIdsOfManagersAsync();
        Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted);

    }
}
