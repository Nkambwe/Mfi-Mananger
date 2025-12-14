
namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    public class Provider :BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public virtual ICollection<InsuranceProductProvider> Products {get;set; }=[];
        public virtual ICollection<Policy> Policies {get;set;}=[];
    }
}
