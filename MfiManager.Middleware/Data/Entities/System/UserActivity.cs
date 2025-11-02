using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System {
    public class UserActivity : BaseEntity {
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public string Description { get; set; }      
        public bool Enabled { get; set; } = true;
        public ActivityCatrgory Category { get; set; }
        public bool IsAdminActivity { get; set; }
        public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; }
        public override bool Equals(object obj) {

            if (obj is not UserActivity)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (UserActivity)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.Name.Equals(Name) && item.Category.Equals(Category);
        }
        public override string ToString() => $"{Category}-{Name}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
