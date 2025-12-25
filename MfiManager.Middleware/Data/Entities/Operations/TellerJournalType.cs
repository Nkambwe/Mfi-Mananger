using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Operations {
    public class TellerJournalType {
        public long TellerId { get; set; }
        public long JournalTypeId { get; set; }
        public virtual Teller Teller { get; set; }
        public virtual JournalType JournalType { get; set; }
    }

}
