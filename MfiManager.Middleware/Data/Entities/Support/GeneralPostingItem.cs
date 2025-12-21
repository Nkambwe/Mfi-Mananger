using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class GeneralPostingItem : BaseEntity {
        public string Code {get;set; }
        public string Series {get;set; }
        public string Description {get;set; }
        public string Notes {get;set; }
        public long GeneralPostingTypeId {get; set; }
        public virtual GeneralPostingType GeneralPostingType { get; set; }
        public virtual ICollection<JournalType> Journals {get;set; }=[];
        public virtual ICollection<VoucherType> Vouchers {get;set;}  = [];
    }
}
