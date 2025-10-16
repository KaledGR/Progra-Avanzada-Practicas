using AP.Architecture;
using AP.Architecture.Providers;
using AP.Models.DTOs;
using AP.ServiceLocator2.Services.Contracts;

namespace AP.ServiceLocator2.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetDataAsync();
    }

    public class TaskService(IRestProvider restProvider, IConfiguration configuration) : IService<TaskDTO>, ITaskService
    {
        public async Task<IEnumerable<TaskDTO>> GetDataAsync()
        {
            var url = configuration.GetStringFromAppSettings("APIS", "Tasks");
            var response = await restProvider.GetAsync(url, null);
            return await JsonProvider.DeserializeAsync<IEnumerable<TaskDTO>>(response);
        }

    }
}
