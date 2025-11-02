namespace MfiManager.Middleware.Data.Entities.System {
    public class MfiEntity: BaseEntity {
        /// <summary>
        /// Get Or Set Entity name eg.SystemUser
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// Get Or set properties to be encrypted for this entity eg.[FirstName, LastName, Email]
        /// </summary>
        public string SecuredFields { get; set; }

        public virtual ICollection<UserActivityLog> Logs { get; set; }
    }
}
