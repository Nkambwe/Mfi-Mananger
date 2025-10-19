using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using System.Text.Json;

namespace MfiManager.App.Services {
    public class MiddlewareHealthService(ILogger<MiddlewareHealthService> logger,
                                         IHttpClientFactory httpClientFactory,
                                         IEndpointProvider endpointProvider)
                                        :  IMiddlewareHealthService {
        private readonly ILogger<MiddlewareHealthService> _logger = logger;
        private readonly IEndpointProvider _endpointProvider =endpointProvider;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<(bool status, bool isConnected, bool hasCompanie)> CheckMiddlewareStatusAsync() {
            try {

                //..build endpoint
                var endpoint = $"{_endpointProvider.Health.Status}";
                _logger.LogInformation("Endpoint: {Endpoint}", endpoint);
                //.. get configured HttpClient
                var httpClient = _httpClientFactory.CreateClient("MiddlewareClient");
                var fullUrl = $"{httpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                _logger.LogInformation("MIDDLEWARE URL: {FullUrl}",fullUrl);

                //..send request
                var response = await httpClient.GetAsync(endpoint);
                _logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                if (!response.IsSuccessStatusCode) {
                    _logger.LogError("Middleware call failed with status: {StatusCode}", response.StatusCode);
                    return (false, false, false);
                }
        
                //..read and deserialize response
                var responseData = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Response Data: {Data}", responseData);
        
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<HealthCheckResponse>(responseData, options);
        
                if (result == null) {
                    _logger.LogInformation("Failed to deserialize response");
                    return (false, false, false);
                }
        
                _logger.LogInformation("Health Check Result - Status: {Status}, Connected: {IsConnected}, HasCompany: {HasCompany}", result.Status,result.IsConnected, result.HasCompany);
                return (result.Status, result.IsConnected, result.HasCompany);
            } catch (HttpRequestException httpEx) {
                _logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                _logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                return (false, false, false);
            } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                _logger.LogError("Request timeout: {Message}", timeoutEx.InnerException.Message);
                _logger.LogCritical("{StackTrace}", timeoutEx.StackTrace);
                return (false, false, false);
            } catch (JsonException jsonEx) {
                _logger.LogError("JSON Deserilization Error: {Message}", jsonEx.Message);  
               _logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
                return (false, false, false);
            } catch (Exception ex)  {
                _logger.LogError("Unexpected Error: {Message}", ex.Message);   
                _logger.LogCritical("{StackTrace}", ex.StackTrace);
                return (false, false, false);
            }
        }

    }

}
