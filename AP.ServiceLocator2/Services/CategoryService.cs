using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetDataAsync();
    }

    public class CategoryService(IRestProvider restProvider, IConfiguration configuration) : IService<CategoryDTO>, ICategoryService
    {
        public async Task<IEnumerable<CategoryDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Category");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<CategoryDTO>>(response);
        }

    }
}
