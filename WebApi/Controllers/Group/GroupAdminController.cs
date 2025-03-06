using Application.Service.Implementation;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Group;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class GroupAdminController : Controller
{
    private readonly GroupService _groupService;
    public GroupAdminController(GroupService GroupService)
    {
        _groupService = GroupService;
    }
    
    [HttpPost("AddGroup")]
    public async Task<IActionResult> CreatGroup([FromBody]GroupDTO group)
    {
        var result = await _groupService.AddAsync(group);
        return Ok(result);
    }

    [HttpPut("UpdateGroup")]
    public async Task<IActionResult> UpdateGroup([FromBody] GroupDTO group)
    {
        var result = await _groupService.UpdateAsync(group);
        return Ok(result);
    }

    [HttpDelete("DeleteGroup/{id}")]
    public async Task<IActionResult> DeleteGroup(Guid groupId)
    {
        var result = await _groupService.DeleteAsync(groupId);
        return Ok(result);
    }
}