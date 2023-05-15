using GoSupply.Application.Dtos;
using GoSupply.Domain.Entities;

namespace GoSupply.Application.Mapping
{
    public class StudentAppProfile : Profile
    {
        public StudentAppProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
