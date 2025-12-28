using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Trade;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {

    public class GeneralReason : ReasonBase {
        public long ReasonGroupId { get; set; }
        public virtual ReasonGroup ReasonGroup { get; set; }
        public virtual ICollection<Trader> Traders { get; set; } = [];
        public virtual ICollection<CustomerExit> CustomerExits { get; set; } = [];
        /// <summary>
        /// Get/Set black listed clients reasons
        /// </summary>
        public virtual ICollection<CustomerBlackList> BlackListedCustomers { get; set; } = [];
        public virtual ICollection<HeldContract> HeldContracts { get; set; } = [];
        public virtual ICollection<JournalType> Journals { get; set; } = [];
        public virtual ICollection<VoucherType> Vouchers { get; set; } = [];
        public virtual ICollection<MemberTransfer> MemberTransfers { get; set; } = [];
        public virtual ICollection<UnLockedCustomer> UnLockedCustomers { get; set; } = [];
        public virtual ICollection<ModifiedGroup> ModifiedGroups { get; set; } = [];
        public virtual ICollection<ModifiedBusiness> ModifiedBusinesses { get; set; } = [];
        public virtual ICollection<ModifiedCashLedger> ModifiedCashTransactions { get; set; } = [];
        public virtual ICollection<ModifiedSavingLedger> ModifiedSavingTransactions { get; set; } = [];
        public virtual ICollection<ModifiedShareLedgerTransaction> ModifiedShareTransactions { get; set; } = [];
        public virtual ICollection<ModifiedTimedepositAccount> ModifiedTimedepositAccounts { get; set; } = [];
        public virtual ICollection<DeletedLedger> DeletedTransactions { get; set; } = [];
        public virtual ICollection<ModifiedLedger> ModifiedTransactions { get; set; } = [];
        public virtual ICollection<ModifiedTimedepositLedger> ModifiedTimedepositTransactions { get; set; } = [];
        public virtual ICollection<ModifiedIndividual> ModifiedIndividuals { get; set; } = [];
        public virtual ICollection<ModifiedMember> ModifiedMembers { get; set; } = [];
    }
}
