namespace xunitSuite.Services
{
    public interface IPrinterService
    {
        public bool IsPrinterAvailable();
        public void SendPrint(string content);
    }
}
