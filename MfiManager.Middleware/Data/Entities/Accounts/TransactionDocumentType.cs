using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class TransactionDocumentType : BaseEntity {
        public string Code {get;set;}
        public string TypeName {get;set;}
        public virtual ICollection<Voucher> Vouchers {get;set;} = [];
        
    }
}
