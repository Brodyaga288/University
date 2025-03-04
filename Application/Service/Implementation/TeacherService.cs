using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class TeacherService
{
    private readonly ITeacherRepository _rep;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _rep = teacherRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<TeacherDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<TeacherDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherDTO> AddAsync(TeacherDTO entity)
    {
        try
        {
            entity.DateOfBirth.ToUniversalTime();
            return _mapper.Map<TeacherDTO>(await _rep.AddAsync(_mapper.Map<Teacher>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherDTO> UpdateAsync(TeacherDTO entity)
    {
        try
        {
            entity.DateOfBirth.ToUniversalTime();
            return _mapper.Map<TeacherDTO>(await _rep.UpdateAsync(_mapper.Map<Teacher>(entity)));
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