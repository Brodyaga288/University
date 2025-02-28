using Application.Service.Implementation;
using Application.Service.Interface;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _authService;

    public AccountController(IAccountService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterDTO model)
    {
        try
        {
            var token = await _authService.RegisterAsync(model);
            return Ok(new {Model = model, Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        try
        {
            var token = await _authService.LoginAsync(model);
            return Ok(new {Model = model, Token = token });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}