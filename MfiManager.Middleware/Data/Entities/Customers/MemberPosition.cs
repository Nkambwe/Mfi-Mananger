using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Group member position history
    /// </summary>
    public class MemberPosition : BaseEntity {
        /// <summary>
        /// Get/Set when the position started
        /// </summary>
        public DateTime Started { get; set; }
        /// <summary>
        /// Get/Set when the position ended
        /// </summary>
        public DateTime? Ended { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public string Notes { get; set; }
    }
}
