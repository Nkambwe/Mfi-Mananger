namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    public class PolicyInsuranceBeneficiary {
        public long BeneficiaryId { get; set; }
        public long PolicyId { get; set; }
        public virtual InsuranceBeneficiary Beneficiary { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
