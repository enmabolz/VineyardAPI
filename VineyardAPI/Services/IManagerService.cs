using VineyardManager.Models;

namespace VineyardManager._Services
{
    public interface IManagerService
    {
        Task<IEnumerable<Guid>> GetIdsOfManagersAsync(); 
        Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted);

    }
}
