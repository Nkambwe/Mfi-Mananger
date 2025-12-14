namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Business group type item
    /// </summary>
    public class BusinessPostingItem: BaseEntity {
        /// <summary>
        /// Get / Set business group item code
        /// </summary>
        public string Code {get;set; }
        /// <summary>
        /// Get / Set business group item posting series number
        /// </summary>
        public string Series {get;set; }
        public string Description {get;set; }
        public string Notes {get;set; }
        /// <summary>
        /// Get / Set business group type Id
        /// </summary>
        public long TypeId {get;set;}
        public virtual BusinessPosting Group { get; set; }
    }
}
