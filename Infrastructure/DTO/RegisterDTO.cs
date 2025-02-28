using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Infrastructure.DTO;

public class RegisterDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    
    public Role Role { get; set; }
}