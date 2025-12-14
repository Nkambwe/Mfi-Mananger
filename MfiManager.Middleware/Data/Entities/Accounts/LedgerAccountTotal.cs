namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class LedgerAccountTotal : AccountBase {
        /// <summary>
        /// Get Or Set Ledger Account header this ledger belongs to
        /// </summary>
        public long HeaderId  {get;set;}
        /// <summary>
        /// Get Or Set range of ledger accounts totaled tor this label
        /// eg.101001000...101009000 for assets
        /// </summary>
        public string TotalRange {get;set;}

        public virtual LedgerAccountHeader Header { get; set; }
    }
}
