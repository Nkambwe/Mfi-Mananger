﻿using MfiManager.App.Defaults;
using MfiManager.App.Extensions;
using MfiManager.App.Factories;
using MfiManager.App.Filters;
using MfiManager.App.Http.Mvc;
using MfiManager.App.Infrastructure.Endpoints;
using MfiManager.App.Infrastructure.Extensions;
using MfiManager.App.Infrastructure.Middleware;
using MfiManager.App.Infrastructure.Routes;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            services.Configure<MfiLogging>(_configuration.GetSection(MfiLogging.SectionName));
            services.Configure<MiddlewareOptions>(_configuration.GetSection(MiddlewareOptions.SectionName));
            services.Configure<EndpointTypeOptions>(_configuration.GetSection(EndpointTypeOptions.SectionName));
            services.Configure<LanguageOptions>(_configuration.GetSection(LanguageOptions.SectionName));

            //..register appSettings variable providers
            services.AddScoped<IEnvironmentProvider, EnvironmentProvider>();
            services.AddScoped<IEndpointProvider, EndpointProvider>();
            services.AddScoped<IApplicationLoggerFactory, ApplicationLoggerFactory>();
            services.AddSingleton<ILoggerProvider, ApplicationLoggerProvider>();
            
            //..register factories 
            services.AddScoped<IMfiErrorFactory, MfiErrorFactory>();
            services.AddScoped<IViewErrorFactory, ViewErrorFactory>();
            services.AddScoped<IApplicationLoggerFactory, ApplicationLoggerFactory>();
            services.AddScoped<IInstallationFactory, InstallationFactory>();
            services.AddScoped<ILoginFactory, LoginFactory>();

            //..register session manager
            services.AddScoped<SessionManager>();

            // Add middleware client
            services.AddApiClients(_configuration);

             //..register application session 
            var sessionOptions = _configuration.GetSection("MiddlewareOptions").Get<MiddlewareOptions>();
            int timeOut = sessionOptions?.IdleSessionTime ?? 30;
            services.AddApplicationSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(timeOut);
                options.Cookie.Name = ".Mfi.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            //..add anti-forgery services
            services.AddAntiforgery(options => {
                options.HeaderName = "X-CSRF-TOKEN";
                options.Cookie.Name = "__RequestVerificationToken";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });
            services.AddScoped<MfiAntiForgeryTokenAttribute>();

            //..register appSettings variable providers
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.Cookie.Name = CookieDefaults.UserCookie;
                options.LoginPath = "/login/userlogin";
                options.LogoutPath = "/app/logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });
            services.AddAuthorization();

            //..configure HttpClient middleware client
            var middlewareOptions = _configuration.GetSection("MiddlewareOptions").Get<MiddlewareOptions>();
            services.AddHttpClient("MiddlewareClient", client => {
                var envOptions = _configuration.GetSection("EnvironmentOptions").Get<EnvironmentOptions>();
                
                if (!(bool)envOptions?.IsLive) {
                    //..Configure uat environment
                    if (!string.IsNullOrEmpty(middlewareOptions?.BaseUrl)) {
                        client.BaseAddress = new Uri(middlewareOptions.BaseUrl.TrimEnd('/') + '/');
                    }
                } else {
                     //..Configure production environment
                    if (!string.IsNullOrEmpty(middlewareOptions?.ProdBaseUrl)) {
                        client.BaseAddress = new Uri(middlewareOptions.ProdBaseUrl.TrimEnd('/') + '/');
                    }
                }
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            //..add MVC
            services.AddControllersWithViews();

             //..register services
            services.AddServices();
            
            //..configure razor pages options
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationFormats.Add("/Views/Shared/TagHelpers/{0}.cshtml");
            });

            //..register taghelper
            services.AddScoped<MfiAntiForgeryTokenTagHelper>();

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
            app.UseSession();

            //..add authorization
            app.UseAuthorization();

            //..add session middleware
            var middlewareOptions = _configuration.GetSection("MiddlewareOptions").Get<MiddlewareOptions>();
            int appSessionTime = middlewareOptions?.AppSessionTime ?? 45;
            app.UseApplicationSession(TimeSpan.FromMinutes(appSessionTime));
        
            //..register middleware health monitor
            app.UseMiddleware<MfiHealthCheckMiddleware>();

            //..get localizaed languages
            var LanguageOptions = _configuration.GetSection("LanguageOptions").Get<LanguageOptions>();
            var supportedCultures = LanguageOptions?.SupportedCultures ?? [];
            var localizationOptions = new RequestLocalizationOptions()
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures)
                .SetDefaultCulture(LanguageOptions?.DefaultCulture?? CommonDefaults.DefaultLanguageCulture);

            //..add cookie provider for localization
            localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
            app.UseRequestLocalization(localizationOptions);

            //..register routes
            var routePublisher = app.Services.GetRequiredService<IRoutePublisher>();
            routePublisher.RegisterRoutes(app);
        }
    }
}
