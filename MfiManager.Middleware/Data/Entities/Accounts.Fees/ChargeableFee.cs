
namespace MfiManager.Middleware.Data.Entities.Accounts.Fees {
    /// <summary>
    /// Type of fees that can be charged on a given module product such as stationery, commission, development, processing, refinance
    /// </summary>
    public class ChargeableFee : BaseEntity {
        public string Name {get;set; }
        public bool ApplyToRegistration {get;set; }
        public bool ApplyToSavings {get;set; }
        public bool ApplyToTimeDeposits {get;set; }
        public bool ApplyToShares {get;set; }
        public bool ApplyToInsurance {get;set; }
        public bool ApplyToLoans {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<RegistrationFeeLedger> RegistrationFeeTransactions {get;set; } = [];
        public virtual ICollection<SavingFeeLedger> SavingFeeTransactions {get;set; } = [];
        public virtual ICollection<TimedepositFeeLedger> TimedepositFeeTransactions {get;set; } = [];
        public virtual ICollection<ShareFeeLedger> ShareFeeTransactions {get;set; } = [];
        public virtual ICollection<InsuranceFeeLedger> InsuranceFeeTransactions {get;set;} = [];
        public virtual ICollection<LoanFeeLedger> LoanFeeTransactions {get;set; } = [];

    }
}
