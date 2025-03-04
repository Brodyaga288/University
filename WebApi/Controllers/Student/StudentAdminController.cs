using Application.Service.Implementation;
using AutoMapper;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Student;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class StudentAdminController : Controller
{
    private readonly StudentService _studentService;
    private readonly ImageService _imageService;
    public StudentAdminController(StudentService studentService, ImageService imageService)
    {
        _studentService = studentService;
        _imageService = imageService;
    }
    
    [HttpPost("AddStudent")]
    public async Task<IActionResult> CreateStubent([FromBody]StudentDTO student)
    {
        
        student.PhotoUrl = await _imageService.ChangingImage(student.PhotoUrl);
        var result = await _studentService.AddAsync(student);
        return Ok(result);
    }

    [HttpPut("UpdateStudent")]
    public async Task<IActionResult> UpdateStudent([FromBody] StudentDTO student)
    {
        student.PhotoUrl = await _imageService.ChangingImage(student.PhotoUrl);
        var result = await _studentService.UpdateAsync(student);
        return Ok(result);
    }

    [HttpDelete("DeleteStudent/{id}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        var result = await _studentService.DeleteAsync(studentId);
        return Ok(result);
    }
}