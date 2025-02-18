namespace VineyardAPI.Interfaces.Services
{
    public interface IGrapeService
    {
        Task<Dictionary<string, int>> GetAreaByGrapeAsync();
    }
}
