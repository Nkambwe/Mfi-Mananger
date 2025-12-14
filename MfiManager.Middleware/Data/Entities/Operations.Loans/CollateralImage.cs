namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Collateral image file
    /// </summary>
    public class CollateralImage : BaseEntity {
        public long CollateralId { get; set; }
        public string File { get; set; }
        public virtual Collateral Collateral { get; set; }
    }
}
