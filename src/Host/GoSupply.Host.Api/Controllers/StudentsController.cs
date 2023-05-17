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

    [HttpPost]
    public async Task Insert([FromBody] StudentDto studentDto) => await StudentAppService.InsertAsync(studentDto);

    [HttpPut("{id}")]
    public async Task Update(int id, [FromBody] StudentDto studentDto) => await StudentAppService.UpdateAsync(id, studentDto);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await StudentAppService.DeleteAsync(id);
}
