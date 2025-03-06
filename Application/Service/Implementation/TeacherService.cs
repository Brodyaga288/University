using Application.Service.Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class TeacherService
{
    private readonly ITeacherRepository _rep;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper, IImageService imageService)
    {
        _rep = teacherRepository;
        _mapper = mapper;
        _imageService = imageService;
    }
    public async Task<IEnumerable<TeacherResponseDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<TeacherResponseDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherResponseDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<TeacherResponseDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherResponseDTO> AddAsync(TeacherRequestDTO entity)
    {
        try
        {
            Teacher teacher = new Teacher()
            {
                Id = entity.Id,
                AcademicDegree = entity.AcademicDegree,
                DateOfBirth = entity.DateOfBirth.ToUniversalTime(),
                Description = entity.Description,
                FullName = entity.FullName,
                PhotoUrl = await _imageService.ChangingImage(entity.Photo)
            };
            return _mapper.Map<TeacherResponseDTO>(await _rep.AddAsync(_mapper.Map<Teacher>(teacher)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<TeacherResponseDTO> UpdateAsync(TeacherRequestDTO entity)
    {
        try
        {
            Teacher teacher = new Teacher()
            {
                Id = entity.Id,
                AcademicDegree = entity.AcademicDegree,
                DateOfBirth = entity.DateOfBirth.ToUniversalTime(),
                Description = entity.Description,
                FullName = entity.FullName,
                PhotoUrl = await _imageService.ChangingImage(entity.Photo)
            };
            return _mapper.Map<TeacherResponseDTO>(await _rep.UpdateAsync(_mapper.Map<Teacher>(teacher)));
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