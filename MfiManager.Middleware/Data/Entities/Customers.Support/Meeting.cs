using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Group meeting info
    /// </summary>
    public class Meeting : BaseEntity {
        
        public string MeetingDays { get; set; }
        public string MeetingTime { get; set; }
        /// <summary>
        /// Get/Set number of meetings held
        /// </summary>
        public int MeetingsHeld { get; set; }
        public Interval Frequency { get; set; }
        public long GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
