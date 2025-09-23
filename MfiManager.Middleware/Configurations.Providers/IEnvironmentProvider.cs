namespace MfiManager.Middleware.Configurations.Providers {

    public interface IEnvironmentProvider {
        bool IsLive { get; }
    }

}
