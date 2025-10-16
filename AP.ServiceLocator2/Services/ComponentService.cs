using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface IComponentService
    {
        Task<IEnumerable<ComponentDTO>> GetDataAsync();
    }

    public class ComponentService(IRestProvider restProvider, IConfiguration configuration) : IService<ComponentDTO>, IComponentService
    {
        public async Task<IEnumerable<ComponentDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Component");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<ComponentDTO>>(response);
        }

    }
}
