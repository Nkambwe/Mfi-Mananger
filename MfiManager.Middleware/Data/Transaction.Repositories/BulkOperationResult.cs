namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public class BulkOperationResult<T> {
        public bool IsSuccess { get; set; }
        public int AffectedRows { get; set; }
        public List<string> Errors { get; set; } = [];
        public Exception Exception { get; set; }
        public TimeSpan Duration { get; set; }
        public string OperationId { get; set; } = string.Empty;

        public static BulkOperationResult<T> Failed(string error, Exception exception = null) {
            return new BulkOperationResult<T> {
                IsSuccess = false,
                Errors = [error],
                Exception = exception
            };
        }
    }
}
