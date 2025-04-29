using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = false);
    Task SendEmailAsync(string[] to, string subject, string body, bool isHtml = false);
    Task SendTemplatedEmailAsync(string to, string templateName, object templateData);
    Task SendTemplatedEmailAsync(string[] to, string templateName, object templateData);
} 