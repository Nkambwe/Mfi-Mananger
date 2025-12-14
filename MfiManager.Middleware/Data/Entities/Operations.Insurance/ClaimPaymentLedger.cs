using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance claim payment transaction record
    /// </summary>
    public class ClaimPaymentLedger: BaseEntity {
        public long ClaimId { get; set; }
        public long TransactionId {get;set;}
        public string TransactionCode { get; set; }
        public DateTime PaidOn { get; set; }
        public string Particulars { get; set; }
        public Payment Payment { get; set; }
        public decimal Paid { get; set; }
        public decimal Outstanding { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Cashier { get; set; }
        public virtual InsuranceClaim Claim { get; set; }
    }
}
