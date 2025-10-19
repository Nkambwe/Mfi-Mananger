using MfiManager.App.Infrastructure.Endpoints;

namespace MfiManager.App.Infrastructure.Settings {
    public class EndpointTypeOptions {

        public const string SectionName = "EndpointTypeOptions";
        public SystemAccessEndpoints Sam { get; set; } = new();
        public HealthEndpoint Health { get; set; } = new();
        public InstallationEndpoints Registration { get; set; } = new();
        public ErrorEndpoints Errors { get; set; } = new();
        public ActivityLogEndpoints ActivityLog { get; set; } = new();
        public DepartmentEndpoints Departments { get; set; } = new();
        public OrganizationEndpoints Organization { get; set; } = new();
    }
}
