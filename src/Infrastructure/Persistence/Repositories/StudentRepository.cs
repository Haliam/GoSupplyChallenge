namespace GoSupply.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }
    }
}
