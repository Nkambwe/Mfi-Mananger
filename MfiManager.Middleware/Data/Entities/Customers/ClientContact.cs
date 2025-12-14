using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Person next of kin records and contact information
    /// </summary>
    public class ClientContact : BaseEntity {
        public long? BranchId {get;set; }
        public string Code {get;set; }
        public string Owner {get;set; }
        public string Name {get;set; }
        public string Telephone {get;set; }
        public string Mobile {get;set; }
        public string Email {get;set; }
        public string Relationship {get;set;}
        public virtual Branch Branch { get; set; }

    }
}
