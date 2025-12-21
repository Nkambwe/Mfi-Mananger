using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Business : BaseEntity, IClient {
        public string ClientCode  { get; set; }
        public string Statistic  { get; set; }
        public string Reference  { get; set; }
        public string LegalName {get;set; }
        public string PermanentAddress  { get; set; }
        public string MailAddress  { get; set; }
        public string PrimaryLine  { get; set; }
        public string SecondaryLine  { get; set; }
        public string Mobile  { get; set; }
        public string Fax  { get; set; }
        public string Email { get; set; }
        public string City  { get; set; }
        public string Town  { get; set; }
        public DateTime RegisteredOn  { get; set; }
        public ClientType ClientType  { get; set; }
        public bool HoldShares  { get; set; }
        public bool Active  { get; set; }
        public bool Exited  { get; set; }
        public bool Approved  { get; set; }
        public DateTime? ApprovedOn  { get; set; }
        public string ApprovedBy  { get; set; }
        public string Notes  { get; set; }
        public bool Transact { get; set; }
        public string WhatsApp  { get; set; }
        public string Facebook  { get; set; }
        public string Instagram  { get; set; }
        public string Twitter { get; set; }
        public long BranchId {get;set; }
        public virtual Branch Branch {get;set;}
        public long? VillageId {get; set;}
        public virtual Village Village {get;set;}
        public long? Filter1Id {get;set; }
        public virtual ClientFilter1 ClientFilter1 { get; set; }
        public long? Filter2Id {get;set; }
        public virtual ClientFilter2 ClientFilter2 { get; set; }
        public long? Filter3Id {get;set; }
        public virtual ClientFilter3 ClientFilter3 { get; set; }
        public long? BusinessFilter1Id {get;set; }
        public virtual BusinessFilter1 BusinessFilter1 { get; set; }
        public long? BusinessFilter2Id {get;set; }
        public virtual BusinessFilter2 BusinessFilter2 { get; set; }
        public virtual ICollection<ClientApproval> Approvals {get;set;}
        public virtual ICollection<Signatory> Signatories {get;set;}=[];
        public override string ToString() => $"{(string.IsNullOrEmpty(ClientCode) ? "000000" : ClientCode.Trim())}-{(string.IsNullOrEmpty(LegalName) ? "Business" : LegalName.Trim())}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;

        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherBusiness"/>Object to compare to this  <see cref="Business"/>
        /// <returns>
        /// True if object is the same as this <see cref="Business"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherBusiness) {

            if (otherBusiness == null || otherBusiness.GetType() != typeof(Business)) return false;

            if (ReferenceEquals(this, otherBusiness)) return true;

            var business = otherBusiness as Business;
            return business != null &&
                   business.ClientCode.Trim()
                       .Equals(ClientCode.Trim(), StringComparison.CurrentCultureIgnoreCase) &&
                   business.LegalName.Trim().Equals(LegalName.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="Business"/> objects for equality.
        /// </summary>
        /// <param name="thisBusiness">The First <see cref="Business"/> instance to compare.</param>
        /// <param name="thatBusiness">The second <see cref="Business"/> instance to compare.</param>
        /// <returns> True when the business are the same, false otherwise.</returns>
        public static bool operator ==(Business thisBusiness, Business thatBusiness) => thatBusiness?.Equals(thisBusiness) ?? Equals(thisBusiness, null);

        /// <summary>
        /// Compares two instances of <see cref="Business"/> objects for inequality.
        /// </summary>
        /// <param name="thisBusiness">The First <see cref="Business"/> instance to compare.</param>
        /// <param name="thatBusiness">The second <see cref="Business"/> instance to compare.</param>
        /// <returns>False when the business are the same, true otherwise.</returns>
        public static bool operator !=(Business thisBusiness, Business thatBusiness) => !(thatBusiness == thisBusiness);
    }
}
