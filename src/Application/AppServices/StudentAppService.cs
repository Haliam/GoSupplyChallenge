
namespace GoSupply.Application.AppServices
{
    public class StudentAppService : AppServiceBase, IStudentAppService
    {
        private IStudentRepository StudentQueryRepository { get; }

        public StudentAppService(IMapper mapper, IStudentRepository studentQueryRepository) 
            : base(mapper)
        {
            StudentQueryRepository = studentQueryRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var query = "Select * From Student";

            var students = await StudentQueryRepository.QueryAsync(query);

            var studentsDto = Mapper.Map<IEnumerable<StudentDto>>(students);

            return studentsDto;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var query = "Select * From Student where id = @id";

            var parameters = new { Id = id };

            var student = await StudentQueryRepository.QueryFirstAsync(query, parameters);

            var studentDto = Mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<int> InsertAsync(StudentDto studentDto)
        {
            var procedure = "InsertStudent";

            return await StudentQueryRepository.ExecuteAsync(procedure, studentDto);
        }

        public async Task<int> UpdateAsync(int id, StudentDto studentDto)
       {
            var procedure = "UpdateStudent";



            var parameters = new StudentDto
            {
                Name = studentDto.Name,
                SurName = studentDto.SurName,
                BirthDate= studentDto.BirthDate,
                Gender = studentDto.Gender,
                Address = studentDto.Address,
            };

            return await StudentQueryRepository.ExecuteAsync(procedure, parameters);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DeleteStudent";

            var parameters = new
            {
                car_id = id
            };

            return await StudentQueryRepository.ExecuteAsync(query, id);
        }
    }
}
