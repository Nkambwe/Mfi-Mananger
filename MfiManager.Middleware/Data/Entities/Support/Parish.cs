namespace MfiManager.Middleware.Data.Entities.Support {

    public class Parish: BaseEntity {
        public string Code {get;set; }
        public string Name {get;set; }
        public long DistrictId {get;set; }
        public virtual District District {get;set; }
        public virtual ICollection<Village> Villages {get;set; }
    }
}
