using VineyardAPI.Repositories;

namespace VineyardAPI.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<IEnumerable<int>> GetIdsOfManagersAsync()
        {
            var managers = await _managerRepository.GetAllManagersAsync();

            return managers.Select(x => x.Id);
        }

        public async Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted)
        {
            var managers = await _managerRepository.GetAllManagersAsync();

            if (sorted)
            {
                return managers.OrderBy(x => x.Name).Select(x => x.TaxNumber);
            }

            return managers.Select(x => x.TaxNumber);
        }
    }
}
