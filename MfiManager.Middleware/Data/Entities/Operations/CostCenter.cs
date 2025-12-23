namespace MfiManager.Middleware.Data.Entities.Operations {
    public class CostCenter : BaseEntity {
        public string Series { get; set; }
        public string Name { get; set; }
        public bool Suspend { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
