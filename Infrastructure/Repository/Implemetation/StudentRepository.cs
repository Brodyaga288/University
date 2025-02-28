using Domain.Models;
using Infrastructure.Repository.Intarface;

namespace Infrastructure.Repository.Implemetation;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationContext context) : base(context)
    {
    }
}