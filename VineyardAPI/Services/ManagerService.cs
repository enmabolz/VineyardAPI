using Microsoft.Data.SqlClient;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Interfaces.Services;

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
            try
            {
                var managers = await _managerRepository.GetAllManagersAsync();

                return managers.Select(x => x.Id);
            } catch (Exception ex) 
            {
                throw new Exception("There was a problem with the database or the Server.", ex);   
            }
        }

        public async Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted)
        {
            try
            {
                var managers = await _managerRepository.GetAllManagersAsync();

                if (sorted)
                {
                    return managers.OrderBy(x => x.Name).Select(x => x.TaxNumber);
                }

                return managers.Select(x => x.TaxNumber);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem with the database or the Server.", ex);
            }

        }

        public async Task<Dictionary<string, int>> GetManagersTotalAdministratedAreaAsync()
        {
            try
            {
                return await _managerRepository.GetManagersTotalAdministratedAreaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem with the database or the Server.", ex);
            }
        }
    }
}
