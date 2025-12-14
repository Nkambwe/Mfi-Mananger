using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/loans")]
    public class MfiLoansController(ILogger<MfiLoansController> logger,
                                    IEnvironmentProvider environment,
                                    IServiceLocalization localizationService,
                                    ISystemErrorService errorService,
                                    ICompanyService companyService)
                                    : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiLoansController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult LoansWelcome() {
            return Ok("Loans says 'Welcome to MFI-Middleware API'");
        }
    }
}
