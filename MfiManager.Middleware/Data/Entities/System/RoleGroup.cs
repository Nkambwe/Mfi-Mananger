using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System {

    public class RoleGroup: BaseEntity {
        public string GroupName { get; set; }
        public string Description { get; set; }
        public GroupScope Scope { get; set; }
        public string Department { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsVerified { get; set; }
        public virtual ICollection<SystemRole> Roles { get; set; }
        public virtual ICollection<PermissionSet> PermissionSets { get; set; }
        public override bool Equals(object obj) {

            if (obj is not RoleGroup)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (RoleGroup)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.GroupName.Equals(GroupName) && item.Description.Equals(Description) && item.Scope.Equals(Scope);
        }

        public override string ToString()
            => $"{GroupName} ({Description})";

        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }


}
