namespace MfiManager.App.Infrastructure.Settings {
    public interface IEnvironmentProvider {
        bool IsLive { get; }
    }
}
