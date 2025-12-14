using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// Image file details for attached file
    /// </summary>
    public class ImageFile : FileAttachment {
        public long? OtherFileId { get; set; }
        public long? TitleId { get; set; }
        public long? IdentificationId { get; set; }
        public DateTime AddedOn { get; set; }
        public string File { get; set; }
        public virtual OtherFile Attachment { get; set; }
        public virtual TitleDeed Title { get; set; }
        public virtual Identification Identification { get; set; }
    }
}
