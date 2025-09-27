using MfiManager.Middleware.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/files")]
    public class MfiFileController(IServiceLoggerFactory loggerFactory) : MfiBaseController(loggerFactory)  {
        [HttpGet("welcome")]
        public IActionResult FilesWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }
    }
}
