namespace MfiManager.Middleware.Data.Entities.Customers {
    public class ClusterMember : BaseEntity {
        public long ClusterId {get;set; }
        public string Member {get;set; }
        public DateTime Started {get;set; }
        public DateTime? Ended {get;set;}
        public virtual Cluster Cluster { get; set; }
    }
}
