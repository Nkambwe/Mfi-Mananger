namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    /// <summary>
    /// Bank SWIFT code
    /// </summary>
    public class Swift : BaseEntity {
        public string Code { get; set; }
        public string Name  { get; set; }
        public virtual ICollection<Bank> Banks  { get; set; } = [];
    }
}
