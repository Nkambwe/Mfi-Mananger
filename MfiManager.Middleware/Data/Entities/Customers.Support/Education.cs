namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Person's level of education
    /// </summary>
    public class Education : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Individual> People { get; set; } = [];
        public virtual ICollection<Member> Members { get; set; } = [];
    }
}
