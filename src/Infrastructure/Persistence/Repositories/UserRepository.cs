namespace GoSupply.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IConfiguration configuration) 
        : base(configuration)
    {
    }
}
