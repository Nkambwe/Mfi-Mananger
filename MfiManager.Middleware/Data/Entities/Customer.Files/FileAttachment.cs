using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Customer.Files {
    public abstract class FileAttachment : BaseEntity {
        public string Series {get;set; }
        public string FileUrl {get;set; }
        public AttachmentType FileType {get;set;}
        public string Notes {get;set;}
    }
}
