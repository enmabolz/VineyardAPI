namespace VineyardAPI.Interfaces.Services
{
    public interface IVineyardService
    {
        Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync();
    }
}
