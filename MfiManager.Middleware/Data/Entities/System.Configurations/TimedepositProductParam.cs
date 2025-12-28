using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.System.Configurations {
    public class TimedepositProductParam : BaseEntity {
        /// <summary>
        /// Gets or sets the parameter name
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string ParamValue { get; set; }
        /// Get/Set param data type
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// Get/Set param description
        /// </summary>
        public string ParamDescription { get; set; }

        public long TimedepositProductId { get; set; }
        public virtual TimedepositProduct TimedepositProduct { get; set; }
        public override string ToString() => $"{(ParameterName ?? string.Empty).Trim()}";
    }
}
