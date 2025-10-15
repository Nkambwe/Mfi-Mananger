using MfiManager.App.Infrastructure.Routes;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MfiManager.App.Infrastructure.Extensions {
    public static class ServiceExtension {

        /// <summary>
        /// Application logging
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection RegisterServices(this IServiceCollection services) {
            //register routes
            services.AddSingleton<IRouteProvider, RouteProvider>();
            services.AddSingleton<IRoutePublisher, RoutePublisher>();

             //..allow html helpers to acces current action context
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.AddScoped<IGrcHtml, GrcHtml>();
            //services.AddScoped<IWebHelper, WebHelper>();
            return services;
        }

        /// <summary>
        /// Auto Mapper Configurations
        /// </summary>
        /// <param name="services">Service Collection</param>
        //public static void ObjectMapper(this IServiceCollection services) {

        //    var mappingConfig = new MapperConfiguration(mc => {
        //        mc.AddProfile(new MappingProfile());
        //    });

        //    IMapper mapper = mappingConfig.CreateMapper();
        //    services.AddSingleton(mapper);
        //}
    }
}
