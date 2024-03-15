using SendGrid.Helpers.Mail;
using SendGrid;
using EllipticCurve;

namespace CuppaComfort.Models
{

    public interface IEmailProvider
    {
        Task SendEmailAsync(string toEmail, string subject, string content, string htmlContent);

        public class EmailProviderSendGrid : IEmailProvider
        {
            private readonly IConfiguration _config;
            public EmailProviderSendGrid(IConfiguration config)
            { 
                _config = config;
            }

            public async Task SendEmailAsync(string toEmail, string subject, string content, string htmlContent)
            {
                var apiKey = _config.GetSection("SendGridKey").Value;
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(_config.GetSection("FromEmail").Value),
                    Subject = subject,
                    PlainTextContent = content,
                    HtmlContent = htmlContent
                };
                msg.AddTo(new EmailAddress(toEmail, "Test User"));
                await client.SendEmailAsync(msg);
            }
        }
    }
}
