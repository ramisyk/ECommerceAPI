using System.Net;
using System.Net.Mail;
using System.Text;
using ECommerceAPI.Application.Services;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Infrastructure.Services;

public class MailService : IMailService
{
    readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
    {
        await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
    }

    public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
    {
        MailMessage mail = new();
        mail.IsBodyHtml = isBodyHtml;
        foreach (var to in tos)
            mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.From = new(_configuration["Mail:Username"]!, "ECommerce", System.Text.Encoding.UTF8);

        SmtpClient smtp = new();
        smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
        smtp.Port = Convert.ToInt32(_configuration["Mail:Port"]);
        smtp.EnableSsl = true;
        smtp.Host = _configuration["Mail:Host"]!;
        await smtp.SendMailAsync(mail);
    }

    public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
    {
        StringBuilder mail = new();
        mail.AppendLine("Hi!<br>If you have requested a new password, you can renew your password from the link below.<br><strong><a target=\"_blank\" href=\"");
        mail.AppendLine(_configuration["AngularClientUrl"]);
        mail.AppendLine("/update-password/");
        mail.AppendLine(userId);
        mail.AppendLine("/");
        mail.AppendLine(resetToken);
        mail.AppendLine("\">Click to request a new password...</a></strong><br><br><span style=\"font-size:12px;\">NOTE: If this request has not been fulfilled by you, please do not take this e-mail seriously.</span><br>Best Regards...<br><br><br>ECommerce");
        
        await SendMailAsync(to, "Update Password Request", mail.ToString());
    }
}