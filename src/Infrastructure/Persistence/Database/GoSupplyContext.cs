namespace GoSupply.Infrastructure.Persistence.Database
{
    public class GoSupplyContext
    {
        private IConfiguration Configuration { get;}

        private string ConnectionString { get;}

        public GoSupplyContext(IConfiguration configuration)
        {
            Configuration = configuration;

            ConnectionString = Configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
