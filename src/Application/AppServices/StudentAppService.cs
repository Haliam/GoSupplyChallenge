namespace GoSupply.Application.AppServices;

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
        var sqlQuery = "Select * From Student";

        var students = await StudentQueryRepository.QueryAsync(sqlQuery);

        var studentsDto = Mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }

    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var sqlQuery = "Select * From Student where id = @id";

        var parameters = new { Id = id };

        var student = await StudentQueryRepository.QueryFirstAsync(sqlQuery, parameters);

        var studentDto = Mapper.Map<StudentDto>(student);

        return studentDto;
    }

    public async Task<int> InsertAsync(StudentDto studentDto)
    {
        var sqlQuery = "SET NOCOUNT ON;" +
            "INSERT INTO Student (Name, SurName, BirthDate, Gender, Address, DistrictId)" +
            "VALUES(@Name, @SurName, @BirthDate, @Gender, @Address, @DistrictId);" +
            "SELECT SCOPE_IDENTITY();";

        var result = await StudentQueryRepository.ExecuteAsync(sqlQuery, studentDto);

        return result;
    }

    public async Task<int> UpdateAsync(int id, StudentDto studentDto)
    {
        var procedure = "UpdateStudent";

        var parameters = new 
        {
            Id = id,
            Name = studentDto.Name,
            SurName = studentDto.SurName,
            BirthDate= studentDto.BirthDate,
            Gender = studentDto.Gender,
            Address = studentDto.Address,
            DistrictId = studentDto.DistrictId
        };

        return await StudentQueryRepository.ExecuteAsync(procedure, parameters);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var procedure = "DeleteStudent";

        var parameters = new { Id = id };

        return await StudentQueryRepository.ExecuteAsync(procedure, parameters);
    }
}
