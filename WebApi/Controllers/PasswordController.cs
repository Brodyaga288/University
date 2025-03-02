using Application.Service.Implementation;
using Application.Service.Interface;
using Domain.Models;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Password;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PasswordController : Controller
{
     private readonly UserManager<User> _userManager;
     private readonly IEmailService _emailService;

     public PasswordController(UserManager<User> userManager, IEmailService emailService)
     { 
         _userManager = userManager;
         _emailService = emailService;
     }

     [HttpPost("forgot-password")]
     public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO model)
     {
         if (string.IsNullOrWhiteSpace(model.Email))
         {
             return BadRequest(new { Message = "Email-адрес не может быть пустым." });
         }

         if (!model.Email.Contains("@"))
         {
             return BadRequest(new { Message = "Некорректный email-адрес." });
         }
         
         var user = await _userManager.FindByEmailAsync(model.Email); 
         if (user == null)
         {
             return BadRequest(new { Message = "Пользователь с таким email не найден." });
         }
            
         var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            
         var resetLink = $"https://your-app.com/reset-password?email={model.Email}&token={token}";
            
         var emailBody = $"Для сброса пароля перейдите по ссылке: <a href='{resetLink}'>Сбросить пароль</a>";
         await _emailService.SendEmailAsync(model.Email, "Сброс пароля", emailBody);

         return Ok(new { Message = $"Ссылка для сброса пароля отправлена на ваш email. {token}" });
     }

     [HttpPost("reset-password")]
     public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
     {
         var user = await _userManager.FindByEmailAsync(model.Email);
         if (user == null)
         {
             return BadRequest(new { Message = "Пользователь с таким email не найден." });
         }
            
         var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
         if (!result.Succeeded)
         {
             return BadRequest(new { Message = "Не удалось сбросить пароль.", Errors = result.Errors });
         }

         return Ok(new { Message = $"Пароль успешно сброшен. Ваш новый пароль = {model.NewPassword}" });
     }
}