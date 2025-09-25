using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/files")]
    public class MfiFileController: MfiBaseController  {

        [HttpGet("welcome")]
        public IActionResult FilesWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }
    }
}
