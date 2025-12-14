using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Business sector that loan product finances
    /// </summary>
    public class BusinessSector : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LoanProduct> LoanProducts { get; set; } = [];
    }

}
