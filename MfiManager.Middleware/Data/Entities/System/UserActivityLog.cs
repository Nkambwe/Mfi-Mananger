namespace MfiManager.Middleware.Data.Entities.System {
    /// <summary>
    /// Class captures log of user activity
    /// </summary>
    public class UserActivityLog: BaseEntity {
        public long? EntityId { get; set; }
        public string EntityName { get; set; }
        public string IpAddress { get; set; }
        public string ActionDetails { get; set; }
        public long SystemUserId { get; set; }
        public long ActivityTypeId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual UserActivity UserActivityType { get; set; }

        public override bool Equals(object obj) {

            if (obj is not UserActivityLog)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (UserActivityLog)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.Id.Equals(Id) && item.EntityName.Equals(EntityName);
        }
        public override string ToString() => $"{Id}-{EntityName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
