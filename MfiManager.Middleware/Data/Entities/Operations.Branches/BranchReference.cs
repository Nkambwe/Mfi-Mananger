using MfiManager.Middleware.Data.Entities.Accounts;

namespace MfiManager.Middleware.Data.Entities.Operations.Branches {
    public class BranchReference : BaseEntity {
        public string Code { get; set; }
        public string Description { get; set; }
        public long ReferenceValueId { get; set; }
        public bool Suspend { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual AccountReferenceValue ReferenceValue { get; set; }
    }
}
