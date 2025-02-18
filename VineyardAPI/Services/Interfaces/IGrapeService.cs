namespace VineyardAPI.Services.Interfaces;

public interface IGrapeService
{
    Task<Dictionary<string, int>> GetAreaByGrapeAsync();
}
