using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class CardLedger : BaseEntity {
        public string TransactionId{ get; set; }
        public string Folio{ get; set; }
        public DateTime TransDate { get; set; }
        public string Particulars{ get; set; }
        public decimal Amount{ get; set; }
        public long CardId { get; set; }
        public long GeneralLedgerTransactionId { get; set; }
        public virtual Card Card { get; set; }
        public virtual Ledger GeneralLedgerTransaction { get; set; }
    }
}
