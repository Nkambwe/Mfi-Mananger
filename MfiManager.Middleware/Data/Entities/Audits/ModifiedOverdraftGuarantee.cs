using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified overdraft loan guarantee record
    /// </summary>
    public class ModifiedOverdraftGuarantee : BaseEntity {
        public long RecordId { get; set; }
        public long OverdraftId { get; set; }
        public long? GuarantorId { get; set; }
        public CollateralType CollateralType { get; set; }
        public decimal Percentage { get; set; }
        public decimal AmountGuaranted { get; set; }
        public decimal CollateralValue { get; set; }
        public string CollateralDescription { get; set; }
        public string Notes { get; set; }
        public long ModifiedRecordId { get; set; }
        public long ModifiedOverdraftId { get; set; }
        public long? ModifiedGuarantorId { get; set; }
        public CollateralType ModifiedCollateralType { get; set; }
        public decimal ModifiedPercentage { get; set; }
        public decimal ModifiedAmountGuaranted { get; set; }
        public decimal ModifiedCollateralValue { get; set; }
        public string ModifiedCollateralDescription { get; set; }
        public string ModifiedNotes { get; set; }
        public virtual OverdraftGuarantee OverdraftGuarantee { get; set; }
    }
}
