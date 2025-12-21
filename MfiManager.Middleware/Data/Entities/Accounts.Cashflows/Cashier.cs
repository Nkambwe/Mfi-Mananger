using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {

    public class Cashier : BaseEntity {
        /// <summary>
        /// Get Or Set Cashier code
        /// </summary>
        public string Code {get; set; }
        /// <summary>
        /// Get Or Set Cashier name
        /// </summary>
        public string Name {get; set; }
        /// <summary>
        /// Current cashier branch
        /// </summary>
        public string CurrentBranch {get; set; }
        /// <summary>
        /// Default cash account for this cashier
        /// </summary>
        public string DefaultAccount  {get; set; }
        /// <summary>
        /// Minimum amount this cashier can be assigned to
        /// </summary>
        public decimal LowerLimit {get; set; }
        /// <summary>
        /// Maximum amount this cashier can be assigned to
        /// </summary>
        public decimal UpperLimit {get; set; }
        /// <summary>
        /// List of company branches that can be accessed by this cashier at the same time
        /// </summary>
        public string AccessibleBranches  {get; set; }
        /// <summary>
        /// Cashier user record ID
        /// </summary>
        public long UserId {get; set; }
        public virtual SystemUser User { get; set; }
        public virtual ICollection<CashierCashAccount> CashAccounts  {get; set; } =[];
        public virtual ICollection<CashierJournal> CashierJournals {get;set;}=[];
        public virtual ICollection<CashierVoucher> CashierVouchers {get;set;} = [];
    }

}
