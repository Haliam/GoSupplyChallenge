namespace GoSupply.Application.Mapping;

public class UserAppProfile : Profile
{
	public UserAppProfile()
	{
		CreateMap<User, UserDto>().ReverseMap();
	}
}
