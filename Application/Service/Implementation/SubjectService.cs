using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class SubjectService
{
    private readonly ISubjectRepository _rep;
    private readonly IMapper _mapper;

    public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _rep = subjectRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SubjectDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<SubjectDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<SubjectDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<SubjectDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<SubjectDTO> AddAsync(SubjectDTO entity)
    {
        try
        {
            return _mapper.Map<SubjectDTO>(await _rep.AddAsync(_mapper.Map<Subject>(entity)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<SubjectDTO> UpdateAsync(SubjectDTO entity)
    {
        try
        {
            return _mapper.Map<SubjectDTO>(await _rep.UpdateAsync(_mapper.Map<Subject>(entity)));
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