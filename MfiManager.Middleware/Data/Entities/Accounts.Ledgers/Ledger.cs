using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Loans;

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
        public virtual ICollection<ClaimPaymentLedger> ClaimPaymentTransactions{ get; set; } = [];
        public virtual ICollection<ShareFeeLedger> ShareFeeTransactions { get; set; } = [];
        public virtual ICollection<SavingFeeLedger> SavingnFeeTransactions { get; set; } = [];
        public virtual ICollection<LoanFeeLedger> LoanFeeTransactions {get;set; } = [];
        public virtual ICollection<TimedepositFeeLedger> TimedepositFeeTransactions {get;set; } = [];
        public virtual ICollection<ModifiedLedger> ModifiedLedgerTransactions {get;set; } = [];
        public virtual ICollection<Disbursement> DisbursementTransactions {get;set; } = [];
        public virtual ICollection<DefferedLoan> DefferedLoans {get;set; } = [];
    }
}
