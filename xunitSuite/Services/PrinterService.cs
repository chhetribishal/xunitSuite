
namespace xunitSuite.Services
{
    public class PrinterService:IPrinterService
    {
        public bool IsPrinterAvailable()
        {
            //some logic to check email service availability
            return true;
        }

        public void SendPrint(string content)
        {
            //some logic to send Emails
        }
    }
}
