namespace MfiManager.Middleware.Data.Entities {
    /// <summary>
    /// Exclude some branches from accessing this entity
    /// </summary>
    public interface IEntityAccessSupported {
        bool ExcludeBranches { get; set; }
    }
}
