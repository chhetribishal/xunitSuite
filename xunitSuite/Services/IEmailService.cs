namespace xunitSuite.Services
{
    public interface IEmailService
    {
        public bool IsEmailAvailable();
        public void SendEmail();
    }
}
