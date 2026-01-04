namespace MfiManager.Middleware.Data.Entities.System {
    /// <summary>
    /// User old used password
    /// </summary>
    public class Password : BaseEntity {
        public string PasswordHash {get;set;}
        public DateTime? ExpiryDate {get;set;}
        public long SystemUserId {get;set; }
        public virtual SystemUser SystemUser { get; set; }
    }

}
