namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    public class Position : BaseEntity {
        public string Code { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<MemberPosition> Members { get; set; } = [];
    }
}
