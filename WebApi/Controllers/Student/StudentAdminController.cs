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
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateStudent([FromForm]StudentRequestDTO studentRequest)
    {
        var result = await _studentService.AddAsync(studentRequest);
        return Ok(result);
    }

    [HttpPut("UpdateStudent")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateStudent([FromForm]StudentRequestDTO studentRequest)
    {
        var result = await _studentService.UpdateAsync(studentRequest);
        return Ok(result);
    }

    [HttpDelete("DeleteStudent/{id}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        var result = await _studentService.DeleteAsync(studentId);
        return Ok(result);
    }
}