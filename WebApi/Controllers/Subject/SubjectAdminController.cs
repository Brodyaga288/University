using Application.Service.Implementation;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Subject;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class SubjectAdminController : Controller
{
    private readonly SubjectService _subjectService;
    public SubjectAdminController(SubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    
    [HttpPost("AddSubject")]
    public async Task<IActionResult> CreateSubject([FromBody]SubjectDTO subject)
    {
        var result = await _subjectService.AddAsync(subject);
        return Ok(result);
    }

    [HttpPut("UpdateSubject")]
    public async Task<IActionResult> UpdateSubject([FromBody] SubjectDTO subject)
    {
        var result = await _subjectService.UpdateAsync(subject);
        return Ok(result);
    }

    [HttpDelete("DeleteSubject/{id}")]
    public async Task<IActionResult> DeleteSubject(Guid subjectId)
    {
        var result = await _subjectService.DeleteAsync(subjectId);
        return Ok(result);
    }
}