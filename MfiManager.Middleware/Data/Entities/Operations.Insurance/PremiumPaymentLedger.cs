using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance policy premium payment transaction record
    /// </summary>
    public class PremiumPaymentLedger: BaseEntity {
        public string TransactionCode { get; set; }
        public string Particulars { get; set; }
        public DateTime PaidOn { get; set; }
        public Payment Payment { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal PremiumFees { get; set; }
        public decimal Discount { get; set; }
        public string Cashier { get; set; }
        public long PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
