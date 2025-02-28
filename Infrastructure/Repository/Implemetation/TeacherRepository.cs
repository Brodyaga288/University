using Domain.Models;
using Infrastructure.Repository.Intarface;

namespace Infrastructure.Repository.Implemetation;

public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(ApplicationContext context) : base(context)
    {
    }
}