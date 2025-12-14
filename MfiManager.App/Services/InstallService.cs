using MfiManager.App.Factories;
using MfiManager.App.Http;
using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Models;
using System.Text.Json;

namespace MfiManager.App.Services {

    public class InstallService(ILogger<InstallService> logger,
                        IHttpHandler<InstallService> httpHandler,
                        IEnvironmentProvider environment,
                        ILocalizationService localizationService, 
                        IEndpointProvider endpointType,
                        IMfiErrorService errorService,
                        IMfiErrorFactory errorFactory,
                        IWebHelper webHelper,
                        SessionManager sessionManager)
        : ApplicationBaseService<InstallService>(logger, httpHandler, environment, endpointType,
            errorService, errorFactory, webHelper, localizationService, sessionManager), IInstallService {

        public async Task<MfiHttpResponse<MfiHttpStatusResponse>> RegisterCompanyAsync(InstallationModel model, string ipAddress) {
            //..validate input
            if(model == null) {
                var error = new MfiHttpErrorResponse(
                    400,
                    LocalizationService.GetLocalizedLabel("App.Request.Bad"),
                    LocalizationService.GetLocalizedLabel("App.Installation.Error.InvalidData")
                );
        
                Logger.LogInformation("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
            }

            try {
                //..map request
                Logger.LogInformation("REQUEST MODEL: {Model}", JsonSerializer.Serialize(model));
                var request = Mapper.ToInstallationRequest(model);
                request.IPAddress = ipAddress;

                if (request.DatabaseProvider.Equals("Oracle", StringComparison.Ordinal)) {
                    request.MinimumVersion = "21";
                } else if (request.DatabaseProvider.Equals("PostgreSQL", StringComparison.Ordinal)) {
                    request.MinimumVersion = "12";
                } else { 
                     request.MinimumVersion = "2012";
                }
                
                //..build endpoint
                var endpoint = $"{EndpointProvider.Installation.Install}";
                Logger.LogInformation("Endpoint: {Endpoint}", endpoint);
        
                return await HttpHandler.PostAsync<InstallationRequest, MfiHttpStatusResponse>(endpoint, request);
            } catch (HttpRequestException httpEx) {
                Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                Logger.LogCritical("{Stacktrace}", httpEx.StackTrace);
                await ProcessErrorAsync(httpEx.Message,"INSTALL-SERVICE" , httpEx.StackTrace);
                var error = new MfiHttpErrorResponse(
                    502,
                    LocalizationService.GetLocalizedLabel("App.Error.Network"),
                    httpEx.Message
                );
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
        
            } catch (Exception ex)  {
                Logger.LogError("HTTP Request Error: {Message}", ex.Message);
                Logger.LogCritical("{Stacktrace}", ex.StackTrace);
                await ProcessErrorAsync(ex.Message,"INSTALL-SERVICE" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(
                    500,
                    LocalizationService.GetLocalizedLabel("App.Error.Server"),
                    LocalizationService.GetLocalizedLabel("App.Error.Server.Message")
                );
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
            }
        }
    }

}
