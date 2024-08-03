using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NotificationSender.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender emailSender;

        public EmailController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="email">Recipient email address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="message">Email message.</param>
        /// <param name="isHtml">Is the email message HTML?</param>
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromForm] string email, [FromForm] string subject, [FromForm] string message, [FromForm] bool isHtml)
        {
            await emailSender.SendEmailAsync(email, subject, message, isHtml);
            return Ok();
        }

        /// <summary>
        /// Sends an email with custom sender, app password, host, and port.
        /// </summary>
        /// <param name="sender">Sender email address.</param>
        /// <param name="appPassword">App password for the sender email.</param>
        /// <param name="host">SMTP host.</param>
        /// <param name="port">SMTP port.</param>
        /// <param name="email">Recipient email address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="message">Email message.</param>
        /// <param name="isHtml">Is the email message HTML?</param>
        [HttpPost("send-custom")]
        public async Task<IActionResult> SendCustomEmail([FromForm] string sender, [FromForm] string appPassword, [FromForm] string host, [FromForm] int port, [FromForm] string email, [FromForm] string subject, [FromForm] string message, [FromForm] bool isHtml)
        {
            await emailSender.SendEmailAsync(sender, appPassword, host, port, email, subject, message, isHtml);
            return Ok();
        }
    }
}
