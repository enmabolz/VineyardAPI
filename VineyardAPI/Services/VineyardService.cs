using VineyardAPI.Repositories.Interfaces;
using VineyardAPI.Services.Interfaces;

namespace VineyardAPI.Services;

public class VineyardService(IVineyardRepository _vineyardRepository) : IVineyardService
{
    public async Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync()
    {
        try
        {
            return await _vineyardRepository.GetVineyardsWithManagersAsync();
        } catch (Exception ex)
        {
            throw new Exception("There was a problem with the database or the Server.", ex);
        }
        
    }
}
