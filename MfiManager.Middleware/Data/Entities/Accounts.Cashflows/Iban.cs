namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    /// <summary>
    /// Bank IBAN number also called routing number
    /// </summary>
    public class Iban : BaseEntity {
        public string Code {get; set; }
        public string Naration  {get; set; }
        public virtual ICollection<Bank> Banks  {get; set; } = [];
    }
}
