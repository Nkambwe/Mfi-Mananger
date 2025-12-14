using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.System.Configurations {
    /// <summary>
    /// Class captures system configurations for company wide configurations and branch specific configurations
    /// </summary>
    public class SystemConfiguration : BaseEntity {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string Description { get; set; }
        public long? CompanyId { get; set; }
        public long? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Company Company { get; set; }
        public override string ToString() => $"{Id}-{Id}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
