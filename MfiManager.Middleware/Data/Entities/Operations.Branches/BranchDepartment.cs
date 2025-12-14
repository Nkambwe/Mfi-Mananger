namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchDepartment : BaseEntity {
        public string Code { get; set; }
        public string Department { get; set; }
        public bool Suspend { get; set; }
        public bool Close { get; set; }
        public DateTime? ClosedOn { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
