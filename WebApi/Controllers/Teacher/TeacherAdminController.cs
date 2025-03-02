using Application.Service.Implementation;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Teacher;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class TeacherAdminController : Controller
{
    private readonly TeacherService _teacherService;
    public TeacherAdminController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    
    [HttpPost("AddTeacher")]
    public async Task<IActionResult> CreateTeacher([FromBody]TeacherDTO teacher)
    {
        var result = await _teacherService.AddAsync(teacher);
        return Ok(result);
    }

    [HttpPut("UpdateTeacher")]
    public async Task<IActionResult> UpdateTeacher([FromBody] TeacherDTO teacher)
    {
        var result = await _teacherService.UpdateAsync(teacher);
        return Ok(result);
    }

    [HttpDelete("DeleteTeacher/{id}")]
    public async Task<IActionResult> DeleteTeacher(Guid teacherId)
    {
        var result = await _teacherService.DeleteAsync(teacherId);
        return Ok(result);
    }
}