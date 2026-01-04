using MfiManager.Middleware.Data.Entities.Customer.Files;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;
using MfiManager.Middleware.Security;

namespace MfiManager.Middleware.Utils {

    public class ObjectMapper(IEncryptionService crypto) : IObjectMapper {
        
        private readonly IEncryptionService _crypto = crypto;
        public SystemError ToSystemErrorRequest(AppErrorRequest model)
            => new() {
                CompanyId = model.CompanyId,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace
            };

        public AppErrorResponse ToSystemErrorRequest(SystemError model)
           => new() {
               Id = model.Id,
               Source = model.Source,
               Message = model.Message,
               Severity = model.Severity,
               StackTrace = model.StackTrace,
               IsDeleted = model.IsDeleted,
               Status = model.Status,
               CreatedOn = model.CreatedOn
           };

        //public ImageResponse Map(this ImageFile source) {
        //    long? FileId = null;
        //    if (source.File != null)
        //        FileId = source.File.Id;

        //    if (source.Identification != null)
        //        FileId = source.Identification.Id;

        //    if (source.TitleDeed != null)
        //        FileId = source.TitleDeed.Id;

        //    return new ImageResponse {
        //        FileId = FileId,
        //        FileDate = source.CreatedOn.Date,
        //        FileImage = !string.IsNullOrEmpty(source.FileUrl ?? string.Empty) ? (source.FileUrl ?? string.Empty).Trim() : string.Empty,
        //        FileAddedBy = !string.IsNullOrEmpty(source.CreatedBy ?? string.Empty) ? (source.CreatedBy ?? string.Empty).Trim() : string.Empty
        //    };
        //}

        //public ImageFile Map(this ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null)
        //    => new() {
        //        IdentificationId = identification?.Id,
        //        TitleDeedId = deed?.Id,
        //        FileId = other?.Id,
        //        IsDeleted = (identification?.IsDeleted ?? false) || (deed?.IsDeleted ?? false) || (other?.IsDeleted ?? false),
        //        CreatedOn = source.FileDate.Date,
        //        FileUrl = !string.IsNullOrWhiteSpace(source.FileImage) ? source.FileImage.Trim() : string.Empty,
        //        CreatedBy = !string.IsNullOrWhiteSpace(source.FileAddedBy) ? source.FileAddedBy.Trim() : string.Empty
        //    };

        //public ImageFile Update(this ImageFile record, ImageResponse source, Identification identification = null, TitleDeed deed = null, OtherFile other = null) {
        //    record.IdentificationId = identification?.Id;
        //    record.TitleDeedId = deed?.Id;
        //    record.FileId = other?.Id;
        //    record.IsDeleted = (identification?.IsDeleted ?? false) || (deed?.IsDeleted ?? false) || (other?.IsDeleted ?? false);
        //    record.CreatedOn = source.FileDate.Date;
        //    record.FileUrl = !string.IsNullOrWhiteSpace(source.FileImage) ? source.FileImage.Trim() : string.Empty;
        //    record.CreatedBy = !string.IsNullOrWhiteSpace(source.FileAddedBy) ? source.FileAddedBy.Trim() : string.Empty;
        //    return record;
        //}

        public IndividualResponse Map(Individual record, EncryptionConfig config) {
            var response = new IndividualResponse {
                Id = record.Id,
                NationalityId = record.NationalityId,
                FirstName = record.FirstName ?? string.Empty,
                MiddleName = record.MiddleName ?? string.Empty,
                LastName = record.LastName ?? string.Empty
            };

            return DecryptEncryptedFields<IndividualResponse>(response, config, _crypto, nameof(Individual));
        } 

        public T DecryptEncryptedFields<T>(T response, EncryptionConfig config, IEncryptionService crypto, string entityName) {
            var dtoType = typeof(T);

            foreach (var prop in dtoType.GetProperties()) {
                if (prop.PropertyType != typeof(string))
                    continue;

                if (!config.IsEncrypted(entityName, prop.Name))
                    continue;

                var value = prop.GetValue(response) as string;
                if (string.IsNullOrEmpty(value))
                    continue;

                prop.SetValue(response, crypto.Decrypt(value));
            }

            return response;
        }
    }

}
