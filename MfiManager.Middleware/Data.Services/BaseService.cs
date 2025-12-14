namespace MfiManager.Middleware.Data.Services {
    public abstract class BaseService<T>(
        ILogger<T> logger, 
        IServiceLocalization localization) {
        protected readonly IServiceLocalization LocalizationService = localization;
        protected readonly ILogger<T> Logger = logger;
    }
}
