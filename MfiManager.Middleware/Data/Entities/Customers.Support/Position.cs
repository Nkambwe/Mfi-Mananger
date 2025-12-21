namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    public class Position : BaseEntity {
        public string Series { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<MemberPosition> MemberPositions { get; set; } = [];
    }
}
