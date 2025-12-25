using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Data.Entities.Operations {

    public class Teller: BaseEntity {
        public string TellerAccount { get; set; }
        public decimal TransactionLimit { get; set; }
        public decimal Balance { get; set; }
        public bool Active { get; set; }
        public long UserId {get;set; }
        public virtual SystemUser SystemUser { get; set; } = null!;
        public long LedgerAccountId {get;set;}
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<Branch> AccessibleBranches { get; set; } = [];
        public virtual ICollection<TellerJournalType> JournalTypes { get; set; } = [];
        public virtual ICollection<TellerVoucherType> VoucherTypes { get; set; } = [];
    }

}
