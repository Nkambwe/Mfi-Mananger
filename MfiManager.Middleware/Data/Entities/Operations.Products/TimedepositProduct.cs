using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    /// <summary>
    /// Timedeposit product record
    /// </summary>
    public partial class TimedepositProduct : BaseEntity {
        public InterestWithdrawMode WithdrawMode {get;set; }
        public bool CapitalizeInterest {get;set; }
        /// <summary>
        /// Get/Set if all interest is forfeited on premature withdraws
        /// </summary>
        public bool ForfeitInterestForPrematureWithdraw {get;set; }
        /// <summary>
        /// Get/Set percentage of penalty forfeited if not all interest is forfeited at premature withdraw
        /// </summary>
        public decimal PrematureWithdrawsPenalty {get;set; }
        /// <summary>
        /// Get/Set number of time period for the account
        /// </summary>
        public int Period {get;set; }
        /// <summary>
        /// Get/Set type of period for this account. Eg. Days, Weeks, Months, or Years
        /// </summary>
        public IntervalType PeriodType {get;set; }
        /// <summary>
        /// Get/Set minimum acceptable amount to be fixed
        /// </summary>
        public decimal MinimumAmount {get;set; }
        /// <summary>
        /// Get/Set Maximum acceptable amount to be fixed
        /// </summary>
        public decimal MaximumAmount {get;set; }
        /// <summary>
        /// Get/Set whether interest
        /// </summary>
        public bool TierInterest {get;set; }
        /// <summary>
        /// Get/Set interest calculation methods
        /// </summary>
        public TierCalculationMethod TierMethod {get;set; }
        public long ProductId {get;set; }
        public virtual Product Product {get;set;}
        public virtual ICollection<TimedepositAccount> TimedepositAccounts {get;set; }
        public virtual ICollection<TimedepositRate> InterestRates {get;set; }
    }
}
