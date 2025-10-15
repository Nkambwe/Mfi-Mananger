namespace MfiManager.App.Infrastructure.Routes {
    public class RoutePublisher(IEnumerable<IRouteProvider> routeProviders) : IRoutePublisher  {

        private readonly IEnumerable<IRouteProvider> _routeProviders = routeProviders;

        public virtual void RegisterRoutes(IEndpointRouteBuilder routeBuilder) {
            //..register all provided routes
            foreach (var routeProvider in _routeProviders.OrderByDescending(rp => rp.Priority)) {
                routeProvider.RegisterRoutes(routeBuilder);
            }
        }

    }
}
