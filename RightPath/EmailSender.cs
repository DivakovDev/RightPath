using Microsoft.AspNetCore.Identity.UI.Services;

namespace RightPath
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //here we can add logic for sending emails for users
            return Task.CompletedTask;
        }
    }
}
