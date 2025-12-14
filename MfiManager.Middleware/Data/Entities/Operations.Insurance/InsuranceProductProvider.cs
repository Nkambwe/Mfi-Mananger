using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    public class InsuranceProductProvider {
        public long ProductId { get; set; }
        public long ProviderId { get; set; }
        public virtual InsuranceProduct Product { get; set; }
        public virtual Provider Provider { get; set; }
    }

}
