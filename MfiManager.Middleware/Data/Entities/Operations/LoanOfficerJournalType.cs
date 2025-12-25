using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class LoanOfficerJournalType {
        public long LoanOfficerId { get; set; }
        public long JournalTypeId { get; set; }
        public virtual LoanOfficer LoanOfficer { get; set; }
        public virtual JournalType JournalType { get; set; }
    }

}
