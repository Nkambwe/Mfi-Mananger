namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class FileParameter {
        public string AttachmentName2 { get; set; }
        public string AttachmentName1 { get; set; }
        public string LocalFolder { get; set; }
        public string AttachmentBaseUrl { get; set; }
        public string AttachmentMainFolder { get; set; }
        public string AttachmentName1LocalFolder { get; set; }
        public string AttachmentName2LocalFolder { get; set; }
        public bool UseFtpStorage { get; set; } = false;
        public string FtpBaseUrl { get; set; }
        public string FtpMainFolder { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string AttachmentName1FtpFolder { get; set; }
        public string AttachmentName2FtpFolder { get; set; }
        public string ClientPhotoFtpFolder { get; set; }
        public string ClientSignatureFtpFolder { get; set; }
        public string IdentificationFtpFolder { get; set; }
        public string ClientPhotoLocalFolder { get; set; }
        public string IdentificationMainFolder { get; set; }
        public string IdentificationBaseUrl { get; set; }
        public string ClientSignatureBaseUrl { get; set; }
        public string ClientSignatureMainFolder { get; set; }
        public int MaximumImageSize { get; set; }
        public string ImageFileType { get; set; }
        public int DocumentFileSize { get; set; }
        public int VideoAndMp3FileSize { get; set; }
    }
}
