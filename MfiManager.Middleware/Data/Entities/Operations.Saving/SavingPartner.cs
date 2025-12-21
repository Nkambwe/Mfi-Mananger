using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {

    public class SavingPartner : BaseEntity {
        public string PartnerName { get; set; }
        public bool Signatory { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// Get/Set if this holder can be sole signatory on this account to transact
        /// </summary>
        public bool OnlySignatory { get; set; }
        public bool IsCustomer { get; set; }
        public long? PersonId { get; set; }
        public virtual Individual Individual { get; set; }
        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public long SavingAccountId { get; set; }
        public virtual SavingAccount SavingAccount { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Identification> Identifications { get; set; } = [];
        public virtual ICollection<ImageFile> ImageFiles { get; set; } = [];
    }

}
