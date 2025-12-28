using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.System.Configurations {
    public class BranchParam : BaseEntity {
        public long BranchId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string ParamType { get; set; }
        public virtual Branch Branch { get; set; }
        public override string ToString() => $"{Id}-{ParameterName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }



}
