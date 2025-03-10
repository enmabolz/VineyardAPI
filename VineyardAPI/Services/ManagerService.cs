﻿using VineyardAPI.Repositories.Interfaces;
using VineyardAPI.Services.Interfaces;

namespace VineyardAPI.Services;

public class ManagerService(IManagerRepository _managerRepository) : IManagerService
{
    public async Task<IEnumerable<int>> GetIdsOfManagersAsync()
    {
        try
        {
            var managers = await _managerRepository.GetAllManagersWithoutParcelsAsync();

            return managers.Select(x => x.Id);
        }
        catch (Exception ex)
        {
            throw new Exception("There was a problem with the database or the Server.", ex);
        }
    }

    public async Task<IEnumerable<string>> GetTaxNumbersOrderedAsync(bool sorted)
    {
        try
        {
            var managers = await _managerRepository.GetAllManagersWithoutParcelsAsync();

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

