using AutoMapper;
using SchoolAPI.Dto;
using SchoolAPI.Models;

namespace SchoolAPI.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.IdGradeNavigation.Name))
                .ForMember(dest => dest.GradeId, opt => opt.MapFrom(dest => dest.IdGradeNavigation.Id));
                
            CreateMap<StudentDto, Student>();
        }
    }
}
