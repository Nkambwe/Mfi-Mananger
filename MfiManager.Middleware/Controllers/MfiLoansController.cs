using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/loans")]
    public class MfiLoansController(ILogger<MfiLoansController> logger) : MfiBaseController  {
        private readonly ILogger<MfiLoansController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult LoansWelcome() {
            return Ok("Loans says 'Welcome to MFI-Middleware API'");
        }
    }
}
