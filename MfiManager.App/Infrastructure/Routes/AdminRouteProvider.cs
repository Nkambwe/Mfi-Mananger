namespace MfiManager.App.Infrastructure.Routes {
    public class AdminRouteProvider : IRouteProvider {
        public int Priority => 110;

        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder) {
            routeBuilder.MapControllerRoute(
                name: "admin-dashboard",
                pattern: "/mfi/admin/dashboard",
                defaults: new { area = "Admin", controller = "Dashboard", action = "Index" }
            );
            
            routeBuilder.MapControllerRoute(
                name: "admin-users",
                pattern: "/mfi/admin/users/{action=Index}/{id?}",
                defaults: new { area = "Admin", controller = "Users" }
            );

            routeBuilder.MapControllerRoute(
                name: "admin-default",
                pattern: "/mfi/admin/{controller=Dashboard}/{action=Index}/{id?}",
                defaults: new { area = "Admin" }
            );
        }
    }
}
