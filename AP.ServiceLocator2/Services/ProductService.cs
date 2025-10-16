using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetDataAsync();
    }

    public class ProductService(IRestProvider restProvider, IConfiguration configuration) : IService<ProductDTO>, IProductService
    {
        public async Task<IEnumerable<ProductDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Product");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<ProductDTO>>(response);
        }

    }
}
