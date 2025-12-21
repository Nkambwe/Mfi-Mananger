namespace MfiManager.Middleware.Data.Entities.Customers {

    public class ClusterMember : BaseEntity {
        public long ClusterId {get;set; }
        public string Member {get;set; }
        public DateTime JoinedOn {get;set; }
        public DateTime? ExitedOn {get;set;}
        public string Notes {get;set; }
        public virtual Cluster Cluster { get; set; }
    }

}
