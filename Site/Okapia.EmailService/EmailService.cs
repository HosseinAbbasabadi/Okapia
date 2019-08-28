using MailKit.Net.Smtp;
using MimeKit;

namespace Okapia.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Admin", "support@okapia.ir");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };
            message.Body = bodyBuilder.ToMessageBody();
            var client = new SmtpClient();
            client.Connect("smtp.okapia.ir", 25, false);
            client.Authenticate("support@okapia.ir", "OKsup@110");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}