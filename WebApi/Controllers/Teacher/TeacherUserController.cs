using Application.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Teacher;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User, Admin")]
public class TeacherUserController : Controller
{
    private readonly TeacherService _teacherService;
    public TeacherUserController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("GetAllTeachers")]
    public async Task<IActionResult> GetAllTeachers()
    { 
        var AllTeachers = await _teacherService.GetAllAsync();

        if (AllTeachers is null)
        {
            return StatusCode(statusCode: 204, new { message = "Нет курсов" });
        }
        else
        {
            return Ok(AllTeachers);
        }
    }

    [HttpGet("GetTeacher/{id}")]
    public async Task<IActionResult> GetTeacher(Guid teacherId)
    {
        var Teacher = await _teacherService.GetAsync(teacherId);
        
        if (Teacher is null)
        {
            return StatusCode(statusCode: 404, "Пользователя не существует");
        }
        else
        {
            return Ok(Teacher);
        }
    }
}