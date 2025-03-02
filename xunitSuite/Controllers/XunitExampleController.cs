using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xunitSuite.Services;

namespace xunitSuite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XunitExampleController : ControllerBase
    {
        private IPrinterService _printerService;
        private IEmailService _emailService;
        public XunitExampleController(IPrinterService printerServices, IEmailService emailService)
        {
            _printerService = printerServices;
            _emailService = emailService;
        }

        [HttpGet("index/{guessedNumber}")]
        public string Index(int guessedNumber)
        {
            string result;
            if(guessedNumber < 100)
            {
                result =  "Wrong! Try a bigger number.";
            }
            else if (guessedNumber >100)
            {
                result =  "Wrong! Try a smaller number.";
            }
            else
            {
                result =  "You guessed correct number";
            }

            if (_emailService.IsEmailAvailable())
            {
                _emailService.SendEmail();
            }
            if (_printerService.IsPrinterAvailable())
            {
                _printerService.SendPrint("print this message");
            }
            return result;
        }
    }
}
