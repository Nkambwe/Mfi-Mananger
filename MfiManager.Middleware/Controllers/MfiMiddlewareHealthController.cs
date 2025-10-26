using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Controllers {

    /// <summary>
    /// Controller handles health checks on middleware API and informs the client of middleware state
    /// </summary>
    [ApiController]
    [Route("mfi")]
    public class MfiMiddlewareHealthController(
        ILogger<MfiMiddlewareHealthController> logger,
        IEnvironmentProvider environment,
        IDbContextFactory<MfiManagerDbContext> contextFactory,
        IConfiguration configuration) : ControllerBase {
        protected readonly ILogger<MfiMiddlewareHealthController> Logger = logger;
        protected readonly IEnvironmentProvider Environment;
        private readonly IDbContextFactory<MfiManagerDbContext> _contextFactory = contextFactory;
        private readonly IConfiguration _configuration = configuration;
        private readonly IEnvironmentProvider _environment = environment;

        [HttpGet("health/checkstatus")]
        public async Task<IActionResult> CheckDatabaseConnection() {
            Logger.LogInformation("=== Starting database health check ===");
        
            try {
                using var dbContext = _contextFactory.CreateDbContext();
                var connectionString = dbContext.Database.GetConnectionString();
                //..log connection string details (mask sensitive parts)
                var maskedConnectionString = MaskValue(connectionString);
                Logger.LogInformation("Using connection string: {ConnectionString}", (_environment.IsLive? maskedConnectionString: connectionString));
                Logger.LogInformation("Database provider: {ProviderName}", dbContext.Database.ProviderName);
            
            } catch (Exception ex) {
                Logger.LogError("Error getting connection string: {Message}", ex.Message);
                Logger.LogError("Stack trace: {StackTrace}", ex.StackTrace);
            }
        
            //..default hasCompanies to false
            bool hasCompanies = false;
            bool canConnect = false;
            string errorDetails = "";
        
            try {
                Logger.LogInformation("Creating database context...");
                using var dbContext = _contextFactory.CreateDbContext();
            
                Logger.LogInformation("Testing database connection...");
                canConnect = await dbContext.Database.CanConnectAsync();
                Logger.LogInformation("CanConnectAsync() result: {canConnect}", canConnect);

                if (canConnect) {
                    Logger.LogInformation("Connection successful! Checking for organizations...");
                    try {
                        hasCompanies = await dbContext.Organizations.AnyAsync();
                        Logger.LogInformation("Organizations found: {HasCompanies}", hasCompanies);
                    } catch (Exception orgEx) {
                        Logger.LogError("Error checking organizations: {Message}", orgEx.Message);
                        //..still return connection as true since we can connect, just can't query
                        Logger.LogCritical("{StackTrace}", orgEx.StackTrace);
                    }
                
                    Logger.LogInformation("Final result: {{status:true, isConnected:true, hasCompanies:{HasCompanies}}}", hasCompanies);
                } else {
                    Logger.LogWarning("Database connection failed");

                    try {
                        //..try to get more details about why connection failed
                        await dbContext.Database.OpenConnectionAsync();
                        Logger.LogWarning("OpenConnectionAsync succeeded despite CanConnectAsync being false");
                    } catch (Exception connEx) {
                        Logger.LogError("OpenConnectionAsync failed: {Message}", connEx.Message);
                        if (connEx.InnerException != null) {
                            Logger.LogError("Inner exception: {Message}", connEx.InnerException.Message);
                        }
                        Logger.LogCritical("OpenConnectionAsync failed: {StackTrace}", connEx.StackTrace);
                    }

                    var statusValue = true;
                    var isConnectedValue = false;
                    var hasCompaniesValue = false;
                    Logger.LogInformation("Final result: {{status:{StatusValue}, isConnected:{IsConnectedValue}, hasCompanies:{HasCompaniesValue}}",statusValue,isConnectedValue,hasCompaniesValue);
                }
            } catch (Exception ex) {
                 Logger.LogError("Exception during health check: {Message}", ex.Message);
                 Logger.LogInformation("Exception type: {Name}", ex.GetType().Name);
                 Logger.LogCritical("Stack trace: {StackTrace}", ex.StackTrace);
            
                if (ex.InnerException != null) {
                     Logger.LogError("Inner exception: {Message}", ex.InnerException.Message);
                     Logger.LogCritical("Inner exception type: {Name}", ex.InnerException.GetType().Name);
                }
            
                errorDetails = ex.Message;
                var statusValue = false;
                var isConnectedValue = false;
                var hasCompaniesValue = false;
                Logger.LogInformation("Final result: {{status:{StatusValue}, isConnected:{IsConnectedValue}, hasCompanies:{HasCompaniesValue}}",statusValue,isConnectedValue,hasCompaniesValue);
            }
        
            Logger.LogInformation("=== Database health check completed ===");
        
            var result = new { 
                status = true, 
                isConnected = canConnect, 
                hasCompanies,
                errorDetails = string.IsNullOrEmpty(errorDetails) ? null : errorDetails,
                timestamp = DateTime.UtcNow
            };
        
            return Ok(result);
        }
    
        /// <summary>
        /// Mask Value in connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns></returns>
        private static string MaskValue(string connectionString) {
            if (string.IsNullOrEmpty(connectionString)) return "NULL";
        
            // Mask sensitive information in connection string
            var parts = connectionString.Split(';');
            var maskedParts = new List<string>();
        
            foreach (var part in parts) {
                var trimmedPart = part.Trim();
                if (trimmedPart.StartsWith("Password=", StringComparison.OrdinalIgnoreCase) ||
                    trimmedPart.StartsWith("Pwd=", StringComparison.OrdinalIgnoreCase)) {
                    maskedParts.Add("Password=***MASKED***");
                } else if (trimmedPart.StartsWith("User ID=", StringComparison.OrdinalIgnoreCase) ||
                           trimmedPart.StartsWith("UID=", StringComparison.OrdinalIgnoreCase)) {
                    var userPart = trimmedPart.Split('=');
                    if (userPart.Length > 1) {
                        maskedParts.Add($"{userPart[0]}={userPart[1].Substring(0, Math.Min(2, userPart[1].Length))}***");
                    }
                } else {
                    maskedParts.Add(trimmedPart);
                }
            }
        
            return string.Join("; ", maskedParts);
        }
    }
}
