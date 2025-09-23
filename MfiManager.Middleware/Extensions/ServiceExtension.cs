using MfiManager.Middleware.Configuration;
using MfiManager.Middleware.Cyphers;
using MfiManager.Middleware.Data;
using MfiManager.Middleware.Factories;
using MfiManager.Middleware.Helpers;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Extensions {

    public static class ServiceCollectionExtension {
        /// <summary>
        /// Configure AutoMapper
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterAutoMapper(this IServiceCollection services) {
             services.AddAutoMapper(cfg => {
                cfg.AddProfile<MappingProfile>();
             });
        }

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
            var _logger = loggerFactory.CreateLogger("middleware_log");
            _logger.Channel = $"DBCONNECTION-{DateTime.Now:yyyyMMddHHmmss}";
            _logger.Log("Attempting DB Connection...", "Config");
            try {

                //..connection variable name
                var connectionVar = Configuration.GetValue<string>("ConnectionOptions:DefaultConnection");

                if (!string.IsNullOrWhiteSpace(connectionVar)) {
                    //..get appSettings environment variable directly
                    var isLive = Configuration.GetValue<bool>("EnvironmentOptions:IsLive");
                    services.AddDbContextFactory<MfiManagerDbContext>(options => {

                        //Retrieve the connection string from environment variables
                        string connectionString = Environment.GetEnvironmentVariable(connectionVar);

                        if (!string.IsNullOrEmpty(connectionString)) {
                            string decryptedString = HashGenerator.DecryptString(connectionString);

                            if (isLive) {
                                _logger.Log($"CONNECTION URL :: {connectionString}", "INFO");
                            } else {
                                _logger.Log($"CONNECTION URL :: {decryptedString}", "INFO");
                            }

                            options.UseSqlServer(decryptedString);
                            _logger.Log("Data Connection Established", "Config");
                        } else {
                            string msg = "Environmental variable name 'MFI_DBCONNECTION_ENV' which holds connection string not found";
                            _logger.Log(msg, "DB_ERROR");
                            throw new Exception(msg);
                        }

                    });
                    _logger.Log($"DB Connection Established...", "Config");
                } else {
                    string msg = "DB Connection Environment variable name 'MFI_DBCONNECTION_ENV' not found in appSettings";
                    _logger.Log(msg, "Db-Error");
                    throw new Exception(msg);
                }

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
            services.AddSingleton<IStaticCacheManager, MemoryStaticCacheManager>();
        }

        /// <summary>
        /// Register repositories
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterRepositories(this IServiceCollection services) { 
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
        
        /// <summary>
        /// Register Middleware services
        /// </summary>
        /// <param name="services">Service instance</param>
        public static void RegisterServices(this IServiceCollection services) { 
            //..register service
            //services.AddScoped<IBaseService, BaseService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            //services.AddScoped<IBranchService, BranchService>();
            //services.AddScoped<ISystemAccessService, SystemAccessService>();
            //services.AddScoped<IActivityLogService, ActivityLogService>();
            //services.AddScoped<IActivityTypeService, ActivityTypeService>();
            //services.AddScoped<IActivityLogSettingService, ActivityLogSettingService>();
            //services.AddScoped<IDepartmentsService, DepartmentsService>();
            //services.AddScoped<IDepartmentUnitService, DepartmentUnitService>();
            //services.AddScoped<IQuickActionService, QuickActionService>();
        }

    }

}
