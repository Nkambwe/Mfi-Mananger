using MfiManager.App.Infrastructure.Extensions;
using MfiManager.App.Infrastructure.Routes;
using MfiManager.App.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace MfiManager.App {
    public class Startup(IConfiguration configuration) {

        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// Service configuration
        /// </summary>
        /// <param name="services">Service Interface</param>
        public void ConfigureServices(IServiceCollection services) {
            //..register appSettings variable options
            services.Configure<MFIEnvironment>(_configuration.GetSection(MFIEnvironment.SectionName));
            services.Configure<MFILogging>(_configuration.GetSection(MFILogging.SectionName));

            //..register appSettings variable providers
            services.AddScoped<IEnvironmentProvider, EnvironmentProvider>();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
            //    options.Cookie.Name = CookieDefaults.UserCookie;
            //    options.LoginPath = "/login/userlogin";
            //    options.LogoutPath = "/app/logout";
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.SlidingExpiration = true;
            //});
            services.AddAuthorization();
            //..add MVC
            services.AddControllersWithViews();
             //..register services
            services.RegisterServices();
            
            //..configure razor pages options
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationFormats.Add("/Views/Shared/TagHelpers/{0}.cshtml");
            });

            //..register taghelper
            //services.AddScoped<MFIAntiForgeryTokenTagHelper>();

            //..add logging 
            services.AddLogging(builder => {
                builder.AddConsole();
                builder.AddDebug();
            });
        }

        /// <summary>
        /// Configure application builder
        /// </summary>
        /// <param name="app">Application buildr instance</param>
        /// <returns></returns>
        public void Configure(WebApplication app) { 
            //..debug service registration
            //using (var scope = app.Services.CreateScope()) {
            //    ServiceRegistrationDebugger.LogRegisteredServices(scope.ServiceProvider);
            //}
        
            //..use appSettings environment variable directly
            var envOptions = _configuration.GetSection("MFIEnvironment").Get<MFIEnvironment>();
            if (!(bool)envOptions?.IsLive) {
                app.UseExceptionHandler("/mfi/error/status-500");
                app.UseHsts();
            } else {
                app.UseDeveloperExceptionPage();
            }

            //..handle 404 errors
            app.UseStatusCodePagesWithReExecute("/mfi/error/status-404");

        
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            //..add session
            //app.UseSession();

            //..add authorization
            app.UseAuthorization();
        
            //..add session middleware
            //var middlewareOptions = _configuration.GetSection("MiddlewareOptions").Get<MiddlewareOptions>();
            //int appSessionTime = middlewareOptions?.AppSessionTime ?? 45;
            //app.UseApplicationSession(TimeSpan.FromMinutes(appSessionTime));
        
            //..register middleware health monitor
            //app.UseMiddleware<HealthCheckMiddleware>();

            //..get localizaed languages
            //var LanguageOptions = _configuration.GetSection("LanguageOptions").Get<LanguageOptions>();
            //var supportedCultures = LanguageOptions?.SupportedCultures ?? Array.Empty<string>();
            //var localizationOptions = new RequestLocalizationOptions()
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures)
            //    .SetDefaultCulture(LanguageOptions?.DefaultCulture?? CommonDefaults.DefaultLanguageCulture);

            //..add cookie provider for localization
            //localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
            //app.UseRequestLocalization(localizationOptions);
            //..register routes
            var routePublisher = app.Services.GetRequiredService<IRoutePublisher>();
            routePublisher.RegisterRoutes(app);
        }
    }
}
