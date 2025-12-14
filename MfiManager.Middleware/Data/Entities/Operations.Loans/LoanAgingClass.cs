using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan aging classes for a given loan product
    /// </summary>
    public class LoanAgingClass : BaseEntity {
        public long ProductId { get; set; }
        public string Class { get; set; }
        public bool Active { get; set; }
        public decimal LowerClass { get; set; }
        public decimal UpperClass { get; set; }
        public string PersonalLoanLedger { get; set; }
        public string GroupLoanLedger { get; set; }
        public string BusinessLoanLedger { get; set; }
        public virtual LoanProduct Product { get; set; }
    }
}
