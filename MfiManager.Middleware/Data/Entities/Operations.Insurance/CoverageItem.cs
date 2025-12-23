namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insured item on a given coverage eg. For Automobile Insurance coverage items can include Bodily person, Motor Vehicle, Medical Payments etc.
    /// </summary>
    public class CoverageItem: BaseEntity {
        public long CoverageId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public bool ChargePerPerson { get; set; }
        public bool HasDeductable { get; set; }
        public bool DeductableAsPercentage { get; set; }
        public decimal DeductableRate { get; set; }
        /// <summary>
        /// Get/Set the amount the person pays for themselves in case of an insurance lose
        /// </summary>
        public decimal FixedDeductableAmount { get; set; }
        public string Notes{get;set;}
        public virtual Coverage Coverage { get; set; }
    }
}
