using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class BranchJournalType {
        public long BranchId { get; set; }
        public long JournalTypeId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual JournalType JournalType { get; set; }
     }

}
