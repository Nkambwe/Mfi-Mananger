
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Types of identification documents for a person
    /// </summary>
    public class IdentificationType : BaseEntity {
        public string TypeName {get;set; }
        public bool Required {get;set; }
        /// <summary>
        /// Get/Set if document can be Sufficient as only document
        /// </summary>
        public bool Sufficient {get;set; }
        public Priority Priority {get;set; }
        public string LocalFolder {get;set; }
        public string FtpFolder {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<Identification> Identifications {get;set;}=[];
    }
}
