namespace NotificationSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, bool isHtml);
        Task SendEmailAsync(string sender, string appPassword, string host, int port, string email, string subject, string message, bool isHtml);
    }
}
