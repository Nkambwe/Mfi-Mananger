using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {

    public class LedgerAccount : AccountBase {
        /// <summary>
        /// Get Or Set normal ledger account balance
        /// </summary>
        public NormalBalance NormalBalance { get; set; }
        /// <summary>
        /// Get Or Set type of posting on this ledger
        /// </summary>
        public PostingType PostingType  { get; set; }
        /// <summary>
        /// Get or Set whether account allows direct or manual posting 
        /// </summary>
        public bool AllowManualPosting { get; set; }
        /// <summary>
        /// Get Or Set whether transaction description are shown in journals
        /// or only use  description codes applied
        /// </summary>
        public bool ShowParticulars { get; set; }
        public bool Suspended  { get; set; }
        public decimal Balance  { get; set; }
        public string Notes { get; set; }
        /// <summary>
        /// Get Or Set Ledger Account header this ledger belongs to
        /// </summary>
        public long LedgerAccountHeaderId { get; set; }
        /// <summary>
        /// Get Or Set code for transaction description that applies to this ledger account
        /// </summary>
        public long? FolioId { get; set; }
        /// <summary>
        /// Get Or Set currency for account if not same as base
        /// </summary>
        public long? CurrencyId  { get; set; }
        public long? ExchangeRateId  { get; set; }
        public long AccountsChartId { get; set; }
        public virtual Folio Folio { get; set; }
        public virtual AccountsChart AccountsChart { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual LedgerAccountHeader LedgerAccountHeader { get; set; }
        public virtual ICollection<LedgerReferences> References { get; set; } = [];
        public virtual ICollection<CashAccount> CashAccounts { get; set; } =[];
        public virtual ICollection<BankAccount> BankAccounts { get; set; } =[];
        public virtual ICollection<Ledger> GeneralLedgerTransactions {get;set;}=[];
    }

}
