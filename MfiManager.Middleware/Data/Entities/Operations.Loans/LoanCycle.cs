namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCycle : BaseEntity {
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public decimal MinimumInterestRate { get; set; }
        public decimal MaximumInterestRate { get; set; }
        public bool ChargeCommissionAsPercentageOfAmount { get; set; }
        public decimal MinimumCommissionAtApplication { get; set; }
        public decimal MaximumCommissionAtApplication { get; set; }
        public decimal MinimumCommissionAtDisbursement { get; set; }
        public decimal MaximumCommissionAtDisbursement { get; set; }
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
    }
}
