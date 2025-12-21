using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Authority issuing the identification for purpose of credibility
    /// </summary>
    public class IssuerAuthority : BaseEntity {
        /// <summary>
        /// Get/Set code for issuing authority such as GOV for Government, LOC for local government
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Get/Set name for authority issuing document
        /// </summary>
        public string AuthorityName { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Identification> Identifications { get; set; } = [];
    }
}
