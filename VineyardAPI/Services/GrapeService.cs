using VineyardAPI.Repositories.Interfaces;
using VineyardAPI.Services.Interfaces;

namespace VineyardAPI.Services;

public class GrapeService(IGrapeRepository _grapeRepository) : IGrapeService
{
    public async Task<Dictionary<string, int>> GetAreaByGrapeAsync()
    {
        try
        {
            var areas = await _grapeRepository.GetTotalAreaByGrapeAsync();

            return areas;
        }
        catch (Exception ex)
        {
            throw new Exception("There was a problem with the database or the Server.", ex);
        }
    }
}

