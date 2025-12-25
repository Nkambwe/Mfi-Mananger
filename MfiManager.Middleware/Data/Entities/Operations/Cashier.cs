using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Data.Entities.Operations {

    public class Cashier : BaseEntity {
        /// <summary>
        /// Default cash account for this cashier
        /// </summary>
        public string DefaultAccount { get; set; }
        /// <summary>
        /// Maximum amount this cashier can be assigned to
        /// </summary>
        public decimal MaximumLimit { get; set; }
        /// <summary>
        /// Cashier user record ID
        /// </summary>
        public long UserId { get; set; }
        public virtual SystemUser User { get; set; }
        public virtual ICollection<CashierCashAccount> CashAccounts { get; set; } = [];
        public virtual ICollection<CashierJournal> CashierJournals { get; set; } = [];
        public virtual ICollection<CashierVoucher> CashierVouchers { get; set; } = [];
        public virtual ICollection<Branch> AccessibleBranches { get; set; } = [];

    }

}
