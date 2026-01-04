using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Member :  BaseEntity, IClient {
        public string ClientCode { get; set; }
        public string MemberNumber { get; set; }
        public string Statistic { get; set; }
        public string Reference { get; set; }
        [Encryptable("First Name")]
        public string FirstName {get;set; }
        [Encryptable("Middle Name")]
        public string MiddleName {get;set; }
        [Encryptable("Last Name")]
        public string LastName {get;set; }
        public Gender Gender {get;set; }
        public string Photo {get;set; }
        public string Signature {get;set; }
        public MaritalStatus MaritalStatus  { get; set; }
        [Encryptable("Spouse")]
        public string SpouseName { get; set; }
        public int Children  { get; set; }
        public int Dependents { get; set; }
        [Encryptable("Mother")]
        public string Mother  { get; set; }
        [Encryptable("Father")]
        public string Father { get; set; }
        public bool Literate  { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string RightThumbPrint { get; set; }
        public string LeftThumbPrint { get; set; }
        [Encryptable("Permanent Address")]
        public string PermanentAddress { get; set; }
        [Encryptable("Mail Address")]
        public string MailAddress { get; set; }
        [Encryptable("Primary Line")]
        public string PrimaryLine  { get; set; }
        [Encryptable("Secondary Line")]
        public string SecondaryLine  { get; set; }
        [Encryptable("Mobile")]
        public string Mobile  { get; set; }
        [Encryptable("Fax")]
        public string Fax  { get; set; }
        [Encryptable("Email")]
        public string Email  { get; set; }
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
        public string ApprovedBy { get; set; }
        [Encryptable("Notes")]
        public string Notes  { get; set; }
        public bool Transact  { get; set; }
        [Encryptable("Whatsapp")]
        public string WhatsApp { get; set; }
        [Encryptable("Facebook")]
        public string Facebook { get; set; }
        [Encryptable("Instagram")]
        public string Instagram { get; set; }
        [Encryptable("Twitter")]
        public string Twitter { get; set; }
        public DateTime JoinedOn {get;set; }
        public DateTime? ExitedOn {get;set; }
        public virtual MemberLoanAccount LoanAccount {get; set;}
        public long GroupId {get;set; }
        public virtual Group Group { get; set; }
        public long? TitleId {get;set; }
        public virtual Title Title { get; set; }
        public long? VillageId {get; set;}
        public virtual Village Village {get;set;}
        public long? Filter1Id {get;set; }
        public virtual ClientFilter1 ClientFilter1 { get; set; }
        public long? Filter2Id {get;set; }
        public virtual ClientFilter2 ClientFilter2 { get; set; }
        public long? Filter3Id {get;set; }
        public virtual ClientFilter3 ClientFilter3 { get; set; }
        public long? MemberFilter1Id {get;set; }
        public virtual MemberFilter1 MemberFilter1 { get; set; }
        public long? MemberFilter2Id {get;set;}
        public virtual MemberFilter2 MemberFilter2 { get; set; }
        public long? NationalityId {get;set; }
        public virtual Nationality Nationality { get; set; }
        public long? EducationId {get;set; }
        public virtual Education Education { get; set; }
        public long? ProfessionId {get;set; }
        public virtual Profession Profession { get; set; }
        public virtual CustomerExit CustomerExit {get; set;}
        public virtual ICollection<RejectedCustomer> Rejects { get; set; } = [];
        public virtual ICollection<IncomeHistory> IncomeHistories {get;set;} = [];
        public virtual ICollection<MemberLanguage> Languages {get;set; } = [];
        public virtual ICollection<MemberPosition> Positions {get;set; } = [];
        public virtual ICollection<MemberTransfer> MemberTransfers {get;set;} = [];
        public virtual ICollection<ModifiedMember> ModifiedMembers {get;set; } = [];
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<SavingAccount> SavingAccounts {get;set;} = [];
        public virtual ICollection<SavingPartner> SavingPartners { get; set; } = [];
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public virtual ICollection<GroupLoan> GroupLoans { get; set; } = [];
        public virtual ICollection<GroupLoanBreakdown> GroupLoanBreakdowns { get; set; } = [];
        public virtual ICollection<GroupRepaymentBreakdown> GroupRepaymentBreakdowns { get; set; } = [];
        public virtual ICollection<Policy> Policies {get;set;}=[];
        public virtual ICollection<CustomerContact> CustomerContacts {get;set;} = [];
        public virtual ICollection<CustomerContract> CustomerContracts {get;set;} = [];
        public virtual ICollection<CustomerAgreement> CustomerAgreements {get;set;} = [];
        public virtual ICollection<CustomerApproval> CustomerApprovals {get;set;} = [];
        public virtual ICollection<CustomerBlackList> BlackLists {get;set;} = [];
        public virtual ICollection<TitleDeed> TitleDeeds {get;set;} = [];
        public virtual ICollection<OtherFile> Files {get;set;} = [];
        public virtual ICollection<Identification> Identifications { get; set; } = [];
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = [];
        public virtual ICollection<UnLockedCustomer> UnLockedCustomers {get;set;} = [];
        public override string ToString() => $"{(string.IsNullOrEmpty(ClientCode) ? "000000" : ClientCode.Trim())}-{(string.IsNullOrEmpty(LastName) ? "Member" : LastName.Trim())}";

        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
       
        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherMember"/>Object to compare to this  <see cref="Member"/>
        /// <returns>
        /// True if object is the same as this <see cref="Member"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherMember) {

            if (otherMember == null || otherMember.GetType() != typeof(Member)) return false;

            if (ReferenceEquals(this, otherMember)) return true;

            var member = otherMember as Member;
            return member != null &&
                   member.ClientCode.Trim()
                       .Equals(ClientCode.Trim(), StringComparison.CurrentCultureIgnoreCase) &&
                   member.FirstName.Trim().Equals(FirstName.Trim(), StringComparison.CurrentCultureIgnoreCase) &&
                   member.MiddleName.Trim().Equals(MiddleName.Trim(), StringComparison.CurrentCultureIgnoreCase) &&
                   member.LastName.Trim().Equals(LastName.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="Member"/> objects for equality.
        /// </summary>
        /// <param name="thisMember">The First <see cref="Member"/> instance to compare.</param>
        /// <param name="thatMember">The second <see cref="Member"/> instance to compare.</param>
        /// <returns> True when the Members are the same, false otherwise.</returns>
        public static bool operator ==(Member thisMember, Member thatMember) => thatMember?.Equals(thisMember) ?? Equals(thisMember, null);

        /// <summary>
        /// Compares two instances of <see cref="Member"/> objects for inequality.
        /// </summary>
        /// <param name="thisMember">The First <see cref="Member"/> instance to compare.</param>
        /// <param name="thatMember">The second <see cref="Member"/> instance to compare.</param>
        /// <returns>False when the members are the same, true otherwise.</returns>
        public static bool operator !=(Member thisMember, Member thatMember) => !(thatMember == thisMember);
    }
}
