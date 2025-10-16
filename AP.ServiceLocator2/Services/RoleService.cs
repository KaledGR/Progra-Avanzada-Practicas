using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetDataAsync();
    }

    public class RoleService(IRestProvider restProvider, IConfiguration configuration) : IService<RoleDTO>, IRoleService
    {
        public async Task<IEnumerable<RoleDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Role");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<RoleDTO>>(response);
        }

    }
}
