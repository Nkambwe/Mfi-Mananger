using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/kyc")]
    public class MfiKycController(ILogger<MfiKycController> logger, 
                                  IObjectMapper objectMapper,
                                  ICustomerService customerService,
                                  IEnvironmentProvider environment,
                                  IServiceLocalization localizationService,
                                  ISystemErrorService errorService,
                                  ICompanyService companyService,
                                  IEntityAccessService entityAccessService,
                                  IEncryptionConfigProvider encryptionProvider,
                                  IEntityResolver EntityResolver)
                                : MfiBaseController(logger, objectMapper, environment, localizationService, errorService, 
                                    companyService,entityAccessService,encryptionProvider, EntityResolver) {

        private readonly ILogger<MfiKycController> _logger = logger;
        private readonly ICustomerService _customerService = customerService;
        private const string LOG_ID="MFI-KYCCONTROLLER";

        [HttpGet]
        public async Task<IActionResult> GetCustomer(long id) {
            long companyId=0;
            long branchId=0;

            //..enforce branch/entity access
            if (!EntityAccessService.CanRead(branchId, nameof(Individual)))
                return Forbid();

            //..load entity
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            //..resolve encryption configuration ONCE per request
            var config = EncryptionProvider.GetConfig(companyId, branchId);

            //..decrypt automatically
            var dto = Mapper.Map(customer, config);

            //..return DTO
            return Ok(dto);
        }


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
