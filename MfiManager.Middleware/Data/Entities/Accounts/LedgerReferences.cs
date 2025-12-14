namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class LedgerReferences {
        public long LedgerAccountId { get; set; }
        public long ReferenceId { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual AccountReference Reference { get; set; }
    }
}
