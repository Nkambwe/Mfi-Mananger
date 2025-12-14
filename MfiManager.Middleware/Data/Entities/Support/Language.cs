using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Language spoken by an individual
    /// </summary>
    public class Language : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; } = [];
        public virtual ICollection<Member> Members { get; set; } = [];

    }
}
