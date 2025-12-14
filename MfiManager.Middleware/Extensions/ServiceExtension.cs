using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Configuration.Options;
using MfiManager.Middleware.Cyphers;
using MfiManager.Middleware.Data;
using MfiManager.Middleware.Data.Services;
using MfiManager.Middleware.Data.Transaction;
using MfiManager.Middleware.Data.Transaction.Repositories;
using MfiManager.Middleware.Enums;
using MfiManager.Middleware.Installation;
using MfiManager.Middleware.Logging;
using MfiManager.Middleware.Utils;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Extensions {

    public static class ServiceCollectionExtension {
        /// <summary>
        /// Configure Cors
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void ConfigureCors(this IServiceCollection services) {
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin", builder => {
                    builder.WithOrigins("10.129.2.39")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// Configure Forward Headers
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void ConfigureForwardHeaders(this IServiceCollection services) {
            services.Configure<ForwardedHeadersOptions>(options => {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                // Add known proxies
                options.KnownProxies.Add(System.Net.IPAddress.Parse("127.0.0.1"));

                // trust all networks (NOTE: use only in trusted environments)
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        /// <summary>
        /// Database connection configuration
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration Configuration) {
            //..create logger
            using var provider = services.BuildServiceProvider();
            var loggerFactory = provider.GetRequiredService<IServiceLoggerFactory>();
            var _logger = loggerFactory.CreateLogger("middleware");
            _logger.Channel = $"DBCONNECTION-{DateTime.Now:yyyyMMddHHmmss}";
            _logger.Log("Attempting DB Connection...", "Config");
            try {

                     //..get appSettings environment variable directly
                    var isLive = Configuration.GetValue<bool>("EnvironmentOptions:IsLive");
                    _logger.Log($"ENVIRONMENT ISLIVE >> {isLive}", "Config");

                    //..connection variable name
                    var connectionVar = Configuration.GetValue<string>("ConnectionOptions:DefaultConnection");
                    _logger.Log($"ENVIRONMENT VAR >> {connectionVar}", "Config");

                    if (string.IsNullOrWhiteSpace(connectionVar)){ 
                        string msg = "DB Connection Environment variable name 'MFI_DBCONNECTION_ENV' not found in appSettings";
                        _logger.Log(msg, "Config");
                        throw new Exception(msg);
                    }

                    // connection string
                    var connectionString = Environment.GetEnvironmentVariable(connectionVar);
                    if (string.IsNullOrEmpty(connectionString))
                        throw new Exception($"Environmental variable '{connectionVar}' which holds connection string value not set");

                   var decryptedString = HashGenerator.DecryptString(connectionString);
                   if (isLive) {
                        _logger.Log($"CONNECTION URL :: {connectionString}", "Config");
                   } else {
                        _logger.Log($"CONNECTION URL :: {decryptedString}", "Config");
                   }

                    // get provider from config
                    var dbProviderOptions = Configuration.GetSection(DatabaseProviderOptions.SectionName).Get<DatabaseProviderOptions>();
                     _logger.Log($"DATABASE PROVIDER >> {dbProviderOptions.Provider}", "Config");
                    services.AddDbContextFactory<MfiManagerDbContext>(options => {
                        switch (dbProviderOptions.Provider) {
                            case DatabaseProvider.SqlServer:
                                options.UseSqlServer(decryptedString);
                                break;
                            case DatabaseProvider.PostgreSQL:
                                options.UseNpgsql(decryptedString);
                                break;
                            case DatabaseProvider.Oracle:
                                options.UseOracle(decryptedString);
                                break;
                            default:
                                throw new NotSupportedException($"Unsupported database provider: {dbProviderOptions.Provider}");
                        }
                    });

                    _logger.Log($"Database Provider: {dbProviderOptions.Provider}", "Config");
                    _logger.Log("Data Connection Established", "Config");

            } catch (Exception e) {
                string msg = "Database connection error occurred";
                _logger.Log(msg, "Config");
                _logger.Log($" {e.Message}", "Db-Error");
                _logger.Log($" {e.StackTrace}", "STACKTRACE");

                throw new Exception(msg);
            }
        }

        /// <summary>
        /// Configure Forward Headers
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void Addcaching(this IServiceCollection services, Action<CacheConfiguration> configureCacheSettings = null) {
            //..configure cache settings
            var cacheSettings = new CacheConfiguration();
            configureCacheSettings?.Invoke(cacheSettings);
            services.AddSingleton(cacheSettings);

            services.AddMemoryCache(options => {
                 //..limit cache size
                options.SizeLimit = 1000;
            });

            //..register cache manager as singleton for static caching
            services.AddTransient<IStaticCacheManager, MemoryStaticCacheManager>();
        }

        /// <summary>
        /// Register repositories
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterRepositories(this IServiceCollection services) { 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddScoped<IBranchRepository, BranchRepository>();
            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IDepartmentUnitRepository, DepartmentUnitRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
            //services.AddScoped<IUserPreferenceRepository, UserPreferenceRepository>();
            //services.AddScoped<IAttemptRepository, AttemptRepository>();
            //services.AddScoped<IQuickActionRepository, QuickActionRepository>();
            //services.AddScoped<ISystemErrorRespository, SystemErrorRespository>();
            //services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            //services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            //services.AddScoped<IActivityLogSettingRepository, ActivityLogSettingRepository>();
        }

        /// <summary>
        /// Register UnitOfWork
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterUnitOfWork(this IServiceCollection services) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
        
        /// <summary>
        /// Register Middleware services
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterServices(this IServiceCollection services) { 
            //..register service
            services.AddScoped<IServerFileProvider, ServerFileProvider>();
            services.AddScoped<IPaginationConfigurationService, PaginationConfigurationService>();
            services.AddScoped<IDatabaseVersionCheckerService, DatabaseVersionCheckerService>();
            services.AddScoped<ILoggingConfigService, LoggingConfigService>();
            services.AddScoped<IServiceLocalization, ServiceLocalization>();
            services.AddScoped<IServerWebHelper, ServerWebHelper>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInstallationService, InstallationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ISystemErrorService, SystemErrorService>();
            //services.AddScoped<IActivityLogService, ActivityLogService>();
            //services.AddScoped<IActivityTypeService, ActivityTypeService>();
            //services.AddScoped<IActivityLogSettingService, ActivityLogSettingService>();
            //services.AddScoped<IDepartmentsService, DepartmentsService>();
            //services.AddScoped<IDepartmentUnitService, DepartmentUnitService>();
            //services.AddScoped<IQuickActionService, QuickActionService>();
            
            
        }

    }

}
