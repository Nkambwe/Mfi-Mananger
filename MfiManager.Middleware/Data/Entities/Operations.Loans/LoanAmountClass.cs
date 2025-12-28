using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan amount classes ranging from First class to fifth class
    /// </summary>
    public class LoanAmountClass : BaseEntity {
        public string ClassName { get; set; }
        public CustomerTarget TargetGroup {get;set; }
        public string Notes {get;set; }
        public long ProductId { get; set; }
        public virtual LoanProduct Product { get; set; }
        public virtual ICollection<LoanAmountClassRange> LoanClassRanges { get; set; }
    }
}
