using System.Linq.Expressions;

namespace MfiManager.Middleware.Configuration.Options {
    public class BulkUpdateOptions<T> {
        public bool SetOutputIdentity { get; set; } = true;
        public bool PreserveInsertOrder { get; set; } = true;
        public Expression<Func<T, object>>[] PropertiesToUpdate { get; set; }
        public int BatchSize { get; set; } = 0;
    }

}
