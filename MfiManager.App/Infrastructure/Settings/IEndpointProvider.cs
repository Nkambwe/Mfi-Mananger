using MfiManager.App.Infrastructure.Endpoints;

namespace MfiManager.App.Infrastructure.Settings {
    public interface IEndpointProvider {
        SystemAccessEndpoints Sam { get;}
        HealthEndpoint Health { get; }
        InstallationEndpoints Installation { get; }
        OrganizationEndpoints Organization { get; }
        ActivityLogEndpoints ActivityLog { get; }
        DepartmentEndpoints Departments { get; }
        ErrorEndpoints Error { get; }
    }

}
