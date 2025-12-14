
using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Services {
    public class SystemErrorService(
         ILogger<SystemErrorService> logger,
         IServiceLocalization localization) 
        : BaseService<SystemErrorService>(logger, localization), ISystemErrorService {
        public async Task<Company> GetDefaultCompanyAsync() {
            return null;
        }

        public string DoSomething(string customerId) {

            using (Logger.BeginScope(new { Channel = "CUSTOMER-SERVICE", Id = customerId })) {
                Logger.LogInformation("Processing customer {CustomerId}", customerId);
                try {
                    return customerId;
                } catch (Exception ex) {
                    Logger.LogError(ex, "Error while processing customer {CustomerId}", customerId);
                    return null;
                }
            }
        }

     }
}
