using VineyardAPI.Models;

namespace VineyardAPI.Interfaces.Repositories
{
    public interface IParcelRepository
    {
        Task<IEnumerable<Parcel>> GetAllParcelsAsync();
    }
}
