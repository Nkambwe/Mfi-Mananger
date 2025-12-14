using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Class holds details of funding agencies
    /// </summary>
    public class Donor : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RevolvingFund> RevolvingFunds { get; set; } = [];
        public override string ToString() => $"{Code.Trim()}-{Name.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
