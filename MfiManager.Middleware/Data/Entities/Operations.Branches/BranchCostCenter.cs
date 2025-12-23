namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    /// <summary>
    /// Class represents an alternative cost center for the branch which is used instead of the default Cost center
    /// This cost center superseds the company cost center on the same ledeger oe subledegr
    /// </summary>
    public class BranchCostCenter : BaseEntity {
        public string Series { get; set; }
        public string Name { get; set; }
        public bool Suspend { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
