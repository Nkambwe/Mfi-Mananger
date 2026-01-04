using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Individual : BaseEntity, IClient {
        public string ClientCode { get; set; }
        public string Statistic { get; set; }
        public string Reference { get; set; }
        [Encryptable("First Name")]
        public string FirstName {get;set; }
        [Encryptable("Last Name")]
        public string LastName {get;set; }
        [Encryptable("Middle Name")]
        public string MiddleName {get;set; }
        public Gender Gender { get; set; }
        public string Photo {get;set; }
        public string Signature { get;set; }
        [Encryptable("City")]
        public string City  { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string RightThumbPrint { get; set; }
        public string LeftThumbPrint { get; set; }
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
        [Encryptable("Permanent Address")]
        public string PermanentAddress { get; set; }
        [Encryptable("Mail Address")]
        public string MailAddress { get; set; }
        [Encryptable("Primary Line")]
        public string PrimaryLine { get; set; }
        [Encryptable("Secondary Line")]
        public string SecondaryLine { get; set; }
        [Encryptable("Mobile")]
        public string Mobile { get; set; }
        [Encryptable("Fax")]
        public string Fax { get; set; }
        [Encryptable("Email")]
        public string Email { get; set; }
        public string Town { get; set; }
        public DateTime RegisteredOn { get; set; }
        public ClientType ClientType { get; set; }
        public bool HoldShares { get; set; }
        public bool Active { get; set; }
        public bool Exited { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        [Encryptable("Notes")]
        public string Notes { get; set; }
        public bool Transact { get; set; }
        [Encryptable("Twitter")]
        public string WhatsApp { get; set; }
        [Encryptable("Facebook")]
        public string Facebook { get; set; }
        [Encryptable("Instagram")]
        public string Instagram { get; set; }
        [Encryptable("Twitter")]
        public string Twitter { get; set; }
        public long BranchId {get;set; }
        public virtual Branch Branch {get;set;}
        public long? NationalityId {get;set; }
        public virtual Nationality Nationality {get;set;}
        public long? TitleId { get; set; }
        public virtual Title Title {get;set;}
        public long? Filter1Id {get; set;}
        public virtual ClientFilter1 Filter1 {get;set;}
        public long? Filter2Id {get; set;}
        public virtual ClientFilter2 Filter2 {get;set;}
        public long? Filter3Id {get; set;}
        public virtual ClientFilter3 Filter3 {get;set;}
        public long? ProfessionId {get; set;}
        public virtual Profession Profession {get;set;}
        public long? EducationId {get; set;}
        public virtual Education Education {get;set;}
        public long? VillageId {get; set;}
        public virtual Village Village {get;set;}
        public virtual CustomerExit CustomerExit {get; set;}
        public virtual IndividualLoanAccount LoanAccount {get; set;}
        public virtual ICollection<IncomeHistory> IncomeHistories {get;set;} = [];
        public virtual ICollection<IndividualLanguage> Languages  {get;set;} = [];
        public virtual ICollection<CreditAssessment> CreditAssessments { get; set; } = [];
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<Policy> Policies {get;set;}=[];
        public virtual ICollection<CustomerApproval> CustomerApprovals {get;set;} = [];
        public virtual ICollection<CustomerContact> CustomerContacts {get;set;} = [];
        public virtual ICollection<CustomerContract> CustomerContracts {get;set;} = [];
        public virtual ICollection<CustomerAgreement> CustomerAgreements {get;set;} = [];
        public virtual ICollection<CustomerBlackList> BlackLists {get;set;} = [];
        public virtual ICollection<TitleDeed> TitleDeeds {get;set;} = [];
        public virtual ICollection<OtherFile> Files {get;set;} = [];
        public virtual ICollection<Identification> Identifications { get; set; } = [];
        public virtual ICollection<SavingPartner> SavingPartners { get; set; } = [];
        public virtual ICollection<SavingAccount> SavingAccounts { get; set; } = [];
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = [];
        public virtual ICollection<UnLockedCustomer> UnLockedCustomers {get;set;} = [];
        public virtual ICollection<ModifiedIndividual> ModifiedRecords {get;set;} = [];
        public virtual ICollection<RejectedCustomer> Rejects { get; set; } = [];
        public override bool Equals(object otherIndividual) {

            if (otherIndividual == null || otherIndividual.GetType() != typeof(Individual)) return false;

            if (ReferenceEquals(this, otherIndividual)) return true;

            var pRecord = otherIndividual as Individual;

            return pRecord != null &&
                   pRecord.PermanentAddress.Equals((PermanentAddress ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.MailAddress.Trim().Equals((MailAddress ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.PrimaryLine.Trim().Equals((PrimaryLine ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.SecondaryLine.Trim().Equals((SecondaryLine ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.Mobile.Trim().Equals((Mobile ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.Email.Trim().Equals((Email ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.Town.Trim().Equals((Town ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase) &&
                   pRecord.City.Trim().Equals((City ?? string.Empty).Trim(),
                       StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Generate a hash code for this address. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Individual"/>.
        /// </returns>
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
        /// <summary>
        /// Compares two instances of <see cref="Individual"/> objects for equality.
        /// </summary>
        /// <param name="thisRecord">The First instance to compare.</param>
        /// <param name="thatRecord">The second instance to compare.</param>
        /// <returns>True when the records are the same, false otherwise.</returns>
        public static bool operator ==(Individual thisRecord, Individual thatRecord)
            => thatRecord?.Equals(thisRecord) ?? Equals(thisRecord, null);

        /// <summary>
        /// Compares two instances of <see cref="Individual"/> objects for inequality.
        /// </summary>
        /// <param name="thisRecord">The First instance to compare.</param>
        /// <param name="thatRecord">The second instance to compare.</param>
        /// <returns> False when the records are the same, true otherwise.</returns>
        public static bool operator !=(Individual thisRecord, Individual thatRecord)
            => !(thatRecord == thisRecord);

        /// <summary>
        /// Override to string method of client object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{FirstName}, {LastName}, {ClientCode},{DateOfBirth}{BirthPlace}{Father}{Mother}";
    }
}
