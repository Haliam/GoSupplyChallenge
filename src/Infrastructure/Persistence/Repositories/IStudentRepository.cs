namespace GoSupply.Infrastructure.Persistence.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int id);

        Task<int> AddAsync(Student student);

        Task<bool> UpdateAsync(Student student);

        Task<bool> DeleteAsync(Student student);
    }
}
