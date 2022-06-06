using AppDisney.Repositories;
using System.Threading.Tasks;

namespace AppDisney.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _respository;

        public EmailService(IEmailRepository repository)
        {
            _respository = repository;
        }
        public Task SendEmailAsync(string toEmail)
        {
            return _respository.SendEmailAsync(toEmail);
        }
    }
}
