using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public abstract class TradeContact : BaseEntity {
        public string Series { get; set; }
        [Encryptable("Trader Name")]
        public string Name { get; set; }
        [Encryptable("Trader Alias")]
        public string Alias { get; set; }
        public string Language { get; set; }
        public string LedgerAccount { get; set; }
        public PaymentPriority Priority { get; set; }
    }
}
