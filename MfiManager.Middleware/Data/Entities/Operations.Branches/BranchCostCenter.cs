namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    /// <summary>
    /// Class represents an alternative cost center for the branch which is used instead of the default Cost center
    /// This cost center superseds the company cost center on the same ledeger oe subledegr
    /// </summary>
    public class BranchCostCenter : BaseEntity {
        public string Code { get; set; }
        public string Center { get; set; }
        public bool Suspend { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
