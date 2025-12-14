using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Class holds details of loan revolving fund
    /// </summary>
    public class RevolvingFund : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
        /// <summary>
        /// Get/Set whether fund is based on savings lending
        /// </summary>
        public bool SavingsBased { get; set; }
        public decimal LoanablePercentage { get; set; }
        public long CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public long? DonorId { get; set; }
        public Donor Donor { get; set; }
        public virtual ICollection<BranchRevolvingFund> Branches { get; set; } = [];
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
        public virtual ICollection<LoanProduct> LoanProducts { get; set; } = [];

        public override string ToString() => $"{Code.Trim()}-{Name.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
