using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/accounting")]
    public class MfiAccountingController: MfiBaseController  {

        [HttpGet("welcome")]
        public IActionResult AccountingWelcome() {
            return Ok("Accounting says 'Welcome to MFI-Middleware API'");
        }
    }
}
