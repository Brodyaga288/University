using Domain.Models;
using Infrastructure.Repository.Intarface;

namespace Infrastructure.Repository.Implemetation;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(ApplicationContext context) : base(context)
    {
    }
}