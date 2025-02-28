using Domain.Models;
using Infrastructure.Repository.Intarface;

namespace Infrastructure.Repository.Implemetation;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationContext context) : base(context)
    {
        
    }
}