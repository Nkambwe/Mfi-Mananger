using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public abstract class TradeContact : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Language { get; set; }
        public string LedgerAccount { get; set; }
        public PaymentPriority Priority { get; set; }
    }
}
