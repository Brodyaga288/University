using Application.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Group;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "User, Admin")]
public class GroupUserController : Controller
{
    // GET
    private readonly GroupService _groupService;
    public GroupUserController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("GetAllGroup")]
    public async Task<IActionResult> GetAllGroups()
    { 
        var AllGroup = await _groupService.GetAllAsync();

        if (AllGroup is null)
        {
            return StatusCode(statusCode: 204, new { message = "Нет групп" });
        }
        else
        {
            return Ok(AllGroup);
        }
    }

    [HttpGet("GetGroup/{id}")]
    public async Task<IActionResult> GetGroup(Guid courseId)
    {
        var Group = await _groupService.GetAsync(courseId);
        
        if (Group is null)
        {
            return StatusCode(statusCode: 404, "Группы не существует");
        }
        else
        {
            return Ok(Group);
        }
    }
}