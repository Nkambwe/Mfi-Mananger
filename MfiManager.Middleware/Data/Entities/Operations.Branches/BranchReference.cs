using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchReference : BaseEntity {
        public string Series { get; set; }
        public string Description { get; set; }
        public bool Suspend { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public long ReferenceValueId { get; set; }
        public virtual AccountReferenceValue ReferenceValue { get; set; }
    }
}
