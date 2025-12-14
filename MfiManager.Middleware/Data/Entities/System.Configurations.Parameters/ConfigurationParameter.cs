using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class ConfigurationParameter : BaseEntity {
        public long BranchId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string ParamType { get; set; }
        public virtual Branch Branch { get; set; }
    }

}
