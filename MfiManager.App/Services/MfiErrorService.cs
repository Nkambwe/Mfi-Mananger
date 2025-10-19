using MfiManager.App.Http;
using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Models;
using System.Text.Json;

namespace MfiManager.App.Services {
    public class MfiErrorService(ILogger<MfiErrorService> logger,
                                 IHttpHandler<MfiErrorService> httpHandler,
                                 IEndpointProvider endpointType) : IMfiErrorService {
        private readonly ILogger<MfiErrorService> _logger = logger;
        private readonly IHttpHandler<MfiErrorService> _httpHandler = httpHandler;
        private readonly IEndpointProvider _endpointType = endpointType;

        public async Task<MfiHttpResponse<SystemErrorResponse>> GetDepartmentById(MfiHttpIdRequest request) {
            _logger.LogInformation($"Get department record");

            try{
               var endpoint = $"{_endpointType.Error.ErrorById}";
                return await _httpHandler.PostAsync<MfiHttpIdRequest, SystemErrorResponse>(endpoint, request);
            } catch (Exception ex) {
                _logger.LogInformation("Error retrieving department record: {Message}", ex.Message);
                _logger.LogError("DEPARTMENT-SERVICE: {StackTrace}" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(500,
                    "Error retrieving department record",
                    ex.Message
                );

                return new MfiHttpResponse<SystemErrorResponse>(error);
            }
        }

        public async Task<MfiHttpResponse<PagedResponse<SystemErrorResponse>>> GetPagedSystemErrorsAsync(MfiHttpListRequest request) {
             //..validate input
            if(request == null) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "Request record cannot be empty",
                    "Error object is null and cannot be saved"
                );
                _logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<PagedResponse<SystemErrorResponse>>(error);
            }

            try{
               var endpoint = $"{_endpointType.Error.AllErrors}";
                return await _httpHandler.PostAsync<MfiHttpListRequest, PagedResponse<SystemErrorResponse>>(endpoint, request);
            } catch (Exception ex) {
                _logger.LogError("Error retrieving all activities: {Message}", ex.Message);
                _logger.LogError("SYSTEMACTIVITY-SERVICE: {StackTrace}" , ex.StackTrace);
                var error = new MfiHttpErrorResponse(500,
                    "Error retrieving list of system errors",
                    ex.Message
                );
                 _logger.LogInformation("System Error: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<PagedResponse<SystemErrorResponse>>(error);
            }
        }

        public async Task<MfiHttpResponse<MfiHttpStatusResponse>> SaveSystemErrorAsync(MfiErrorModel model, string ipAddress) {
            //..validate input
            if(model == null) {
                var error = new MfiHttpErrorResponse(
                    400,
                    "Request record cannot be empty",
                    "Error object is null and cannot be saved"
                );
                _logger.LogError("BAD REQUEST: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
            }

            try {
                //..map request
                _logger.LogInformation("REQUEST MODEL: {Model}",JsonSerializer.Serialize(model));
                var request = Mapper.ToSystemErrorRequest(model, ipAddress);
                _logger.LogInformation("REQUEST OBJECT: {Request}", JsonSerializer.Serialize(request));

                //..build endpoint
                var endpoint = $"{_endpointType.Error.CaptureError}";
                _logger.LogInformation("Endpoint: {Endpoint}", endpoint);
        
                return await _httpHandler.PostAsync<SystemErrorRequest, MfiHttpStatusResponse>(endpoint, request);
            } catch (HttpRequestException httpEx) {
                _logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                _logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                var error = new MfiHttpErrorResponse(
                    502,
                    "Network error occurred",
                    httpEx.Message
                );
                 _logger.LogInformation("System Error: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
        
            } catch (Exception ex)  {
                _logger.LogError("Unexpected Error: {Message}", ex.Message);    
                _logger.LogCritical("{StackTrace}", ex.StackTrace);
                var error = new MfiHttpErrorResponse(
                    500,
                    "An unexpected error occurred",
                    "Cannot proceed! An error occurred, please try again later"
                );
                 _logger.LogInformation("System Error: {Error}", JsonSerializer.Serialize(error));
                return new MfiHttpResponse<MfiHttpStatusResponse>(error);
            }
        }

    }
}
