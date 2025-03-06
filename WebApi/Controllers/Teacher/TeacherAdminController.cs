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
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateTeacher([FromForm]TeacherRequestDTO teacherRequest)
    {
        var result = await _teacherService.AddAsync(teacherRequest);
        return Ok(result);
    }

    [HttpPut("UpdateTeacher")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateTeacher([FromForm] TeacherRequestDTO teacherRequest)
    {
        var result = await _teacherService.UpdateAsync(teacherRequest);
        return Ok(result);
    }

    [HttpDelete("DeleteTeacher/{id}")]
    public async Task<IActionResult> DeleteTeacher(Guid teacherId)
    {
        var result = await _teacherService.DeleteAsync(teacherId);
        return Ok(result);
    }
}