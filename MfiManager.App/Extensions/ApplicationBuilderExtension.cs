using MfiManager.App.Infrastructure.Middleware;

namespace MfiManager.App.Extensions {
    public static class ApplicationBuilderExtension {

        public static IApplicationBuilder UseApplicationSession(this IApplicationBuilder app, TimeSpan sessionTimeout)
            => app.UseMiddleware<SessionMiddleware>(sessionTimeout);

    }
}
