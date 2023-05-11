namespace GoSupply.Infrastructure.Persistence.Database
{
    public class GoSupplyContext
    {
        private IConfiguration IConfiguration { get;}

        private string ConnectionString { get;}

        public GoSupplyContext(IConfiguration configuration)
        {
            IConfiguration = configuration;

            ConnectionString = IConfiguration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
