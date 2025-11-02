namespace MfiManager.Middleware.Data.Entities.System {
    public class Branch: BaseEntity {
        public long CompanyId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public object Address { get; internal set; }
        public object EmailAddress { get; internal set; }
        public object PostalAddress { get; internal set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<SystemConfiguration> SystemConfigurations { get; set; }
        public override bool Equals(object obj) {

            if (obj is not Branch)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (Branch)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.BranchCode.Equals(BranchCode) && item.BranchName.Equals(BranchName);
        }
        public override string ToString() => $"{BranchCode}-{BranchName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
