
namespace MfiManager.Middleware.Data.Entities.Customers {

    public class Cluster : BaseEntity {
        public string Series {get;set; }
        public string ClusterName {get;set; }
        public DateTime AddedOn {get;set; }
        public DateTime? ClosedOn {get;set; }
        public string Area {get;set; }
        /// <summary>
        /// Get/Set flag to check if cluster was dissolved into another cluster
        /// </summary>
        public bool Merged {get;set; }
        /// <summary>
        /// Get/Set code to which this cluster was joined to if cluster was dissolved into another
        /// </summary>
        public string MergedTo {get;set; }
        public bool Active {get;set; }
        public string CreditOfficer {get;set; }
        public string Notes {get;set; }
        public long GroupId {get;set; }
        public virtual Group Group {get;set;}
        public virtual ICollection<ClusterMember> Members {get;set;}
    }

}
