using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// File associated with and insurance event 
    /// </summary>
    public class EventFile: BaseEntity {
        public long EventId { get; set; }
        public AttachmentType Type { get; set; }
        public string FilePath { get; set; }
        public virtual Event Event { get; set; }
    }
}
