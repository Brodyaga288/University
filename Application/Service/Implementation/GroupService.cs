using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class GroupService
{
    private readonly IGroupRepository _rep;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _rep = groupRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GroupDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<GroupDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<GroupDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<GroupDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<GroupDTO> AddAsync(GroupDTO entity)
    {
        try
        {
            return _mapper.Map<GroupDTO>(await _rep.AddAsync(_mapper.Map<Group>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<GroupDTO> UpdateAsync(GroupDTO entity)
    {
        try
        {
            return _mapper.Map<GroupDTO>(await _rep.UpdateAsync(_mapper.Map<Group>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            return await _rep.DeleteAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}