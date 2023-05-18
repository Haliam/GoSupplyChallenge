namespace GoSupply.Host.Api.Controllers;

[Route("api/student")]
[ApiController]
public class StudentsController : ControllerBase
{
    private IStudentAppService StudentAppService { get; }

    public StudentsController(IStudentAppService studentAppService)
    {
        StudentAppService = studentAppService;
    }

    [HttpGet]
    public async Task<IEnumerable<StudentDto>> GetAllAsync() => await StudentAppService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<StudentDto> GetByIdAsync(int id) => await StudentAppService.GetByIdAsync(id);

    [HttpGet("byprovince/{province}")]
    public async Task<IEnumerable<StudentDto>> GetByProvinceAsync(string province) => await StudentAppService.GetByProvinceAsync(province);

    [HttpGet("allstudentsbyteacher")]
    public async Task<IEnumerable<StudentsByTeacherDto>> GetAllStudentsByTeacherAsync() => await StudentAppService.GetAllStudentsByTeacherAsync();

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task InsertAsync([FromBody] StudentDto studentDto) => await StudentAppService.InsertAsync(studentDto);

    [HttpPut("{id}")]
    [Authorize(Roles = "User")]
    public async Task UpdateAsync(int id, [FromBody] StudentDto studentDto) => await StudentAppService.UpdateAsync(id, studentDto);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task DeleteAsync(int id) => await StudentAppService.DeleteAsync(id);
}
