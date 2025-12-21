using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public interface IClient {
        public string ClientCode {get; set; }
        public string Statistic  {get; set; }
        public string Reference  {get; set; }
         /// <summary>
        /// Get Or Set Physical Address
        /// </summary>
        public string PermanentAddress { get; set; }
        /// <summary>
        /// Get Or Set Postal Address
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// Get Or Set Primary telephone contact
        /// </summary>
        public string PrimaryLine  { get; set; }
        /// <summary>
        /// Get Or Set Second telephone contact
        /// </summary>
        public string SecondaryLine  { get; set; }
        /// <summary>
        /// Get Or Set Mobile contact
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Get Or Set Fax Number
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Get Or Set Email contact
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Get Or Set Town of location
        /// </summary>
        public string Town  { get; set; }
        public DateTime RegisteredOn  {get; set; }
        public ClientType ClientType  {get; set; }
        public bool HoldShares {get; set; }
        public bool Active  {get; set; }
        public bool Exited {get; set; }
        public bool Approved  {get; set; }
        public DateTime? ApprovedOn  {get; set; }
        public string ApprovedBy  {get; set; }
        public string Notes {get; set; }
        public bool Transact  {get; set; }
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; } 
        public string Twitter { get; set; } 
        
    }
}
