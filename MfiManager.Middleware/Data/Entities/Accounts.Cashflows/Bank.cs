namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    /// <summary>
    /// Bank group name for example Standard Chartered bank for all branches for this bank 
    /// </summary>
    public class Bank : BaseEntity {
        public string Code { get; set; }
        public long? IbanId  { get; set; }
        public long? SwiftId { get; set; }
        /// <summary>
        /// Get/Set bank group description e.g. Standard Chartered banks and accounts attached to this bank in different countries
        /// </summary>
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Fax  { get; set; }
        public virtual Iban Iban { get; set; }
        public virtual Swift Swift { get; set; }
        public virtual ICollection<BankBranch> Branches {get; set; } = [];
    }
}
