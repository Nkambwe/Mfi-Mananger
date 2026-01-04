namespace MfiManager.Middleware.Data.Entities.System {
    public class UserPrefference: BaseEntity {
        public string Theme { get; set; }
        public string Language { get; set; }
        public long SystemUserId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public override bool Equals(object obj) {

            if (obj is not UserPrefference)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (UserPrefference)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.SystemUserId.Equals(SystemUserId) && item.Id.Equals(Id);
        }

        public override string ToString() => $"{SystemUserId} ({Id})";

        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
