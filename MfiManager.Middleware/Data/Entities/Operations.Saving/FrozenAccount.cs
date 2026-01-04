using MfiManager.Middleware.Data.Entities.Operations.Reasons;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    public class FrozenAccount : BaseEntity {
        public long SavingAccountId { get; set; }
        public long ReasonId { get; set; }
        public DateTime FrozenOn { get; set; }
        public DateTime? UnFrozenOn { get; set; }
        public string FrozenBy { get; set; }
        public virtual AccountFreezeReason Reason { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
    }
}
