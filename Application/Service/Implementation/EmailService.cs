using System.Net.Mail;
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
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_smtpUsername, _smtpPassword));
        email.To.Add(MailboxAddress.Parse(to));
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
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}