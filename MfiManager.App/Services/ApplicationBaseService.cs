using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Extensions;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using System.Text.Json;

namespace MfiManager.App.Services {

    public class ApplicationBaseService<T> : IApplicationBaseService<T> { 
        protected readonly ILogger<T> Logger;
        protected string LogId {get; set;} = "MFI-MANAGER-APP-SERVICE";
        protected readonly IEnvironmentProvider Environment;
        protected readonly IEndpointProvider EndpointProvider;
        protected readonly IWebHelper WebHelper;
        protected readonly IHttpHandler<T> HttpHandler;
        protected readonly IMfiErrorService ErrorService;
        protected readonly IMfiErrorFactory ErrorFactory;
        protected readonly SessionManager SessionManager;
        protected readonly JsonSerializerOptions JsonOptions;
        
        public ApplicationBaseService(ILogger<T> logger,
                              IHttpHandler<T> httpHandler,
                              IEnvironmentProvider environment,
                              IEndpointProvider endpointType,
                              IMfiErrorService errorService,
                              IMfiErrorFactory errorFactory,
                              IWebHelper webHelper,
                              SessionManager sessionManager) {
            Logger = logger;
            HttpHandler = httpHandler;
            Environment = environment;
            EndpointProvider = endpointType;
            WebHelper = webHelper;
            ErrorService = errorService;
            ErrorFactory = errorFactory;
            SessionManager = sessionManager;
            JsonOptions = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        
        /// <summary>
        /// Method used to process and capture errors to the database
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="source">Error source</param>
        /// <param name="stacktrace">Stack trace for the error</param>
        /// <returns></returns>
        protected async Task<MfiHttpResponse<MfiHttpStatusResponse>> ProcessErrorAsync(string message, string source, string stacktrace) {
             using (Logger.BeginScope(new { Channel = "CONTROLLER", Id = LogId })) {
                var ipAddress = WebHelper.GetCurrentIpAddress();
                var branch = SessionManager.GetWorkspace()?.Branch;
                Logger.LogInformation("WORKSPACE BRANCH: {}", JsonSerializer.Serialize(branch));
                long conpanyId = branch?.OrganizationId ?? 0;
                var errModel = await ErrorFactory.PrepareErrorModelAsync(conpanyId, message, source, stacktrace);
                Logger.LogError("ERROR MODEL: {ErrorModel}", JsonSerializer.Serialize(errModel));
                var response = await ErrorService.SaveSystemErrorAsync(errModel, ipAddress);
                Logger.LogInformation("RESPONSE: {Response}", JsonSerializer.Serialize(response));

                return response;
             }
            
        }
    }
}
