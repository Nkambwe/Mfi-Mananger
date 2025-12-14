using MfiManager.Middleware.Data.Entities.Operations.Saving;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan Guarantor record
    /// </summary>
    public class Guarantor : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsClient { get; set; }
        public string ClientCode { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public ICollection<Collateral> Collateral { get; set; } = [];
        public ICollection<OverdraftGuarantee> Overdrafts { get; set; } = [];
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];

        public override string ToString() => $"{(string.IsNullOrEmpty(Code) ? "000000" : Code.Trim())}:{(string.IsNullOrEmpty(Name) ? "" : Name.Trim())}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;

        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherGuarantor"/>Object to compare to this  <see cref="Guarantor"/>
        /// <returns>
        /// True if object is the same as this <see cref="Guarantor"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherGuarantor) {

            if (otherGuarantor == null || otherGuarantor.GetType() != typeof(Guarantor)) return false;

            if (ReferenceEquals(this, otherGuarantor)) return true;

            var guarantor = otherGuarantor as Guarantor;
            return guarantor != null && guarantor.Code.Trim().Equals(Code.Trim(), StringComparison.CurrentCultureIgnoreCase) && guarantor.Name.Trim().Equals(Name.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="Guarantor"/> objects for equality.
        /// </summary>
        /// <param name="thisGuarantor">The First <see cref="Guarantor"/> instance to compare.</param>
        /// <param name="thatGuarantor">The second <see cref="Guarantor"/> instance to compare.</param>
        /// <returns>
        /// True when the guarantors are the same, false otherwise.
        /// </returns>
        public static bool operator ==(Guarantor thisGuarantor, Guarantor thatGuarantor)
            => thatGuarantor?.Equals(thisGuarantor) ?? Equals(thisGuarantor, null);

        /// <summary>
        /// Compares two instances of <see cref="Guarantor"/> objects for inequality.
        /// </summary>
        /// <param name="thisGuarantor">The First <see cref="Guarantor"/> instance to compare.</param>
        /// <param name="thatGuarantor">The second <see cref="Guarantor"/> instance to compare.</param>
        /// <returns>
        /// False when the guarantors are the same, true otherwise.
        /// </returns>
        public static bool operator !=(Guarantor thisGuarantor, Guarantor thatGuarantor)
            => !(thatGuarantor == thisGuarantor);
    }
}
