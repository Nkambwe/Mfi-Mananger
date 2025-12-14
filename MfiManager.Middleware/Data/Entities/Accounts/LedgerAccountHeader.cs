namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class LedgerAccountHeader : AccountBase {
        /// <summary>
        /// Get Or Set the parent header code this header belongs to
        /// </summary>
        public string SubHeaderFor  {get;set;}
        public virtual ICollection<LedgerAccount> LedgerAccounts   {get;set;} =[];
        public virtual ICollection<LedgerAccountTotal> TotalLabels    {get;set;} =[];
    }
}
