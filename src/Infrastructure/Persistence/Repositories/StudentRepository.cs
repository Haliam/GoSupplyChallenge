namespace GoSupply.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IDbConnection DbConnection { get;}

        private GoSupplyContext Context { get;}

        public StudentRepository(GoSupplyContext context)
        {
            Context = context;

            DbConnection = Context.CreateConnection();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await DbConnection.GetAllAsync<Student>();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await DbConnection.GetAsync<Student>(id);
        }

        public async Task<int> AddAsync(Student student)
        {
            return await DbConnection.InsertAsync(student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await DbConnection.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            return await DbConnection.DeleteAsync<Student>(student);
        }
    }
}
