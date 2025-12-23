using MfiManager.Middleware.Data.Entities.Customer.Files;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// File associated with and insurance event 
    /// </summary>
    public class EventFile: FileAttachment {
        public long EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
