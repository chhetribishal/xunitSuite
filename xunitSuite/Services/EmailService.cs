
namespace xunitSuite.Services
{
    public class EmailService : IEmailService
    {
        public bool IsEmailAvailable()
        {
            //some logic to check email service availability
            return true;
        }

        public void SendEmail()
        {
            //some logic to send Emails
        }
    }
}
