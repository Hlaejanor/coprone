using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Web.Services
{
    public static class EmailService
    {
        public static Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute("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", subject, message, email);
        }

        private static Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@coprone.com"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
