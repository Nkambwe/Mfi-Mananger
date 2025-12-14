namespace MfiManager.Middleware.Data.Entities.Operations {
    public class RevenueCenter : BaseEntity {
        public string Code {get;set; }
        public string Name {get;set; }
        public bool Active {get;set; }
        public long CompanyId {get;set;}
        public virtual Company Company { get; set; }
    }

}
