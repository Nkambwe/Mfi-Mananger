namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchRevenueCenter : BaseEntity {
        public string Series { get; set; }
        public string Name { get; set; }
        public bool Suspend { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }

    }
}
