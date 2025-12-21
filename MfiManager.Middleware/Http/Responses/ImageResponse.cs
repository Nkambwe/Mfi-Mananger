namespace MfiManager.Middleware.Http.Responses {
    public class ImageResponse {
        public long Id { get; set; }
        public long? FileId { get; set; }
        public DateTime FileDate { get; set; }
        public string FileImage { get; set; }
        public string FileAddedBy { get; set; }
    }
}
