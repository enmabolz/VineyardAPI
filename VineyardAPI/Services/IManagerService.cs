using VineyardManager.Models;

namespace VineyardManager._Services
{
    public interface IManagerService
    {
        Task<IEnumerable<int>> GetIdsOfManagersAsync(); 
        Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted);

    }
}
