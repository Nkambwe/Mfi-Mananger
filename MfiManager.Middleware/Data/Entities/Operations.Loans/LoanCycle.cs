
namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class LoanCycle : BaseEntity {
        public int CycleNumber {get;set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public decimal MinimumInterestRate { get; set; }
        public decimal MaximumInterestRate { get; set; }
        public bool CommissionAsPercentage { get; set; }
        public decimal MinimumCommissionAtApplication { get; set; }
        public decimal MaximumCommissionAtApplication { get; set; }
        public decimal MinimumCommissionAtDisbursement { get; set; }
        public decimal MaximumCommissionAtDisbursement { get; set; }
        public string Notes { get; set; }
        public long? IndividualAccountId {get;set; }
        public virtual IndividualLoanAccount IndividualAccount { get; set; }
        public long? BusinessAccountId {get;set; }
        public virtual BusinessLoanAccount BusinessAccount { get; set; }
        public long? GroupAccountId {get;set; }
        public virtual GroupLoanAccount GroupAccount { get; set; }
    }

}
