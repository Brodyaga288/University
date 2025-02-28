using Domain.Models;
using Infrastructure.Repository.Intarface;

namespace Infrastructure.Repository.Implemetation;

public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(ApplicationContext context) : base(context)
    {
    }
}