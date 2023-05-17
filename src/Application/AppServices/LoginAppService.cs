namespace GoSupply.Application.AppServices
{
    public class LoginAppService : AppServiceBase, ILoginAppService
    {
        private IConfiguration Configuration { get; }

        private IUserRepository UserRepository { get; }

        public LoginAppService(IMapper mapper, IConfiguration configuration, IUserRepository userRepository)
            : base(mapper)
        {
            Configuration = configuration;

            UserRepository = userRepository;
        }

        public async Task<UserDto> Authenticate(UserLoginDto userLoginDto)
        {
            var sqlQuery = "SELECT UserId, UserName, Email, FirstName, LastName, Role " +
                "FROM UserLogin INNER JOIN [User] ON UserId = [User].Id " +
                "WHERE UserName = @UserName AND Password = @Password";

            var parameters = new
            {
                UserName = userLoginDto.UserName,

                Password = userLoginDto.Password
            };

            var user = await UserRepository.QueryFirstAsync(sqlQuery, parameters);

            var userDto = Mapper.Map<UserDto>(user);

            userDto.UserName = userLoginDto.UserName;

            return userDto;
        }

        public async Task<string> GenerateJwtSecurityToken(UserDto userDto)
        {
            var claims = CreateClaim(userDto);

            var token = CreateToken(claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static Claim[] CreateClaim(UserDto userDto) => new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userDto.UserName),

            new Claim(ClaimTypes.Email, userDto.Email),

            new Claim(ClaimTypes.GivenName, userDto.FirstName),

            new Claim(ClaimTypes.Surname, userDto.LastName),

            new Claim(ClaimTypes.Role, userDto.RoleName)
        };

        private JwtSecurityToken CreateToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(

                Configuration["Jwt:Issuer"],

                Configuration["Jwt:Audience"],

                claims,

                expires: DateTime.Now.AddMinutes(60),

                signingCredentials: credentials);
        }
    }
}
