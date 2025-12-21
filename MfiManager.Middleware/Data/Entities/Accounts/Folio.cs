namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class Folio : BaseEntity {
        public string Code { get; set; }
        public string Particulars { get; set; }
        public long FolioTypeId { get; set; }
        public string Notes{ get; set; }
        public virtual FolioType FolioType { get; set; }
        public virtual ICollection<LedgerAccount> LedgerAccounts {get;set;}=[];
    }
}
