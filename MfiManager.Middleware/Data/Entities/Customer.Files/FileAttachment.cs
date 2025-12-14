using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    public abstract class FileAttachment : BaseEntity {
        public AttachmentType FileType {get;set;}
        public string Notes {get;set;}
    }
}
