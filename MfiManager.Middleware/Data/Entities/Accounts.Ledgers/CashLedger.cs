using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class CashLedger: BaseEntity {
        public string TransactionId {get; set;}
        public string Account {get; set;}
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
        public virtual ICollection<CashAccount> CashAccounts {get; set;}=[];

    }
}
