namespace GoSupply.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IConfiguration Configuration { get; }

        public Repository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<T>> QueryAsync(string query, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

            return await db.QueryAsync<T>(query, parameters, commandType: commandType);
        } 
            
        public async Task<T> QueryFirstAsync(string query, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

            return await db.QueryFirstAsync<T>(query, parameters, commandType: commandType);
        }
           
        public async Task<int> ExecuteAsync(string procedure, object? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

            return await db.ExecuteAsync(procedure, parameters, commandType: commandType);
        } 
    }
}
