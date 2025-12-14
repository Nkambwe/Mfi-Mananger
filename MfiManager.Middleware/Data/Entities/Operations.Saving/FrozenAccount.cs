namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    public class FrozenAccount : BaseEntity {
        public long AccountId { get; set; }
        public DateTime FrozenOn { get; set; }
        public DateTime? UnFrozenOn { get; set; }
        public string FreezeReason { get; set; }
        public string FrozenBy { get; set; }
        public string Name { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
    }
}
