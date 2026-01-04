using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Business : BaseEntity, IClient {
        public string ClientCode  { get; set; }
        public string Statistic  { get; set; }
        public string Reference  { get; set; }
        [Encryptable("Legal Name")]
        public string LegalName {get;set; }
        [Encryptable("Permanent Address")]
        public string PermanentAddress  { get; set; }
        [Encryptable("Mail Address")]
        public string MailAddress  { get; set; }
        [Encryptable("Primary Line")]
        public string PrimaryLine  { get; set; }
        [Encryptable("Secondary Line")]
        public string SecondaryLine  { get; set; }
        [Encryptable("Mobile Number")]
        public string Mobile  { get; set; }
        [Encryptable("Fax Number")]
        public string Fax  { get; set; }
        [Encryptable("Email Address")]
        public string Email { get; set; }
        [Encryptable("City")]
        public string City  { get; set; }
        [Encryptable("Town")]
        public string Town  { get; set; }
        public DateTime RegisteredOn  { get; set; }
        public ClientType ClientType  { get; set; }
        public bool HoldShares  { get; set; }
        public bool Active  { get; set; }
        public bool Exited  { get; set; }
        public bool Approved  { get; set; }
        public DateTime? ApprovedOn  { get; set; }
        public string ApprovedBy  { get; set; }
        [Encryptable("Notes")]
        public string Notes  { get; set; }
        public bool Transact { get; set; }
        [Encryptable("Whatsapp")]
        public string WhatsApp  { get; set; }
        [Encryptable("Facebook")]
        public string Facebook  { get; set; }
        [Encryptable("Instagram")]
        public string Instagram  { get; set; }
        [Encryptable("Twitter")]
        public string Twitter { get; set; }
        public long BranchId {get;set; }
        public virtual BusinessLoanAccount LoanAccount {get; set;}
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
        public virtual CustomerExit CustomerExit {get; set;}
        public virtual ICollection<Signatory> Signatories {get;set;}=[];
        public virtual ICollection<CustomerApproval> CustomerApprovals {get;set;}
        public virtual ICollection<CustomerContact> CustomerContacts {get;set;} = [];
        public virtual ICollection<CustomerContract> CustomerContracts {get;set;} = [];
        public virtual ICollection<CustomerAgreement> CustomerAgreements {get;set;} = [];
        public virtual ICollection<CustomerBlackList> BlackLists {get;set;} = [];
        public virtual ICollection<TitleDeed> TitleDeeds {get;set;} = [];
        public virtual ICollection<OtherFile> Files {get;set;} = [];
        public virtual ICollection<UnLockedCustomer> UnLockedCustomers {get;set;} = [];
        public virtual ICollection<ModifiedBusiness> ModfiedRecords {get;set;} = [];
        public virtual ICollection<BusinessLoan> BusinessLoans { get; set; } = [];
        public virtual ICollection<SavingAccount> SavingAccounts { get; set; } = [];
        public virtual ICollection<RejectedCustomer> Rejects { get; set; } = [];
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
