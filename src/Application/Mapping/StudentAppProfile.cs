namespace GoSupply.Application.Mapping;

public class StudentAppProfile : Profile
{
    public StudentAppProfile()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}
