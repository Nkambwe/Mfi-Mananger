namespace MfiManager.Middleware.Data.Entities.Accounts.Currecies {
    public class ExchangeRate : BaseEntity {
        public long CurrencyId {get;set; }
        /// <summary>
        /// Get/Set currency your converting against
        /// </summary>
        public string Against {get;set; }
        public decimal Buy {get;set; }
        public decimal Sale {get;set; }
        /// <summary>
        /// Get/Set the organization rate considered to be stable for the period
        /// </summary>
        public decimal Average {get;set;}
        /// <summary>
        /// Check if this is the current running rate
        /// </summary>
        public bool IsRunning {get;set;}
        public virtual Currency Currency { get; set; }
    }
}
