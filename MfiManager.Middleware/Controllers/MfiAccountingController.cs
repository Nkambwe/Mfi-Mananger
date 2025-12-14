using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/accounting")]
    public class MfiAccountingController(
         ILogger<MfiAccountingController> logger,
         IEnvironmentProvider environment,
         IServiceLocalization localizationService,
         ISystemErrorService errorService,
         ICompanyService companyService)
         : MfiBaseController(logger, environment, localizationService, errorService, companyService) {
        private readonly ILogger<MfiAccountingController> _logger = logger;

        [HttpGet("welcome")]
        public IActionResult AccountingWelcome() {
            return Ok("Accounting says 'Welcome to MFI-Middleware API'");
        }

    }
}
