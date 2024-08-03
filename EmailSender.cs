using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationSender
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message, bool isHtml)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("@gmail.com", "")
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("test@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = isHtml  // Use parameter to determine HTML content
            };

            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }

        public Task SendEmailAsync(string sender, string appPassword, string host, int port, string email, string subject, string message, bool isHtml)
        {
            var client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender, appPassword)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(sender),
                Subject = subject,
                Body = message,
                IsBodyHtml = isHtml  // Use parameter to determine HTML content
            };

            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }
    }
}
