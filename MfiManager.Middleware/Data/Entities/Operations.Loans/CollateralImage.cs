namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Collateral image file
    /// </summary>
    public class CollateralImage : BaseEntity {
        public string FileName { get; set; }
        public long CollateralId { get; set; }
        public string Notes { get; set; }
        public virtual Collateral Collateral { get; set; }
    }
}
