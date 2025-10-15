namespace MfiManager.App.Infrastructure.Routes {
    public class RouteProvider : IRouteProvider {
        public int Priority => 0;

        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder) {
            //..root redirect to login page
            routeBuilder.MapGet("/", context =>
            {
                context.Response.Redirect("/mfi/application/login");
                return Task.CompletedTask;
            });

            //..error 500
            routeBuilder.MapControllerRoute(
                name: "500",
                pattern: "/mfi/error/status-500/",
                defaults: new { controller = "Error", action = "Status500" }
            );

            //..error 404
            routeBuilder.MapControllerRoute(
                name: "404",
                pattern: "/mfi/error/status-404/",
                defaults: new { controller = "Error", action = "Status404" }
            );

            //..areas
            routeBuilder.MapControllerRoute(
                name: "areas",
                pattern: "/mfi/{area:exists}/{controller}/{action=Index}/{id?}"
            );

            //..user login
            routeBuilder.MapControllerRoute(
                name: "default",
                pattern: "/mfi/{controller=Application}/{action=Login}/{id?}"
            );
        }
    }
}
