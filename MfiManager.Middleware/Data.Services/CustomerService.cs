namespace MfiManager.Middleware.Data.Services {
    public class CustomerService(ILogger<CustomerService> logger) : BaseService(logger),ICustomerService {
        public string DoSomething(string customerId) {
            using (_logger.BeginScope(new { Channel = "CUSTOMER-SERVICE", Id = customerId })) {
                _logger.LogInformation("Processing customer {CustomerId}", customerId);

                try {
                    return customerId;
                } catch (Exception ex) {
                    _logger.LogError(ex, "Error while processing customer {CustomerId}", customerId);
                    return null;
                }
            }
        }
    }
}
