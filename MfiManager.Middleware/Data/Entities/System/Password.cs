namespace MfiManager.Middleware.Data.Entities.System {
    /// <summary>
    /// User old used password
    /// </summary>
    public class Password : BaseEntity {
        public long UserId {get;set; }
        public string PasswordHash {get;set;}
        public DateTime? LastUse {get;set;}
        public virtual SystemUser User { get; set; }
    }

}
