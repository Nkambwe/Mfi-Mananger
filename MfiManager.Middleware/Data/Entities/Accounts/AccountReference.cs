namespace MfiManager.Middleware.Data.Entities.Accounts {
    /// <summary>
    /// Ledger Account references
    /// </summary>
    /// <remarks>
    /// Ledger Account references provide us with a deeper analysis of the transactions posted on the general ledger accounts.
    /// They provide us with  with information on how account amount is allocated, for example, among business units and departments.
    /// </remarks>
    public class AccountReference : BaseEntity {
        public string Code { get; set; }
        public string Series { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsSystem { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<LedgerReferences> LedgerAccounts { get; set; }
        public virtual ICollection<AccountReferenceValue> ReferenceValues { get; set; }

    }
}
