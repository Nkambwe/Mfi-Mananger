using MfiManager.App.Infrastructure.Endpoints;
using Microsoft.Extensions.Options;

namespace MfiManager.App.Infrastructure.Settings {
    public class EndpointProvider(IOptions<EndpointTypeOptions> options) : IEndpointProvider {

         private readonly EndpointTypeOptions _options = options.Value; 
        public SystemAccessEndpoints Sam => _options.Sam;

        public HealthEndpoint Health => _options.Health;

        public InstallationEndpoints Installation =>_options.Registration;

        public OrganizationEndpoints Organization => _options.Organization;

        public ActivityLogEndpoints ActivityLog => _options.ActivityLog;

        public DepartmentEndpoints Departments =>_options.Departments;

        public ErrorEndpoints Error => _options.Errors;
    }

}
