namespace MfiManager.Middleware.Data.Entities.Customer.Filters {
    /// <summary>
    /// Define a custom grouping for clients
    /// </summary>
    public abstract class ClientFilter : BaseEntity {
        public string Code {get;set; }
        public string Description {get;set;}
        public string Notes {get;set;}
    }
}
