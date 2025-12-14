namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class Folio : BaseEntity {
        public string Code { get; set; }
        public string Particulars { get; set; }
        public long TypeId { get; set; }
        public string Notes{ get; set; }
        public virtual FolioType Type { get; set; }
        public virtual ICollection<LedgerAccount> LedgerAccounts {get;set;}=[];
    }
}
