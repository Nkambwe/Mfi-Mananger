namespace MfiManager.App.Infrastructure.Routes {
    /// <summary>
    /// Route Publisher
    /// </summary>
    public interface IRoutePublisher {

        void RegisterRoutes(IEndpointRouteBuilder routeBuilder);
    }
}
