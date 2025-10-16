namespace AP.ServiceLocator2.Services.Contracts;

public interface IService<T>
{
    Task<IEnumerable<T>> GetDataAsync();
}
