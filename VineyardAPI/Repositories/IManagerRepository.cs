using VineyardManager.Models;

namespace VineyardManager.Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync();
    }
}
