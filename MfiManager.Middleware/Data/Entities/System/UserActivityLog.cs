namespace MfiManager.Middleware.Data.Entities.System {
    /// <summary>
    /// Class captures log of user activity
    /// </summary>
    public class UserActivityLog: BaseEntity {
        public long EntityId { get; set; }
        public string IpAddress { get; set; }
        public string ActionDetails { get; set; }
        public long UserId { get; set; }
        public long ActivityId { get; set; }
        public virtual SystemUser User { get; set; }
        public virtual UserActivity Activity { get; set; }
        public virtual MfiEntity Entity { get; set; }

        public override bool Equals(object obj) {

            if (obj is not UserActivityLog)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (UserActivityLog)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.Id.Equals(Id) && item.EntityId.Equals(EntityId) &&  item.Id.Equals(Id) && item.UserId.Equals(UserId) &&  item.IpAddress.Equals(IpAddress);
        }
        public override string ToString() => $"{Id}-{EntityId}-{UserId}-{IpAddress}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
