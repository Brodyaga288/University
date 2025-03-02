using Application.Service.Implementation;
using Application.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User, Admin")]
public class CourseUserController : Controller
{
    private readonly CourseService _courseService;
    public CourseUserController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("GetAllCourses")]
    public async Task<IActionResult> GetAllCourses()
    { 
        var AllCourses = await _courseService.GetAllAsync();

        if (AllCourses is null)
        {
            return StatusCode(statusCode: 204, new { message = "Нет курсов" });
        }
        else
        {
            return Ok(AllCourses);
        }
    }

    [HttpGet("GetCourse/{id}")]
    public async Task<IActionResult> GetCourse(Guid courseId)
    {
        var Course = await _courseService.GetAsync(courseId);
        
        if (Course is null)
        {
            return StatusCode(statusCode: 404, "Пользователя не существует");
        }
        else
        {
            return Ok(Course);
        }
    }
}