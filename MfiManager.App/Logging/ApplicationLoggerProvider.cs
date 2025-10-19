namespace MfiManager.App.Logging {
    public class ApplicationLoggerProvider(IServiceScopeFactory factory):ILoggerProvider {
        private readonly IServiceScopeFactory  _factory = factory ?? throw new ArgumentNullException(nameof(factory));

        public ILogger CreateLogger(string categoryName){
            //..create a scope to resolve scoped dependencies
            var scope = _factory.CreateScope();
            var factory = scope.ServiceProvider.GetRequiredService<IApplicationLoggerFactory>();

            //..log to separate file for each entity
            //return new ServiceLoggerAdapter(factory.CreateLogger(categoryName), categoryName);

            //..log to a single file in appsttings config
            return new ApplicationLoggerAdapter(factory.CreateLogger(), categoryName);
        }

        public void Dispose() { }
    }

}
