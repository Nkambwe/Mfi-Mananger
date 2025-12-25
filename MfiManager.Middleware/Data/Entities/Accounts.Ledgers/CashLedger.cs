using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {

    public class CashLedger: BaseEntity {
        public string TransactionCode {get; set;}
        public string LedgerAccount {get; set;}
        public DateTime PostedOn {get; set;}
        public string Description {get; set;}
        /// <summary>
        /// Get / Set if transactional balance is provisional. Provisional balance is balance that has not yet been approved.
        /// If Journal transactions have not been approved, cash transactions relating to them are treated as provisional too
        /// </summary>
        public bool Provisional {get; set;}
        /// <summary>
        /// Cash account debits
        /// </summary>
        public decimal Debit {get; set;}
        /// <summary>
        /// Get/Set credit amount
        /// </summary>
        public decimal Credit  {get; set;}
        /// <summary>
        /// Get/Set Transaction amount in foreign currency
        /// </summary>
        public decimal ExchangeAmount {get; set;}
        /// <summary>
        /// Get/Set account balance
        /// </summary>
        public decimal Balance {get; set;}

        public long CashAccountId { get; set;}

        public virtual CashAccount CashAccount { get; set; }
        public virtual ICollection<ModifiedCashLedger> ModifiedCashLedgers {get; set;}=[];

    }
}
