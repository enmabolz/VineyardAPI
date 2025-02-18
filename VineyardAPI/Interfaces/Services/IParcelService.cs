using VineyardAPI.Models;

namespace VineyardAPI.Interfaces.Services
{
    public interface IParcelService
    {
        Task<Dictionary<string, int>> GetAreaByGrapeAsync();
    }
}
