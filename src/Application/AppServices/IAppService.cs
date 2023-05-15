namespace GoSupply.Application.AppServices;

public interface IAppService<T>
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<int> InsertAsync(T entity);

    Task<int> UpdateAsync(int id, T entity);

    Task<int> DeleteAsync(int id);
}