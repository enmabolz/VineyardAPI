namespace VineyardAPI.Repositories.Interfaces;

public interface IVineyardRepository
{
    Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync();
}
