using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;

namespace MfiManager.Middleware.Utils {
    public static class Mapper {

        public static SystemError ToSystemErrorRequest(AppErrorRequest model)
            => new(){ 
                CompanyId = model.CompanyId,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace
            };

         public static AppErrorResponse ToSystemErrorRequest(SystemError model)
            => new(){ 
                Id = model.Id,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace,
                IsDeleted = model.IsDeleted,
                Status = model.Status,
                CreatedOn = model.CreatedOn
            };

        public static ImageResponse Map(this ImageFile source) {
            long? attachmentId = null;
            if (source.Attachment != null)
                attachmentId = source.Attachment.Id;

            if (source.Identification != null)
                attachmentId = source.Identification.Id;

            if (source.Title != null)
                attachmentId = source.Title.Id;

            return new ImageResponse {
                AttachmentId = attachmentId,
                FileDate = source.AddedOn.Date,
                FileImage = !string.IsNullOrEmpty(source.File ?? string.Empty) ? (source.File ?? string.Empty).Trim() : string.Empty,
                FileAddedBy = !string.IsNullOrEmpty(source.CreatedBy ?? string.Empty) ? (source.CreatedBy ?? string.Empty).Trim() : string.Empty
            };
        }

        public static ImageFile Map(this ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null)
            => new() {
                IdentificationId = identification?.Id,
                TitleId = deed?.Id,
                OtherFileId = other?.Id,
                AddedOn = source.FileDate.Date,
                File = !string.IsNullOrEmpty(source.FileImage ?? string.Empty) ? (source.FileImage ?? string.Empty).Trim() : string.Empty,
                CreatedBy = !string.IsNullOrEmpty(source.FileAddedBy ?? string.Empty) ? (source.FileAddedBy ?? string.Empty).Trim() : string.Empty
            };

        public static ImageFile Update(this ImageFile record, ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null) {
            record.IdentificationId = identification?.Id;
            record.TitleId = deed?.Id;
            record.OtherFileId = other?.Id;
            record.AddedOn = source.FileDate.Date;
            record.File = !string.IsNullOrEmpty(source.FileImage ?? string.Empty) ? (source.FileImage ?? string.Empty).Trim() : string.Empty;
            record.CreatedBy = !string.IsNullOrEmpty(source.FileAddedBy ?? string.Empty) ? (source.FileAddedBy ?? string.Empty).Trim() : string.Empty;
            return record;
        }
    }
}
