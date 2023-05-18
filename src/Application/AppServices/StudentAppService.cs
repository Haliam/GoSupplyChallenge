namespace GoSupply.Application.AppServices;

public class StudentAppService : AppServiceBase, IStudentAppService
{
    private IConfiguration Configuration { get; }

    private IStudentRepository StudentRepository { get; }

    public StudentAppService(IMapper mapper, IConfiguration configuration, IStudentRepository studentQueryRepository) 
        : base(mapper)
    {
        Configuration = configuration;

        StudentRepository = studentQueryRepository;
    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var sqlQuery = "Select * From Student";

        var students = await StudentRepository.QueryAsync(sqlQuery);

        var studentsDto = Mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }

    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var sqlQuery = "Select * From Student where id = @id";

        var parameters = new { Id = id };

        var student = await StudentRepository.QueryFirstAsync(sqlQuery, parameters);

        var studentDto = Mapper.Map<StudentDto>(student);

        return studentDto;
    }

    public async Task<int> InsertAsync(StudentDto studentDto)
    {
        var sqlQuery = "SET NOCOUNT ON;" +
            "INSERT INTO Student (Name, SurName, BirthDate, Gender, Address, DistrictId)" +
            "VALUES(@Name, @SurName, @BirthDate, @Gender, @Address, @DistrictId);" +
            "SELECT SCOPE_IDENTITY();";

        var result = await StudentRepository.ExecuteAsync(sqlQuery, studentDto);

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

        return await StudentRepository.ExecuteAsync(procedure, parameters);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var procedure = "DeleteStudent";

        var parameters = new { Id = id };

        return await StudentRepository.ExecuteAsync(procedure, parameters);
    }

    public async Task<IEnumerable<StudentDto>> GetByProvinceAsync(string province)
    {
        var sqlQuery = "SELECT s.* " +
            "FROM Student s " +
            "INNER JOIN District d ON s.DistrictId = d.id " +
            "INNER JOIN Province p ON d.ProvinceId = p.id " +
            "WHERE p.Name = @ProvinceName;";

        var parameters = new { ProvinceName = province };

        var students =  await StudentRepository.QueryAsync(sqlQuery, parameters);

        var studentsDto = Mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }

    public async Task<IEnumerable<StudentsByTeacherDto>> GetAllStudentsByTeacherAsync()
    {
        using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

        var query = from teacher in db.Query<Teacher>("SELECT Id, Name FROM Teacher")
                       join assignment in db.Query<Assignment>("SELECT TeacherId, CourseId FROM Assignment") on teacher.Id equals assignment.TeacherId
                       join enrolment in db.Query<Enrolment>("SELECT CourseId, StudentId FROM Enrolment") on assignment.CourseId equals enrolment.CourseId
                       join student in db.Query<Student>("SELECT Id FROM Student") on enrolment.StudentId equals student.Id
                       group enrolment by teacher.Name into g
                       select new StudentsByTeacherDto
                       {
                           TeacherName = g.Key,
                           StudentNumber = g.Select(e => e.StudentId).Distinct().Count()
                       };

        return query.ToList();
    }
}
