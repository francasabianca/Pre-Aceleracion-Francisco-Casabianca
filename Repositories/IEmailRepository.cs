using System.Threading.Tasks;

namespace AppDisney.Repositories
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(string toEmail);
    }
}
