using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Saving Overdraft loan guarantee record
    /// </summary>
    public class OverdraftGuarantee : BaseEntity {
        public CollateralType CollateralType { get; set; }
        /// <summary>
        /// Get/Set percentage guaranteed by this guarantor
        /// </summary>
        public decimal Percentage { get; set; }
        public decimal AmountGuaranteed { get; set; }
        public decimal CollateralValue { get; set; }
        public string CollateralDescription { get; set; }
        public string Notes { get; set; }
        
        public long? GuarantorId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public long OverdraftId { get; set; }
        public virtual OverdraftLoan Overdraft { get; set; }
        public virtual ICollection<ModifiedOverdraftGuarantee> Modifications { get; set; }
    }
}
