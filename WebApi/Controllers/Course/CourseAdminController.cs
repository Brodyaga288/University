using Application.Service.Implementation;
using Application.Service.Interface;
using Domain.Models;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CourseAdminController : Controller
{
    private readonly CourseService _courseService;
    public CourseAdminController(CourseService courseService)
    {
        _courseService = courseService;
    }
    
    [HttpPost("AddCourse")]
    public async Task<IActionResult> CreateCourse([FromBody]CourseDTO course)
    {
        var result = await _courseService.AddAsync(course);
        return Ok(result);
    }

    [HttpPut("UpdateCourse")]
    public async Task<IActionResult> UpdateCourse([FromBody] CourseDTO course)
    {
        var result = await _courseService.UpdateAsync(course);
        return Ok(result);
    }

    [HttpDelete("DeleteCourse/{id}")]
    public async Task<IActionResult> DeleteCourse(Guid courseId)
    {
        var result = await _courseService.DeleteAsync(courseId);
        return Ok(result);
    }
}