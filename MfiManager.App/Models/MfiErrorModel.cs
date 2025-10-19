namespace MfiManager.App.Models {
    public class MfiErrorModel {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Severity { get; set; }
        public string StackTrace { get; set; }
    }
}
