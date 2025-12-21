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
            long? FileId = null;
            if (source.File != null)
                FileId = source.File.Id;

            if (source.Identification != null)
                FileId = source.Identification.Id;

            if (source.TitleDeed != null)
                FileId = source.TitleDeed.Id;
            
            return new ImageResponse {
                FileId = FileId,
                FileDate = source.CreatedOn.Date,
                FileImage = !string.IsNullOrEmpty(source.FileUrl ?? string.Empty) ? (source.FileUrl ?? string.Empty).Trim() : string.Empty,
                FileAddedBy = !string.IsNullOrEmpty(source.CreatedBy ?? string.Empty) ? (source.CreatedBy ?? string.Empty).Trim() : string.Empty
            };
        }

        public static ImageFile Map(this ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null)
            => new() {
                IdentificationId = identification?.Id,
                TitleDeedId = deed?.Id,
                FileId = other?.Id,
                IsDeleted =(identification?.IsDeleted ?? false) || (deed?.IsDeleted ?? false) ||(other?.IsDeleted ?? false),
                CreatedOn = source.FileDate.Date,
                FileUrl = !string.IsNullOrWhiteSpace(source.FileImage) ? source.FileImage.Trim() : string.Empty,
                CreatedBy = !string.IsNullOrWhiteSpace(source.FileAddedBy) ? source.FileAddedBy.Trim() : string.Empty
            };

        public static ImageFile Update(this ImageFile record, ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null) {
            record.IdentificationId = identification?.Id;
            record.TitleDeedId = deed?.Id;
            record.FileId = other?.Id;
            record.IsDeleted = (identification?.IsDeleted ?? false) || (deed?.IsDeleted ?? false) ||(other?.IsDeleted ?? false);
            record.CreatedOn = source.FileDate.Date;
            record.FileUrl = !string.IsNullOrWhiteSpace(source.FileImage) ? source.FileImage.Trim() : string.Empty;
            record.CreatedBy = !string.IsNullOrWhiteSpace(source.FileAddedBy) ? source.FileAddedBy.Trim() : string.Empty;
            return record;
        }
    }
}
