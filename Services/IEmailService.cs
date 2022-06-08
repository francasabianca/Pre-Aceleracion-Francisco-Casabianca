using System.Threading.Tasks;

namespace AppDisney.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail);
    }
}
