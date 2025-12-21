using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class Ledger : Transaction {
        public long LedgerAccountId {get;set;}
        public long? MonthlyClosureId {get;set;}
        public virtual MonthlyClosure MonthlyClosure { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<CardLedger> CardTransactions  {get;set;}=[];
        public virtual ICollection<Voucher> VoucherTransactions  {get;set;}=[];
        public virtual ICollection<RegistrationFeeLedger> RegistrationFeeTransactions { get; set; } = [];
        public virtual ICollection<InsuranceFeeLedger> InsuranceFeeTransactions { get; set; } = [];
        public virtual ICollection<ShareFeeLedger> ShareFeeTransactions { get; set; } = [];
        public virtual ICollection<SavingFeeLedger> SavingnFeeTransactions { get; set; } = [];
        public virtual ICollection<LoanFeeLedger> LoanFeeTransactions {get;set; } = [];
        public virtual ICollection<TimedepositFeeLedger> TimedepositFeeTransactions {get;set; } = [];

    }
}
