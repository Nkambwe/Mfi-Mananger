using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Class represents the valid format of an entity like, reference number, serial number, TIN, etc
    /// </summary>
    public class LabelFormat : BaseEntity {
        public long? BranchId {get;set;}
        public string Code {get;set;}
        public string Expression {get;set;}
        public FormatFor FormatType {get;set;}
        public virtual Branch Branch { get; set; }

    }
}
