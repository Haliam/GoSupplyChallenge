namespace GoSupply.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> QueryAsync(string query, object parameters = null, CommandType commandType = CommandType.Text);

        Task<T> QueryFirstAsync(string query, object parameters = null, CommandType commandType = CommandType.Text);

        Task<int> ExecuteAsync(string procedure, object parameters = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
