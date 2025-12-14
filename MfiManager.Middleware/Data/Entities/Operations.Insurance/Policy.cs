using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance policy record
    /// </summary>
    public class Policy: BaseEntity {
        public string PolicyNumber {get;set; }
        public DateTime EffectiveDate {get;set; }
        public DateTime? ExpiryDate {get;set; }
        public int BeneficiariesCount {get;set; }
        public string Agent {get;set; }
        public string Notes {get;set; }
        public long ProviderId {get;set; }
        public long ProductId {get;set; }
        public long? IndividualId {get;set; }
        public long? MemberId {get;set; }
        public virtual Individual Individual { get; set; }
        public virtual Member Member { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual InsuranceProduct InsuranceProduct { get; set; }
        public virtual ICollection<PremiumPaymentLedger> PremiumPayments {get;set;}=[];
        public virtual ICollection<PolicyInsuranceBeneficiary> Beneficiaries {get;set;}=[];
        public virtual ICollection<InsuranceClaim> Claims {get;set;}=[];
    }
}
