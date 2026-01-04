using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class FileConfigurationParameters: IConfigurationParameter {
        [ConfigParam(name: "AttachmentName1", description: "Attachment 1 name", paramType: "string")]
        public string AttachmentName1 { get; set; }
        [ConfigParam(name: "AttachmentName2", description: "Attachment 2 name", paramType: "string")]
        public string AttachmentName2 { get; set; }
        [ConfigParam(name: "LocalFolder", description: "Local folder name", paramType: "string")]
        public string LocalFolder { get; set; }
        [ConfigParam(name: "AttachmentBaseUrl", description: "Attachment base URL", paramType: "string")]
        public string AttachmentBaseUrl { get; set; }
        [ConfigParam(name: "AttachmentMainFolder", description: "Attachment main folder name", paramType: "string")]
        public string AttachmentMainFolder { get; set; }
        [ConfigParam(name: "AttachmentName1LocalFolder", description: "Attachment 1 name FTP local folder name", paramType: "string")]
        public string AttachmentName1LocalFolder { get; set; }
        [ConfigParam(name: "AttachmentName2LocalFolder", description: "Attachment 2 name FTP local folder name", paramType: "string")]
        public string AttachmentName2LocalFolder { get; set; }
        [ConfigParam(name: "UseFtpStorage", description: "Check wether to use FTP for file storage", paramType: "bool")]
        public string UseFtpStorage { get; set; }
        [ConfigParam(name: "FtpBaseUrl", description: "FTP base URL", paramType: "string")]
        public string FtpBaseUrl { get; set; }
        [ConfigParam(name: "FtpMainFolder", description: "FTP main folder name", paramType: "string")]
        public string FtpMainFolder { get; set; }
        [ConfigParam(name: "FtpUserName", description: "FTP access username", paramType: "string")]
        public string FtpUserName { get; set; }
        [ConfigParam(name: "FtpPassword", description: "FTP access password", paramType: "string")]
        public string FtpPassword { get; set; }
        [ConfigParam(name: "AttachmentName1FtpFolder", description: "Attachment 1 name FTP folder name", paramType: "string")]
        public string AttachmentName1FtpFolder { get; set; }
        [ConfigParam(name: "AttachmentName2FtpFolder", description: "Attachment 2 name FTP folder name", paramType: "string")]
        public string AttachmentName2FtpFolder { get; set; }
        [ConfigParam(name: "ClientPhotoFtpFolder", description: "Client photo FTP folder name", paramType: "string")]
        public string ClientPhotoFtpFolder { get; set; }
        [ConfigParam(name: "ClientSignatureFtpFolder", description: "Client Signature FTP folder name", paramType: "string")]
        public string ClientSignatureFtpFolder { get; set; }
        [ConfigParam(name: "IdentificationFtpFolder", description: "Identification FTP folder name", paramType: "string")]
        public string IdentificationFtpFolder { get; set; }
        [ConfigParam(name: "ClientPhotoLocalFolder", description: "Client photo local folder name", paramType: "string")]
        public string ClientPhotoLocalFolder { get; set; }
        [ConfigParam(name: "IdentificationMainFolder", description: "Identification main folder name", paramType: "string")]
        public string IdentificationMainFolder { get; set; }
        [ConfigParam(name: "IdentificationBaseUrl", description: "Identification base URL", paramType: "string")]
        public string IdentificationBaseUrl { get; set; }
        [ConfigParam(name: "ClientSignatureBaseUrl", description: "Client signature base URL", paramType: "string")]
        public string ClientSignatureBaseUrl { get; set; }
        [ConfigParam(name: "ClientSignatureMainFolder", description: "Client signature main folder name", paramType: "string")]
        public string ClientSignatureMainFolder { get; set; }
        [ConfigParam(name: "MaximumImageSize", description: "Maximum image file size", paramType: "int")]
        public string MaximumImageSize { get; set; }
        [ConfigParam(name: "ImageFileType", description: "Image File Type", paramType: "string")]
        public string ImageFileType { get; set; }
        [ConfigParam(name: "DocumentFileSize", description: "Document file size", paramType: "int")]
        public string DocumentFileSize { get; set; }
        [ConfigParam(name: "VideoAndMp3FileSize", description: "Video and MP3 file size", paramType: "int")]
        public string VideoAndMp3FileSize { get; set; }
    }

}
