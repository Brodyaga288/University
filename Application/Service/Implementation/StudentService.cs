using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class StudentService
{
    private readonly IStudentRepository _rep;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _rep = studentRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<StudentDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<StudentDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<StudentDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentDTO> AddAsync(StudentDTO entity)
    {
        try
        {
            return _mapper.Map<StudentDTO>(await _rep.AddAsync(_mapper.Map<Student>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentDTO> UpdateAsync(StudentDTO entity)
    {
        try
        {
            return _mapper.Map<StudentDTO>(await _rep.UpdateAsync(_mapper.Map<Student>(entity)));
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