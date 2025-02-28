using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Service.Interface;
using AutoMapper;
using Domain.Models;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Service.Implementation;

public class AccountService : IAccountService
{
     private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(RegisterDTO model)
    {
        var user = new User
        {
            UserName = model.UserName, // Используем UserName
            FullName = model.FullName,
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Регистрация не удалась: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
        var role = await _userManager.AddToRoleAsync(user, model.Role.ToString());

        if (!role.Succeeded)
        {
            throw new Exception("Не удалось выдать роль: " + string.Join(", ", role.Errors.Select(e => e.Description)));
        }
        if (result.Succeeded)
        {
            return "Успешная регистрация";
        }
        throw new Exception("Регистрация не удалась: " + string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<string> LoginAsync(LoginDTO model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName); // Ищем пользователя по UserName

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return await GenerateJwtToken(user);
        }

        throw new Exception("Неверный логин или пароль");
    }

    private async Task<string> GenerateJwtToken(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        };
        claims.AddRange(roles.Select(role => new Claim("role", role)));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
