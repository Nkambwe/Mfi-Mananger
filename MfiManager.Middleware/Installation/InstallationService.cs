using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;
using System.Text.Json;

namespace MfiManager.Middleware.Installation {
    public class InstallationService(ILogger<InstallationService> logger,
                                     IServiceLocalization localization)
        : BaseService<InstallationService>(logger, localization), IInstallationService {

        private const string Channel = "INSTALLATION-SERVICE";

        public async Task<HttpResponse<StatusResponse>> SetupCompanyAsync(InstallRequest requestModel) {
            using (Logger.BeginScope(new { Channel, Id = $"{DateTime.Now:yyyMMddHHmmss}" })) {
                Logger.LogInformation("Processing installation {RegNumber}", requestModel.RegNumber);
                try {
                    if (requestModel == null) {
                        var error = new HttpErrorResponse(
                           400,
                           message: LocalizationService.GetLocalizedLabel("Server.Error.Badrequest"),
                           description: $"Intallation - {LocalizationService.GetLocalizedLabel("Server.Error.Badrequest.Message")}"
                        );
                        Logger.LogInformation("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                        return new HttpResponse<StatusResponse>(error);
                    }

                    return new HttpResponse<StatusResponse>() {
                        Data = new StatusResponse() {
                            Status = true,
                            Message = "Setup completed successfully"
                        }
                    };
                } catch (Exception ex) {
                    Logger.LogError(ex, "Error while processing installtion {RegNumber}", requestModel.RegNumber);

                    HttpErrorResponse error = new(
                        500,
                        message: LocalizationService.GetLocalizedLabel("Server.Error.Critical"),
                        description: LocalizationService.GetLocalizedLabel("System.Error")
                        );
                    return new HttpResponse<StatusResponse>(error);
                }
            }
        }
    }
}
