namespace VineyardAPI.Services.Interfaces;

public interface IManagerService
{
    Task<IEnumerable<int>> GetIdsOfManagersAsync();
    Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted);
    Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync();
}
