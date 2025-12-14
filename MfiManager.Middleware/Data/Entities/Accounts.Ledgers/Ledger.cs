using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class Ledger : Transaction, ICloneable {
        public long LedgerId {get;set;}

        public object Clone() {
            var clone = (Ledger)MemberwiseClone();
            clone.LedgerAccount = null;
            clone.Folio = null;
            clone.CardTransactions = null;
            clone.VoucherTransactions = null;
            return clone;
        }

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
