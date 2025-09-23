using System.Diagnostics;

namespace MfiManager.Middleware {

    public partial class Program {

        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions() {
                Args = args,
                ContentRootPath = AppContext.BaseDirectory,
                ApplicationName = Process.GetCurrentProcess().ProcessName
            });

            //enable logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            var startup = new Startup(builder.Configuration);

            // calling ConfigureServices method
            startup.ConfigureServices(builder.Services);

            // calling Configure method
            var app = builder.Build();
            startup.Configure(app);

        }
    }

}