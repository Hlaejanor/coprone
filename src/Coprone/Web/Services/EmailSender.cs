using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Web.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await Execute(Part1() + Part2() + Part3(), subject, message, email);
        }

        private string Part1()
        {
            return "SG.aZiTN1a6QCOHR";
        }

        private string Part2()
        {
            return "vNvCy65LQ.suNRn_p5RzDDC2P";
        }

        private string Part3()
        {
            return "vTQQu6H5Nr0okceAlKc5ssFCeAMM";
        }

        private Task Execute(string apiKey, string subject, string message, string email)
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
