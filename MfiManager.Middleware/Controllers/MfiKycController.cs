using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/kyc")]
    public class MfiKycController(ILogger<MfiKycController> logger, 
                                  IEnvironmentProvider environment,
                                  ICustomerService customerService) 
        : MfiBaseController(logger, environment) {
        private readonly ILogger<MfiKycController> _logger = logger;
        private readonly ICustomerService _customerService = customerService;
        private const string LOG_ID="MFI-KYCCONTROLLER";

        [HttpGet("welcome")]
        public IActionResult KycWelcome() {
            using (_logger.BeginScope(new { Channel = "CONTROLLER", Id = LOG_ID }))
            {
                string name = "John Doe";
                _logger.LogInformation("Received request for customer {Name}", name);
                return Ok("Kyc says 'Welcome to MFI-Middleware API'");
            }
           
        }

        [HttpGet("doSomething")]
        public IActionResult DoSomething() {
            using (_logger.BeginScope(new { Channel = "CONTROLLER", Id = LOG_ID }))
            {
                string code = "KYC-1002";
                _logger.LogInformation("Received request for customer {Id}", code);
               return Ok(_customerService.DoSomething("Hello from MFI-Middleware"));
            }
            
        }
    }
}
