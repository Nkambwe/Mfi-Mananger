namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchRevenueCenter : BaseEntity {
        public string Code { get; set; }
        public string Center { get; set; }
        public bool Suspend { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }

    }
}
