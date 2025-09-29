namespace MfiManager.Middleware.Data.Services {
    public abstract class BaseService(ILogger logger) {
        protected readonly ILogger _logger = logger;
    }
}
