namespace MfiManager.Middleware.Data.Entities.Operations.Trade {

    public class DeliveryDefaults : BaseEntity {
        /// <summary>
        /// Get/Set person receiving the delivery
        /// </summary>
        public string Receiver {get;set; }
        /// <summary>
        /// Get/Set reference group for sales on this delivery
        /// </summary>
        public string ReferenceGroup {get;set; }
        /// <summary>
        /// Get/Set reference value for sales on this delivery
        /// </summary>
        public string ReferenceValue  {get;set; }
        /// <summary>
        /// Get/Set area where customer or vendor operates business
        /// </summary>
        public string Area  {get;set; }
        /// <summary>
        /// Get/Set default transaction currency
        /// </summary>
        public string Currency  {get;set; }
        /// <summary>
        /// Get/Set delivery notes
        /// </summary>
        public string DeliveryNotes  {get;set; }
    }
}
