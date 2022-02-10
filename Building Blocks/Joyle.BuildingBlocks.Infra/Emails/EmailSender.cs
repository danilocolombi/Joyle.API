using Joyle.BuildingBlocks.Application.Emails;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Joyle.BuildingBlocks.Infra.Emails
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(EmailMessage message)
        {
            try
            {
                var client = new SendGridClient(_configuration.GetSection("SendGridApiKey")?.Value);
                var email = MailHelper.CreateSingleEmail(from: new EmailAddress("danilocolombitavares@gmail.com", "Joyle"),
                    to: new EmailAddress(message.To),
                    message.Subject,
                    message.Content,
                    message.Content);

                await client.SendEmailAsync(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
