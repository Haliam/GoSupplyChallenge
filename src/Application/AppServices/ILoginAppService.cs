namespace GoSupply.Application.AppServices
{
    public interface ILoginAppService
    {
        Task<UserDto> Authenticate(UserLoginDto userLoginDto);

        Task<string> GenerateJwtSecurityToken(UserDto userDto);
    }
}
