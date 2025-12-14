namespace MfiManager.Middleware.Data.Entities.Support {
    public class District: BaseEntity {
        public string Code {get;set; }
        public string Name {get;set; }
        public virtual Parish Parishes {get;set; }
    }
}
