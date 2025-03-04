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
    private readonly ImageService _imageService;
    public TeacherAdminController(TeacherService teacherService, ImageService imageService)
    {
        _teacherService = teacherService;
        _imageService = imageService;
    }
    
    [HttpPost("AddTeacher")]
    public async Task<IActionResult> CreateTeacher([FromBody]TeacherDTO teacher)
    {
        teacher.PhotoUrl = await _imageService.ChangingImage(teacher.PhotoUrl);
        var result = await _teacherService.AddAsync(teacher);
        return Ok(result);
    }

    [HttpPut("UpdateTeacher")]
    public async Task<IActionResult> UpdateTeacher([FromBody] TeacherDTO teacher)
    {
        teacher.PhotoUrl = await _imageService.ChangingImage(teacher.PhotoUrl);
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