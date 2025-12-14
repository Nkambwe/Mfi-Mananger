namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanAmountClass : BaseEntity {
        public long? AmountClassId { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public virtual AmountClass AmountClass { get; set; }
    }
}
