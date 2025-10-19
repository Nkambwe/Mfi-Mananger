using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Configurations.Providers;
using MfiManager.Middleware.Cyphers;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Extensions;
using MfiManager.Middleware.Logging;
using Microsoft.AspNetCore.HttpOverrides;

namespace MfiManager.Middleware {
    public class Startup(IConfiguration configuration) {

        public IConfiguration Configuration { get; } = configuration;

        /// <summary>
        /// Servervice configuration
        /// </summary>
        /// <param name="services">Service collection instance</param>
        public void ConfigureServices(IServiceCollection services) {
            //..get appSettings settings
            services.Configure<EnvironmentOptions>(Configuration.GetSection(EnvironmentOptions.SectionName));
            services.Configure<ServiceLoggingOption>(Configuration.GetSection(ServiceLoggingOption.SectionName));
            services.Configure<UrlOptions>(Configuration.GetSection(UrlOptions.SectionName));
            services.Configure<DataConnectionOptions>(Configuration.GetSection(DataConnectionOptions.SectionName));
            services.Configure<DatabaseProviderOptions>(Configuration.GetSection(DatabaseProviderOptions.SectionName));
            services.Configure<PaginationOptions>(Configuration.GetSection(PaginationOptions.SectionName));
            services.Configure<BulkOperationOptions>(Configuration.GetSection(BulkOperationOptions.SectionName));
            services.Configure<BulkMonitorOptions>(Configuration.GetSection(BulkMonitorOptions.SectionName));


            //..register appSettings provider
            services.AddScoped<IEnvironmentProvider, EnvironmentProvider>();
            services.AddScoped<IServiceLoggerFactory, ServiceLoggerFactory>();
            services.AddSingleton<ILoggerProvider, ServiceLoggerProvider>();
            services.AddScoped<IDataConnectionProvider, DataConnectionProvider>();
            services.AddScoped<IDabaseServiceProvider, DabaseServiceProvider>();
            services.AddScoped<IUrlProvider, UrlProvider>();
            services.AddScoped<IObjectCypher, ObjectCypher>();

            //..add authentication cookies
            services.AddAuthentication("Cookies").AddCookie("Cookies", options => {
                options.Cookie.Name = ".MfiManager.Auth";
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.AddAuthorization();

            //..Mvc configurations
            services.AddRazorPages();
            services.AddEndpointsApiExplorer();
            services.AddControllers().AddJsonOptions(options => {
                //..keep JSON Property names as they are
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //..format JSON data to make it more readable
                options.JsonSerializerOptions.WriteIndented = true;
            });

            //..swagger
            services.AddSwaggerGen(c => {
                c.CustomSchemaIds(type => type.FullName);
            });
 
            //..cross origin configuration
            services.ConfigureCors();
 
            //forward headers
            services.ConfigureForwardHeaders();

            //..configure database connection
            services.ConfigureDatabaseConnection(Configuration);

            //..add memory cache (required for caching)
            services.AddMemoryCache();

            //..add caching
            services.Addcaching(settings => {
                settings.DefaultCacheTime = TimeSpan.FromHours(1);
                settings.ShortTermCacheTime = TimeSpan.FromMinutes(5);
                settings.CacheEnabled = true;
            });

            //..register unit of work
            services.RegisterUnitOfWork();
 
            //..register repositories
            services.RegisterRepositories();

            //..register services
            services.RegisterServices();

            //..http configurations
            services.AddHttpClient();
            services.AddSingleton<IServiceProvider, ServiceProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Configure application builder
        /// </summary>
        /// <param name="app">Web Application instance</param>
        public void Configure(WebApplication app) {
            //..use appSettings environment variable directly
            var isLive = Configuration.GetValue<bool>("EnvironmentOptions:IsLive");
            if (!isLive) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
 
            if (!isLive) {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
 
            app.UseForwardedHeaders(new ForwardedHeadersOptions {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
