
using MfiManager.Middleware.Data.Entities.Customer.Files;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Signatory on business client transactions
    /// </summary>
    public class Signatory : BaseEntity {
       
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        /// <summary>
        /// Get/Set whether signatory is no longer acceptable as signatory
        /// </summary>
        public bool Suspended { get; set; }
        /// <summary>
        /// Get/Set whether business signatory can be a sole signatory on business transactions
        /// </summary>
        public bool CanSignAlone { get; set; }
        public string PassCode { get; set; }
        public string Notes { get; set; }
        public long BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public virtual ICollection<OtherFile> Files {get;set;} = [];
        public virtual ICollection<Identification> Identifications { get; set; } = [];
    }
}
