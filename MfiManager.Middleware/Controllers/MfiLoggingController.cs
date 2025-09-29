using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/logging")]
    public class MfiLoggingController(ILogger<MfiLoggingController> logger,
                                      ILoggingConfigService configService) 
                                : MfiBaseController {
        private const string LOG_ID="MFI-LOGCONTROLLER";
        private readonly ILogger<MfiLoggingController> _logger = logger;
        private readonly ILoggingConfigService _configService = configService;
        [HttpGet("welcome")]
        public IActionResult LoggingWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }

        [HttpGet]
        public IActionResult GetSettings() {
            using (_logger.BeginScope(new { Channel = "CONTROLLER", Id = LOG_ID }))
            {
                 _logger.LogInformation("Get logging settings");
                var settings = _configService.GetSettings();
                return Ok(settings);
            }
            
        }

        [HttpPost]
        public IActionResult UpdateSettings([FromBody] ServiceLoggingOption settings) {
            using (_logger.BeginScope(new { Channel = "CONTROLLER", Id = LOG_ID })) {
                 _configService.UpdateSettings(settings);
                _logger.LogInformation("Logging settings updated via API");
                return Ok(new { Message = "Logging settings updated" });
            }
           
        }
    }
}
