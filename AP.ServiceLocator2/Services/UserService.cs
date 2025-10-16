using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetDataAsync();
    }

    public class UserService(IRestProvider restProvider, IConfiguration configuration) : IService<UserDTO>, IUserService
    {
        public async Task<IEnumerable<UserDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "User");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<UserDTO>>(response);
        }

    }
}
