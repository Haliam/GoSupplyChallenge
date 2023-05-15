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

    // GET: api/<StudentsController>
    [HttpGet]
    public async Task<IEnumerable<StudentDto>> GetAllAsync() => await StudentAppService.GetAllAsync();

    // GET api/<StudentsController>/5
    [HttpGet("{id}")]
    public async Task<StudentDto> GetByIdAsync(int id) => await StudentAppService.GetByIdAsync(id);

    // POST api/<StudentsController>
    [HttpPost]
    public async Task Insert([FromBody] StudentDto studentDto) => await StudentAppService.InsertAsync(studentDto);

    // PUT api/<StudentsController>/5
    [HttpPut("{id}")]
    public async Task Update(int id, [FromBody] StudentDto studentDto) => await StudentAppService.UpdateAsync(id, studentDto);

    // DELETE api/<StudentsController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id) => await StudentAppService.DeleteAsync(id);
}
