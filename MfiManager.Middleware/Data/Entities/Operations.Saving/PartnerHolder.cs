using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {

    public class PartnerHolder : BaseEntity {
        public long AccountId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool Signatory { get; set; }
        /// <summary>
        /// Get/Set if this holder can be sole signatory on this account to transact
        /// </summary>
        public bool OnlySignatory { get; set; }
        public string Signature { get; set; }
        public virtual ICollection<Identification> Identifications { get; set; } = [];
    }

}
