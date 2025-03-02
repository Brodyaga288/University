using Application.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Student;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User, Admin")]
public class StudentUserController : Controller
{
    private readonly StudentService _studentService;
    public StudentUserController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("GetAllStudents")]
    public async Task<IActionResult> GetAllStudents()
    { 
        var AllStudent = await _studentService.GetAllAsync();

        if (AllStudent is null)
        {
            return StatusCode(statusCode: 204, new { message = "Нет курсов" });
        }
        else
        {
            return Ok(AllStudent);
        }
    }

    [HttpGet("GetStudent/{id}")]
    public async Task<IActionResult> GetStudent(Guid courseId)
    {
        var Student = await _studentService.GetAsync(courseId);
        
        if (Student is null)
        {
            return StatusCode(statusCode: 404, "Пользователя не существует");
        }
        else
        {
            return Ok(Student);
        }
    }
}