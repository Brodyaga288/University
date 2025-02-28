using AutoMapper;
using Domain.Models;

namespace Infrastructure.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseDTO>().ReverseMap();
        CreateMap<Group, GroupDTO>().ReverseMap();
        CreateMap<Teacher, TeacherDTO>().ReverseMap();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Subject, SubjectDTO>().ReverseMap();
    }
}