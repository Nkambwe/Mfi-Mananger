namespace MfiManager.Middleware.Data.Entities.Support {

    public class Parish: BaseEntity {
        public string Code {get;set; }
        public string Name {get;set; }
        public virtual Village Village {get;set; }
    }
}
