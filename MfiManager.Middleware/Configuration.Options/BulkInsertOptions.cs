using EFCore.BulkExtensions;

namespace MfiManager.Middleware.Configuration.Options {

    public class BulkInsertOptions {
        public bool SetOutputIdentity { get; set; } = false;
        public bool PreserveInsertOrder { get; set; } = false;
        public SqlBulkCopyOptions SqlBulkCopyOptions { get; set; } = SqlBulkCopyOptions.Default;
        public int BatchSize { get; set; } = 0; 
    }

}
