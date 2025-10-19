using Microsoft.AspNetCore.Mvc.Filters;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Logging;
using System.Text.Json;
using MfiManager.App.Services;

namespace MfiManager.App.Filters {
    public class LogActivityResultAttribute(string activityType, string comment = null, 
        string systemKeyword = null, string entityName = null) 
        : Attribute, IAsyncResultFilter {
        private readonly string _activityType = activityType;
        private readonly string _comment = comment;
        private readonly string _systemKeyword = systemKeyword;
        private readonly string _entityName = entityName;

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
            await next();

            IApplicationLogger logger = null;
            try {
                //..create logger
                var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<IApplicationLoggerFactory>();
                logger = loggerFactory.CreateLogger();

                //..get user IP Address
                var webHelper = context.HttpContext.RequestServices.GetRequiredService<IWebHelper>();
                string ipAddress = webHelper.GetCurrentIpAddress();
                
                //..get user info
                var authService = context.HttpContext.RequestServices.GetRequiredService<ISystemAccesssService>();
                var grcResponse = await authService.GetCurrentUserAsync(ipAddress);
                
                if (grcResponse.HasError) {
                    logger.Log($"ACTIVITY LOG ERROR: Failed to get current user - {JsonSerializer.Serialize(grcResponse)}");
                    return;
                }
                
                var userId = grcResponse.Data.Id;
                var activityService = context.HttpContext.RequestServices.GetRequiredService<ISystemActivityService>();
                
                var comment = _comment ?? $"{context.ActionDescriptor.DisplayName} Successfully completed";
                await activityService.InsertActivityAsync(userId, _activityType, comment, _systemKeyword, _entityName, ipAddress);

                //...activity logging
                logger.Log($"ACTIVITY LOGGED: {_activityType} for user {userId}");
            
            } catch (Exception ex) {
                if (logger != null) {
                    logger.Log($"ACTIVITY LOG EXCEPTION: Failed to log activity {_activityType} - {JsonSerializer.Serialize(new { 
                        Error = ex.Message,
                        ex.StackTrace,
                        ActivityType = _activityType,
                        SystemKeyword = _systemKeyword,
                        EntityName = _entityName
                    })}");
                } else {
                    //..fallback to default logger if custom logger creation failed
                    var fallbackLogger = context.HttpContext.RequestServices.GetService<ILogger<LogActivityResultAttribute>>();
                    fallbackLogger?.LogError(ex, "Failed to log activity: {ActivityType}", _activityType);
                }
            }
        }
    }
}
