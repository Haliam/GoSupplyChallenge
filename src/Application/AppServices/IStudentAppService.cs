namespace GoSupply.Application.AppServices;

public interface IStudentAppService : IAppService<StudentDto>
{
    Task<IEnumerable<StudentDto>> GetByProvinceAsync(string province);

    Task<IEnumerable<StudentsByTeacherDto>> GetAllStudentsByTeacherAsync();
}
