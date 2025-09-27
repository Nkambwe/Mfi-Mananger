using MfiManager.Middleware.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/loans")]
    public class MfiLoansController(IServiceLoggerFactory loggerFactory) : MfiBaseController(loggerFactory)  {
        [HttpGet("welcome")]
        public IActionResult LoansWelcome() {
            return Ok("Loans says 'Welcome to MFI-Middleware API'");
        }
    }
}
