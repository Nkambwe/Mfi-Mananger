using MfiManager.App.Services;

namespace MfiManager.App.Infrastructure.Middleware {
    /// <summary>
    /// Custom midlleware class to manage Health Checks
    /// </summary>
    public class MfiHealthCheckMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<MfiHealthCheckMiddleware> _logger;

        public MfiHealthCheckMiddleware(RequestDelegate next, ILogger<MfiHealthCheckMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {

            string path = context.Request.Path.ToString().ToLower();
        
            if (path == "/" || path == "/login" || path == "/userlogin") {
                _logger.LogInformation("Health check middleware triggered for path: {Path}", path);
            
                // Get health service from current scope
                var healthCheckService = context.RequestServices.GetRequiredService<IMiddlewareHealthService>();
            
                try {
                    var (status, isConnected, hasCompanies) = await healthCheckService.CheckMiddlewareStatusAsync();
                
                    _logger.LogInformation("Health check results - Status: {Status}, Connected: {Connected}, HasCompanies: {HasCompanies}", 
                        status, isConnected, hasCompanies);
                
                    if (!status || !isConnected) {
                        _logger.LogWarning("Redirecting to /mfi/error/status-503 - Status: {Status}, Connected: {Connected}", status, isConnected);
                        context.Response.Redirect("/mfi/error/status-503");
                        return;
                    } 
                
                    if (!hasCompanies) {
                        _logger.LogInformation("No companies found, redirecting to /org/register");
                        context.Response.Redirect("/org/register");
                        return;
                    }
                
                    _logger.LogInformation("Health check passed, redirecting to /login/userlogin");
                    context.Response.Redirect("/login/userlogin");
                    return;
                } catch (Exception ex) {
                    _logger.LogError(ex, "Error during health check");
                    context.Response.Redirect("/mfi/error/status-503");
                    return;
                }
            }
        
            await _next(context);
        }
    }
}
