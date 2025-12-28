using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.System.Configurations {
    public class LoanProductParam : BaseEntity {
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
        /// <summary>
        /// Gets or sets the product for which this setting applies
        /// </summary>
        public long LoanProductId { get; set; }
        public virtual LoanProduct LoanProduct { get; set; }
        public override string ToString() => $"{(ParameterName ?? string.Empty).Trim()}";
    }
}
