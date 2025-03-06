using AutoMapper;
using Domain.Models;

namespace Infrastructure.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseDTO>().ReverseMap();
        CreateMap<Group, GroupDTO>().ReverseMap();
        CreateMap<Teacher, TeacherRequestDTO>().ReverseMap();
        CreateMap<Student, StudentRequestDTO>().ReverseMap();
        CreateMap<Subject, SubjectDTO>().ReverseMap();
    }
}