namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Base class for reason classes
    /// </summary>
    public abstract class ReasonBase : BaseEntity {
        public string Series { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
