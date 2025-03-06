using Application.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Subject;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User, Admin")]
public class SubjectUserController : Controller
{
    private readonly SubjectService _subjectService;
    public SubjectUserController(SubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet("GetAllSubjects")]
    public async Task<IActionResult> GetAllSubjects()
    { 
        var AllSubjects = await _subjectService.GetAllAsync();

        if (AllSubjects is null)
        {
            return StatusCode(statusCode: 204, new { message = "Нет курсов" });
        }
        else
        {
            return Ok(AllSubjects);
        }
    }

    [HttpGet("GetSubject/{id}")]
    public async Task<IActionResult> GetSubject(Guid courseId)
    {
        var Subject = await _subjectService.GetAsync(courseId);
        
        if (Subject is null)
        {
            return StatusCode(statusCode: 404, "Пользователя не существует");
        }
        else
        {
            return Ok(Subject);
        }
    }
}