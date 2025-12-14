
namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    /// <summary>
    /// Charge associated to a charge group
    /// </summary>
    public class Charge : BaseEntity {
        public string Code {get;set; }
        public string Series {get;set; }
        public string ChargeName {get;set; }
        public bool IsRated {get;set; }
        public bool ApplisToRegistration {get;set; }
        public bool AppliesToSavings {get;set; }
        public bool AppliesToTimeDeposits {get;set; }
        public bool AppliesToShares {get;set; }
        public bool AppliesToInsurance {get;set; }
        public bool AppliesToLoans {get;set; }
        public int LastCount {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<ChargeItemCharge> ChargeItems {get;set;}
    }

}
