using System.Net.Mail;
using System.Text;
using Application.Service.Interface;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Application.Service.Implementation;

public class EmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public EmailService(IConfiguration config)
    {
        _smtpServer = config["EmailSettings:SmtpServer"];
        _smtpPort = config.GetValue<int>("EmailSettings:SmtpPort");
        _smtpUsername = config["EmailSettings:SmtpUsername"];
        _smtpPassword = config["EmailSettings:SmtpPassword"];
    }
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        if (string.IsNullOrWhiteSpace(to))
        {
            throw new ArgumentException("Email-адрес не может быть пустым.");
        }

        if (!to.Contains("@"))
        {
            throw new ArgumentException("Некорректный email-адрес.");
        }
        Console.WriteLine($"Отправка email на адрес: '{to}'");
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(Encoding.UTF8, subject, _smtpUsername));
        email.To.Add(new MailboxAddress(Encoding.UTF8, "", to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = body };
        
        if (!IsValidEmail(to))
        {
            throw new ArgumentException("Некорректный email-адрес.");
        }
        
        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_smtpUsername, _smtpPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
    
    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}