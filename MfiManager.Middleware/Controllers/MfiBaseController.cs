using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi")]
    public class MfiBaseController(ILogger<MfiBaseController> logger, IEnvironmentProvider environment) : ControllerBase {

            protected readonly ILogger<MfiBaseController> Logger = logger;
            protected readonly IEnvironmentProvider Environment = environment;
    }
}
