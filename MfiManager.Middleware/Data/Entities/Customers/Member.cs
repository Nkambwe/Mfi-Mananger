using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;
using System;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class Member :  IClient {
        public string MemCode {get;set; }
        public long? TitleId {get;set; }
        public string FirstName {get;set; }
        public string MiddleName {get;set; }
        public string LastName {get;set; }
        public Gender Gender {get;set; }
        public string Photo {get;set; }
        public string Signature {get;set; }
        public long? NationalityId {get;set; }
        public long BranchId {get;set; }
        public long? Filter1Id {get;set; }
        public long? Filter2Id {get;set; }
        public long? Filter3Id {get;set; }
        public long? ProfessionId {get;set; }
        public long? EducationId {get;set; }
        public string Group {get;set; }
        public DateTime Started {get;set; }
        public DateTime? Ended {get;set; }
        public long? MemberFilter1Id {get;set; }
        public long? MemberFilter2Id {get;set;}
        public string Code { get; set; }
        public string Statistic { get; set; }
        public string Reference { get; set; }
        public string PermanentAddress { get; set; }
        public string MailAddress { get; set; }
        public string PrimaryLine  { get; set; }
        public string SecondaryLine  { get; set; }
        public string Mobile  { get; set; }
        public string Fax  { get; set; }
        public string Email  { get; set; }
        public string Town  { get; set; }
        public DateTime RegisteredOn  { get; set; }
        public string Area  { get; set; }
        public ClientType Type  { get; set; }
        public bool HoldShares  { get; set; }
        public bool Active  { get; set; }
        public bool Exited  { get; set; }
        public bool Approved  { get; set; }
        public DateTime? ApprovedOn  { get; set; }
        public string ApprovedBy { get; set; }
        public string Notes  { get; set; }
        public bool Transact  { get; set; }
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public virtual Title Title { get; set; }
        public virtual ClientFilter1 ClientFilter1 { get; set; }
        public virtual ClientFilter2 ClientFilter2 { get; set; }
        public virtual ClientFilter3 ClientFilter3 { get; set; }
        public virtual MemberFilter1 MemberFilter1 { get; set; }
        public virtual MemberFilter2 MemberFilter2 { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Education Education { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual ICollection<IncomeHistory> Incomes {get;set;} = [];
        public virtual ICollection<Language> Languages {get;set; } = [];
        public virtual ICollection<MemberPosition> Positions {get;set; } = [];
        public virtual ICollection<MemberTransfer> Transfers {get;set;} = [];
        public virtual ICollection<ClientApproval> Approvals {get;set;} = [];
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public virtual ICollection<Policy> Policies {get;set;}=[];

        public override string ToString() => $"{(string.IsNullOrEmpty(Code) ? "000000" : Code.Trim())}-{(string.IsNullOrEmpty(LastName) ? "Member" : LastName.Trim())}";

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
                   member.Code.Trim()
                       .Equals(Code.Trim(), StringComparison.CurrentCultureIgnoreCase) &&
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
