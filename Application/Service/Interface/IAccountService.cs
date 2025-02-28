using Domain.Models;
using Infrastructure.DTO;

namespace Application.Service.Interface;

public interface IAccountService
{
    public Task<string> RegisterAsync(RegisterDTO model);
    public Task<string> LoginAsync(LoginDTO model);
}