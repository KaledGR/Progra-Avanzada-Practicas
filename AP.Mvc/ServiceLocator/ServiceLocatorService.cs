using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Helper;
using AP.ServiceLocator2.Services;


using System.Xml.Linq;

namespace AP.Mvc.ServiceLocator2
{
    public interface IServiceLocatorService
    {
        Task<IEnumerable<T>> GetDataAsync<T>(string name);

        Task<IEnumerable<CategoryDTO>> GetDataCategoryAsync();
        Task<IEnumerable<ComponentDTO>> GetDataComponentAsync();

        Task<IEnumerable<InventoryDTO>> GetDataInventoryAsync();
        Task<IEnumerable<ProductDTO>> GetDataProductAsync();
        Task<IEnumerable<RoleDTO>> GetDataRoleAsync();
        Task<IEnumerable<TaskDTO>> GetDataTaskAsync();

        Task<IEnumerable<UserDTO>> GetDataUserkAsync();


    }

    public class ServiceLocatorService(IRestProvider restProvider, IServiceMapper serviceMapper) : IServiceLocatorService
    {

        public void Test()
        {
            serviceMapper.GetServiceAsync<ICategoryService>("category");
        }

        public async Task<IEnumerable<T>> GetDataAsync<T>(string name)
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", name);
            return await JsonProvider.DeserializeAsync<IEnumerable<T>>(response);
        }

        public async Task<IEnumerable<CategoryDTO>> GetDataCategoryAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "category");
            return await JsonProvider.DeserializeAsync<IEnumerable<CategoryDTO>>(response);
        }

        public async Task<IEnumerable<ComponentDTO>> GetDataComponentAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "component");
            return await JsonProvider.DeserializeAsync<IEnumerable<ComponentDTO>>(response);
        }

        public async Task<IEnumerable<InventoryDTO>> GetDataInventoryAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "inventor");
            return await JsonProvider.DeserializeAsync<IEnumerable<InventoryDTO>>(response);
        }

        public async Task<IEnumerable<ProductDTO>> GetDataProductAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "product");
            return await JsonProvider.DeserializeAsync<IEnumerable<ProductDTO>>(response);
        }

        public async Task<IEnumerable<RoleDTO>> GetDataRoleAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "role");
            return await JsonProvider.DeserializeAsync<IEnumerable<RoleDTO>>(response);
        }

        public async Task<IEnumerable<TaskDTO>> GetDataTaskAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "task");
            return await JsonProvider.DeserializeAsync<IEnumerable<TaskDTO>>(response);
        }

        public async Task<IEnumerable<UserDTO>> GetDataUserkAsync()
        {
            var response = await restProvider.GetAsync("https://localhost:7252/api/ServiceLocator/", "user");
            return await JsonProvider.DeserializeAsync<IEnumerable<UserDTO>>(response);
        }

    }
}
