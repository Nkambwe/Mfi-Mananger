using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations.Saving;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    /// <summary>
    /// Image file details for attached file
    /// </summary>
    public class ImageFile : BaseEntity {
        public string FileUrl { get; set; }
        public string Notes {get;set;}
        public long? FileId { get; set; }
        public virtual OtherFile File { get; set; }
        public long? TitleDeedId { get; set; }
        public virtual TitleDeed TitleDeed { get; set; }
        public long? IdentificationId { get; set; }
        public virtual Identification Identification { get; set; }
        public long? SavingPartnerId { get; set; }
        public virtual SavingPartner SavingPartner { get; set; }
    }
}
