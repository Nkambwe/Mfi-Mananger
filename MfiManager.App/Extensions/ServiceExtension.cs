using MfiManager.App.Http;
using MfiManager.App.Http.Mvc;
using MfiManager.App.Infrastructure.Helpers;
using MfiManager.App.Infrastructure.Routes;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MfiManager.App.Extensions {
    public static class ServiceExtension { 
        /// <summary>
        /// Application logging
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddServices(this IServiceCollection services) {

            //register routes
            services.AddSingleton<IRouteProvider, RouteProvider>();
            services.AddSingleton<IRoutePublisher, RoutePublisher>();

            //..sessionExtensions manager
            services.AddScoped<SessionManager>();

            //..register health service
            services.AddScoped<IMfiFileProvider, MfiFileProvider>();
            services.AddScoped<IMfiWorkspaceService, MfiWorkspaceService>();
            services.AddScoped<IApplicationLoggingConfigService, ApplicationLoggingConfigService>();
            services.AddScoped(typeof(IHttpHandler<>), typeof(HttpHandler<>));
            services.AddScoped(typeof(IApplicationBaseService<>), typeof(ApplicationBaseService<>));
            services.AddScoped<ICompanyBranchService, CompanyBranchService>();
            services.AddScoped<IMfiErrorService, MfiErrorService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IInstallService, InstallService>();
            services.AddScoped<ISystemAccesssService, SystemAccesssService>();
            services.AddScoped<ISystemActivityService, SystemActivityService>();
            services.AddScoped<IMiddlewareHealthService, MiddlewareHealthService>();
            services.AddScoped<ILocalizationService, LocalizationService>();

            //..allow html helpers to acces current action context
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IMfiHtml, MfiHtml>();
            services.AddScoped<IWebHelper, WebHelper>();
            return services;
        }

     }
}
