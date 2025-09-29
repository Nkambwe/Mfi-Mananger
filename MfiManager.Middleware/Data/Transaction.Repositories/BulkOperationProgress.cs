namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public class BulkOperationProgress {
        public int ProcessedItems { get; set; }
        public int TotalItems { get; set; }
        public int CurrentBatch { get; set; }
        public int TotalBatches { get; set; }
        public int ErrorCount { get; set; }
        public double PercentComplete => TotalItems > 0 ? (double)ProcessedItems / TotalItems * 100 : 0;
    }

}
