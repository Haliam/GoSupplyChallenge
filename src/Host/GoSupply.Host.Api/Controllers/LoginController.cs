namespace GoSupply.Host.Api.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    ILoginAppService LoginAppService { get; set; }

    public LoginController(ILoginAppService loginAppService)
    {
        LoginAppService = loginAppService;
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var userDto = await LoginAppService.Authenticate(userLoginDto);

        if (userDto == null)
            return NotFound();

        var token = await LoginAppService.GenerateJwtSecurityToken(userDto);

        return Ok(token);
    }
}
