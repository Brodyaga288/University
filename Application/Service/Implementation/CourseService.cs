using Application.Service.Interface;
using Application.Service.Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class CourseService
{
    private readonly ICourseRepository _rep;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _rep = courseRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CourseDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<CourseDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<CourseDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<CourseDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<CourseDTO> AddAsync(CourseDTO entity)
    {
        try
        {
            return _mapper.Map<CourseDTO>(await _rep.AddAsync(_mapper.Map<Course>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<CourseDTO> UpdateAsync(CourseDTO entity)
    {
        try
        {
            return _mapper.Map<CourseDTO>(await _rep.UpdateAsync(_mapper.Map<Course>(entity)));
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