using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Data.Services;

namespace Infrastructure.Extensions.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(string recipientEmail, string subject, string htmlBody)
    {
        var senderEmail = _configuration["EmailSettings:Username"];
        var senderPassword = _configuration["EmailSettings:Password"];
        var smtp = _configuration["EmailSettings:SmtpServer"];
        var port = int.Parse(_configuration["EmailSettings:Port"]);

        SmtpClient smtpClient = new SmtpClient(smtp)
        {
            Port = port,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };

        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress(senderEmail);
            message.To.Add(recipientEmail);
            message.Subject = subject;
            message.Body = htmlBody;
            message.IsBodyHtml = true;
 
            await smtpClient.SendMailAsync(message);
        }
    }
}