using AP.Models.DTOs;
using AP.ServiceLocator.Services.Contracts;


namespace AP.ServiceLocator.Helper;

public interface IServiceMapper
{
    Task<IService<T>> GetServiceAsync<T>(string name);
}

public class ServiceMapper : IServiceMapper
{
    private readonly IServiceProvider serviceProvider;

    public ServiceMapper(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<IService<T>> GetServiceAsync<T>(string name)
    {
        var service = name.ToLower() switch
        {
            "category" => (IService<T>)serviceProvider.GetRequiredService<IService<CategoryDTO>>(),
            "component" => (IService<T>)serviceProvider.GetRequiredService<IService<ComponentDTO>>(),
            "inventory" => (IService<T>)serviceProvider.GetRequiredService<IService<InventoryDTO>>(),
            "product" => (IService<T>)serviceProvider.GetRequiredService<IService<ProductDTO>>(),
            "role" => (IService<T>)serviceProvider.GetRequiredService<IService<RoleDTO>>(),
            "task" => (IService<T>)serviceProvider.GetRequiredService<IService<TaskDTO>>(),
            "user" => (IService<T>)serviceProvider.GetRequiredService<IService<UserDTO>>(),
            _ => throw new ArgumentException($"Service not found for '{name}'")
        };

        return Task.FromResult(service);
    }

}

