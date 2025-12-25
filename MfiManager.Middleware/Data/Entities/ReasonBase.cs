namespace MfiManager.Middleware.Data.Entities {
    /// <summary>
    /// Base class for reason classes
    /// </summary>
    public abstract class ReasonBase : BaseEntity {
        public string Series {get;set;}
        public string Reason {get;set;}
    }
}
