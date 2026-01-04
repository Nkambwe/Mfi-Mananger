namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class PurchasingDefaults : BaseEntity {
        /// <summary>
        /// Get/Set person to contact on purchase
        /// </summary>
        public string ContactPerson {get;set; }
        /// <summary>
        /// Get/Set reference group for purchases on this delivery
        /// </summary>
        public string ReferenceGroup {get;set; }
        /// <summary>
        /// Get/Set reference value for sales on this delivery
        /// </summary>
        public string ReferenceValue  {get;set; }
        /// <summary>
        /// Get/Set employee responsible for the purchase
        /// </summary>
        public string PurchaseOfficer  {get;set; }
        /// <summary>
        /// Get/Set default transaction currency
        /// </summary>
        public string Currency  {get;set; }
        /// <summary>
        /// Get/Set delivery notes
        /// </summary>
        public string Notes  {get;set; }
        public long TraderId {get;set; }
        public virtual Trader Trader {get;set; }
    }

}
