namespace MfiManager.Middleware.Data.Entities.System {

    public class SystemError: BaseEntity {
        public long CompanyId { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Severity { get; set; }
        public string StackTrace { get; set; }
        public string Status { get; set; }
    }
}
