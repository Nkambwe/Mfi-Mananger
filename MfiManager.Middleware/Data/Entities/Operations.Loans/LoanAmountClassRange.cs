
namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class LoanAmountClassRange : BaseEntity {
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public string Notes { get; set; }
        public long LoanClassId { get; set; }
        public virtual LoanAmountClass LoanAmountClass { get; set; }
    }

}
