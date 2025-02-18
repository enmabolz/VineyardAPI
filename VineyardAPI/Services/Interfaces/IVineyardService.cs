namespace VineyardAPI.Services.Interfaces;

public interface IVineyardService
{
    Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync();
}
