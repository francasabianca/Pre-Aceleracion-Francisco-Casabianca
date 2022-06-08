using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace AppDisney.Repositories.Implements
{
    public class EmailRepository : IEmailRepository
    {
        private IConfiguration _configuration;

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("scoutporpuses@gmail.com", "Testing Auth email");
            var subject = "Verify your email";
            var to = new EmailAddress(toEmail);
            var plainTextContent = "Mail sent by SendGrid with C#";
            var htmlContent = "<strong>Mail sent by SendGrid with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
