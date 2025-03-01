using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace xunitSuite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XunitExampleController : ControllerBase
    {
        [HttpGet("index/{guessedNumber}")]
        public string Index(int guessedNumber)
        {
            if(guessedNumber < 100)
            {
                return "Wrong! Try a bigger number.";
            }
            else if (guessedNumber >100)
            {
                return "Wrong! Try a smaller number.";
            }
            else
            {
                return "You guessed correct number";
            }
        }
    }
}
