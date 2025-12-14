using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan collateral record
    /// </summary>
    public class Collateral : BaseEntity {
        public long GuarantorId { get; set; }
        public string LoanNumber { get; set; }
        public string OverdraftNumber { get; set; }
        public CollateralType Type { get; set; }
        public string Description { get; set; }
        public decimal Values { get; set; }
        public string Notes { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public ICollection<CollateralImage> Images { get; set; }
    }
}
