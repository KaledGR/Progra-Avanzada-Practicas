using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface IInventorService
    {
        Task<IEnumerable<InventoryDTO>> GetDataAsync();
    }

    public class InventorService(IRestProvider restProvider, IConfiguration configuration) : IService<InventoryDTO>, IInventorService
    {
        public async Task<IEnumerable<InventoryDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Inventor");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<InventoryDTO>>(response);
        }

      
    }
}