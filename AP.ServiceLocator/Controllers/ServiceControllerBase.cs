using AP.Models.DTOs;
using AP.ServiceLocator.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AP.ServiceLocator.Controllers
{
    public class ServiceControllerBase : ControllerBase
    {
        protected readonly Dictionary<string, Func<Task<IEnumerable<object>>>> ServiceResolvers;
        protected ServiceControllerBase(IServiceMapper serviceMapper)
        {
            ServiceResolvers = new()
            {
                ["category"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<CategoryDTO>("category");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["component"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<ComponentDTO>("component");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["inventor"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<InventoryDTO>("inventor");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["product"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<ProductDTO>("product");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["role"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<RoleDTO>("role");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["task"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<TaskDTO>("task");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },
                ["user"] = async () =>
                {
                    // defer resolution until invocation time
                    var service = await serviceMapper.GetServiceAsync<UserDTO>("user");
                    var data = await service.GetDataAsync();
                    return data.Cast<object>();
                },

            };
        }
    }
}
