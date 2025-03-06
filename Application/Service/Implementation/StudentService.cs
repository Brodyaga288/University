using Application.Service.Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repository.Intarface;

namespace Application.Service.Implementation;

public class StudentService
{
    private readonly IStudentRepository _rep;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper, IImageService imageService)
    {
        _rep = studentRepository;
        _mapper = mapper;
        _imageService = imageService;
    }
    public async Task<IEnumerable<StudentResponseDTO>> GetAllAsync()
    {
        try
        {
            return _mapper.Map<IEnumerable<StudentResponseDTO>>(await _rep.GetAllAsync());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentResponseDTO> GetAsync(Guid id)
    {
        try
        {
            return _mapper.Map<StudentResponseDTO>(await _rep.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentResponseDTO> AddAsync(StudentRequestDTO entity)
    {
        try
        {
            Student student = new Student()
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth.ToUniversalTime(),
                Description = entity.Description,
                FullName = entity.FullName,
                PhotoUrl = await _imageService.ChangingImage(entity.Photo),
                GroupId = entity.GroupId,
            };
            return _mapper.Map<StudentResponseDTO>(await _rep.AddAsync(_mapper.Map<Student>(student)));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<StudentResponseDTO> UpdateAsync(StudentRequestDTO entity)
    {
        try
        {
            Student student = new Student()
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth.ToUniversalTime(),
                Description = entity.Description,
                FullName = entity.FullName,
                PhotoUrl = await _imageService.ChangingImage(entity.Photo),
                GroupId = entity.GroupId,
            };
            return _mapper.Map<StudentResponseDTO>(await _rep.UpdateAsync(_mapper.Map<Student>(student)));
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