using Polly;
using Polly.Extensions.Http;

namespace MfiManager.App.Infrastructure.Extensions {
    public static class HttpClientServiceExtensions {

        public static IServiceCollection AddApiClients(this IServiceCollection services, IConfiguration configuration) {

            //..add Polly for resilience patterns
            services.AddHttpClient("PollyWaitAndRetry")
                .AddPolicyHandler(RetryPolicy)
                .AddPolicyHandler(CircuitBreakerPolicy);

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> RetryPolicy => HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        private static IAsyncPolicy<HttpResponseMessage> CircuitBreakerPolicy => HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
    }
}
