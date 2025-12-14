namespace MfiManager.Middleware.Data.Entities.Operations.Shares {
    /// <summary>
    /// Dividends transaction record
    /// </summary>
    public class DividendTransactionLedger : BaseEntity {
        public long ShareAccountId {get;set; }
        public DateTime PaidOn {get;set; }
        public string Ledger {get;set; }
        public decimal Amount {get;set; }
        public decimal Outstanding {get;set; }
        public virtual ShareAccount ShareAccount { get; set; }
    }
}
