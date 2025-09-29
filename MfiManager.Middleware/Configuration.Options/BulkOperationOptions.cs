namespace MfiManager.Middleware.Configuration.Options {

    public class BulkOperationOptions {
         public const string SectionName = "BulkOperations";
        public int DefaultBatchSize { get; set; } = 10000;
        public int EFCoreThreshold { get; set; } = 1000;
        public bool PreferEFCore { get; set; } = false;
        public bool ContinueOnBatchError { get; set; } = false;
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromMinutes(30);
    }

}
