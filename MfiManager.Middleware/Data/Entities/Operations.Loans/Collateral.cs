using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan collateral record
    /// </summary>
    public class Collateral : BaseEntity {
        public string LoanNumber { get; set; }
        public string OverdraftNumber { get; set; }
        public CollateralType CollateralType { get; set; }
        public string Description { get; set; }
        public decimal CollateralValue { get; set; }
        public string Notes { get; set; }
        public long GuarantorId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public ICollection<CollateralImage> Images { get; set; }
    }
}
