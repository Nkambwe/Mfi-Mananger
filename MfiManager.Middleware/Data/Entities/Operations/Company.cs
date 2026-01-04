using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Data.Entities.System.Configurations;

namespace MfiManager.Middleware.Data.Entities.Operations {

    public class Company : BaseEntity {
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string RegistrationNumber { get; set; }
        public string SystemLanguage { get; set; }
        public virtual ICollection<CostCenter> CostCenters { get; set; } = [];
        public virtual ICollection<RevenueCenter> RevenueCenters { get; set; } = [];
        public virtual ICollection<ProductType> ProductTypes { get; set; } = [];
        public virtual ICollection<Branch> Branches { get; set; } = [];
        public virtual ICollection<Department> Departments { get; set; } = [];
        public virtual ICollection<SystemError> SystemErrors { get; set; } = [];
        public virtual ICollection<SystemParam> SystemConfigurations { get; set; } = [];
        public virtual ICollection<SeriesParam> SeriesParams { get; set; } = [];
        public virtual ICollection<EncryptionSetting> EncryptionSettings { get; set; } = [];
        public override string ToString() => $"{CompanyName}";
        public override bool Equals(object obj) {

            if (obj is not Company)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (Company)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.CompanyName.Equals(CompanyName) && item.Id.Equals(Id);
        }

        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }

}
