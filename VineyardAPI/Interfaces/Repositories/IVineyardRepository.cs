namespace VineyardAPI.Interfaces.Repositories
{
    public interface IVineyardRepository
    {
        Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync();
    }
}
