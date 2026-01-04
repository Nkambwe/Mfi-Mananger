using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System {
    public class SystemUser: BaseEntity {
        public string Username { get; set; }
        [Encryptable("First Name")]
        public string FirstName { get; set; }
        [Encryptable("Last Name")]
        public string LastName { get; set; }
        [Encryptable("Other Name")]
        public string OtherName { get; set; }
        [Encryptable("PF Number")]
        public string PFNumber { get; set; }
        [Encryptable("Email Address")]
        public string EmailAddress { get; set; }
        [Encryptable("Phone Number")]
        public string PhoneNumber { get; set; }
        [Encryptable("Password")]
        public string PasswordHash { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentUnit { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsVerified { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public bool IsLoggedIn { get; set; } 
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public long RoleId { get; set; }
        public virtual SystemRole Role { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public LoanOfficer LoanOfficer { get; set; } = null!;
        public Teller Teller { get; set; } = null!;
        public virtual ICollection<Cashier> Cashiers { get; set; }
        public virtual ICollection<LoginAttempt> Attempts { get; set; }
        public virtual ICollection<UserQuickAction> QuickActions { get; set; }
        public virtual ICollection<UserPrefference> Prefferences { get; set; }
        public virtual ICollection<UserActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<DelegatePermission> DelegatePermissions {get;set;}=[];
        public override bool Equals(object obj) {

            if (obj is not SystemUser)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (SystemUser)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.PFNumber.Equals(PFNumber) &&
                   item.FirstName.Equals(FirstName) &&
                   item.LastName.Equals(LastName);
        }

        public override string ToString() => $"{PFNumber} :: {FirstName} {LastName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }

}
