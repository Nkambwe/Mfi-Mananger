using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class UnSealedCustomerFile : BaseEntity {
        public long? BranchId  {get;set;}
        public string Client  {get;set;}
        public DateTime UnlockedOn {get;set;}
        public string UnlockedBy  {get;set;}
        public string Notes {get;set;}
        public string Reason {get;set;}
        public virtual Branch Branch { get; set; }
    }
}
