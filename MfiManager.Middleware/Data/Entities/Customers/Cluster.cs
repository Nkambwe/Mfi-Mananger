using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class Cluster : BaseEntity {
        public string Code {get;set; }
        public long BranchId {get;set; }
        public string Group {get;set; }
        public string RegisteredName {get;set; }
        public DateTime RegisteredOn {get;set; }
        public string Area {get;set; }
        public ClientType Type {get;set; }
        public bool Closed {get;set; }
        /// <summary>
        /// Get/Set flag to check if cluster was dissolved into another cluster
        /// </summary>
        public bool Merged {get;set; }
        /// <summary>
        /// Get/Set code to which this cluster was joined to if cluster was dissolved into another
        /// </summary>
        public string MergedTo {get;set; }
        public bool Active {get;set; }
        public bool MarkAsDeleted {get;set; }
        public string CreditOfficer {get;set; }
        public string Notes {get;set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ClusterMember> Members {get;set;}

    }
}
