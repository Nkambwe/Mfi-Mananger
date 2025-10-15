namespace MfiManager.App.Infrastructure.Routes {
   public class BackofficeRouteProvider : IRouteProvider {
        public int Priority => 100;
        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder) {
            routeBuilder.MapControllerRoute(
                name: "backoffice-dashboard",
                pattern: "/mfi/backoffice/dashboard",  
                defaults: new { area = "BackOffice", controller = "Dashboard", action = "Index" }
            );
            routeBuilder.MapControllerRoute(
                name: "backoffice-reports",
                pattern: "/mfi/backoffice/reports",  
                defaults: new { area = "BackOffice", controller = "Reports", action = "Index" }
            );

            routeBuilder.MapControllerRoute(
                name: "backoffice-default",
                pattern: "/mfi/backoffice/{controller=Dashboard}/{action=Index}/{id?}",
                defaults: new { area = "BackOffice" }
            );
        }
    }
}
