namespace Application.Service.Interface;

public interface IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body);
}