using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Operations.Shares;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    /// <summary>
    /// Share product
    /// </summary>
    public class ShareProduct : BaseEntity {
        public long ProductId {get;set; }
        public virtual Product Product {get;set;}
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<ShareValue> ShareValues {get;set;} = [];
    }
}
