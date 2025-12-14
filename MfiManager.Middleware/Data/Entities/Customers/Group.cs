using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class Group : IClient {
        public long BranchId {get;set; }
        public string RegisteredName {get;set; }
        public long? Filter1Id {get;set; }
        public long? Filter2Id {get;set; }
        public long? Filter3Id {get;set; }
        public long? GroupFilter1Id {get;set; }
        public long? GroupFilter2Id {get;set; }
        public long? NationalityId {get;set;}
        public string Code { get; set; }
        public string Statistic { get; set; }
        public string Reference  { get; set; }
        public string PermanentAddress  { get; set; }
        public string MailAddress  { get; set; }
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
        public bool Active { get; set; }
        public bool Exited  { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApprovedOn  { get; set; }
        public string ApprovedBy  { get; set; }
        public string Notes  { get; set; }
        public bool Transact  { get; set; }
        public string WhatsApp  { get; set; }
        public string Facebook { get; set; }
        public string Instagram  { get; set; }
        public string Twitter  { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual ClientFilter1 ClientFilter1 { get; set; }
        public virtual ClientFilter2 ClientFilter2 { get; set; }
        public virtual ClientFilter3 ClientFilter3 { get; set; }
        public virtual GroupFilter1 GroupFilter1 { get; set; }
        public virtual GroupFilter2 GroupFilter2 { get; set; }
        public virtual ICollection<Meeting> Meetings {get;set;}
        public virtual ICollection<ClientApproval> Approvals {get;set;}
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public override string ToString() => $"{(string.IsNullOrEmpty(Code) ? "000000" : Code.Trim())}-{(string.IsNullOrEmpty(RegisteredName) ? "Group Name" : RegisteredName.Trim())}";
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
                   && cluster.Code.Trim().Equals(Code.Trim(), StringComparison.CurrentCultureIgnoreCase)
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
