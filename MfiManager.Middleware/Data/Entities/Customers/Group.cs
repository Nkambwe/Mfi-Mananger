using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Group : BaseEntity, IClient {
        [Encryptable("Group Name")]
        public string RegisteredName {get;set; }
        public string ClientCode { get; set; }
        public string Statistic { get; set; }
        public string Reference  { get; set; }
        [Encryptable("Permanent Address")]
        public string PermanentAddress  { get; set; }
        [Encryptable("Mail Address")]
        public string MailAddress  { get; set; }
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
        public bool Active { get; set; }
        public bool Exited  { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApprovedOn  { get; set; }
        public string ApprovedBy  { get; set; }
        [Encryptable("Notes")]
        public string Notes  { get; set; }
        public bool Transact  { get; set; }
        [Encryptable("Whatsapp")]
        public string WhatsApp  { get; set; }
        [Encryptable("Facebook")]
        public string Facebook { get; set; }
        [Encryptable("Instagram")]
        public string Instagram  { get; set; }
        [Encryptable("Twitter")]
        public string Twitter  { get; set; }
        public long BranchId {get;set; }
        public virtual GroupLoanAccount LoanAccount {get; set;}
        public virtual Branch Branch { get; set; }
        public long? Filter1Id {get;set; }
        public virtual ClientFilter1 ClientFilter1 { get; set; }
        public long? Filter2Id {get;set; }
        public virtual ClientFilter2 ClientFilter2 { get; set; }
        public long? Filter3Id {get;set; }
        public virtual ClientFilter3 ClientFilter3 { get; set; }
        public long? GroupFilter1Id {get;set; }
        public virtual GroupFilter1 GroupFilter1 { get; set; }
        public long? GroupFilter2Id {get;set; }
        public virtual GroupFilter2 GroupFilter2 { get; set; }
        public virtual CustomerExit CustomerExit {get; set;}
        public virtual ICollection<Member> Members { get; set; } =[];
        public virtual ICollection<Cluster> Clusters { get; set; } =[];
        public virtual ICollection<Meeting> Meetings {get;set;}
        public virtual ICollection<CustomerApproval> CustomerApprovals {get;set;}
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public virtual ICollection<TitleDeed> TitleDeeds {get;set;} = [];
        public virtual ICollection<OtherFile> Files {get;set;} = [];
        public virtual ICollection<CustomerContract> CustomerContracts {get;set;} = [];
        public virtual ICollection<CustomerAgreement> CustomerAgreements {get;set;} = [];
        public virtual ICollection<CustomerBlackList> BlackLists {get;set;} = [];
        public virtual ICollection<UnLockedCustomer> UnLockedCustomers {get;set;} = [];
        public virtual ICollection<ModifiedGroup> ModifiedGroups {get;set;} = [];
        public virtual ICollection<GroupLoan> Loans { get; set; } = [];
        public virtual ICollection<RejectedCustomer> Rejects { get; set; } = [];
        public virtual ICollection<SavingAccount> SavingAccounts { get; set; } = [];
        public override string ToString() => $"{(string.IsNullOrEmpty(ClientCode) ? "000000" : ClientCode.Trim())}-{(string.IsNullOrEmpty(RegisteredName) ? "Group Name" : RegisteredName.Trim())}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;

        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherGroup"/>Object to compare to this  <see cref="Group"/>
        /// <returns>
        /// True if object is the same as this <see cref="Group"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherGroup) {

            if (otherGroup == null || otherGroup.GetType() != typeof(Group)) return false;

            if (ReferenceEquals(this, otherGroup)) return true;

            var cluster = otherGroup as Group;
            return cluster != null
                   && cluster.ClientCode.Trim().Equals(ClientCode.Trim(), StringComparison.CurrentCultureIgnoreCase)
                   && cluster.RegisteredName.Trim().Equals(RegisteredName.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="Group"/> objects for equality.
        /// </summary>
        /// <param name="thisGroup">The First <see cref="Group"/> instance to compare.</param>
        /// <param name="thatGroup">The second <see cref="Group"/> instance to compare.</param>
        /// <returns>True when the groups are the same, false otherwise.</returns>
        public static bool operator ==(Group thisGroup, Group thatGroup)
            => thatGroup?.Equals(thisGroup) ?? Equals(thisGroup, null);

        /// <summary>
        /// Compares two instances of <see cref="Group"/> objects for inequality.
        /// </summary>
        /// <param name="thisGroup">The First <see cref="Group"/> instance to compare.</param>
        /// <param name="thatGroup">The second <see cref="Group"/> instance to compare.</param>
        /// <returns>False when the Groups are the same, true otherwise. </returns>
        public static bool operator !=(Group thisGroup, Group thatGroup)
            => !(thatGroup == thisGroup);
    }

}
