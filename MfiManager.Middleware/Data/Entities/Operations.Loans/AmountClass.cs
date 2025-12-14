namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan amount classes ranging from First class to fifth class
    /// </summary>
    public class AmountClass : BaseEntity {
        public string ClassLevel { get; set; }
        public virtual ICollection<LoanAmountClass> LoanAmountClass { get; set; }
    }
}
