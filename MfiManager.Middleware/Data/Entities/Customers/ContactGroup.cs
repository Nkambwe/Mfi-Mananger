namespace MfiManager.Middleware.Data.Entities.Customers {
    public abstract class ContactGroup : BaseEntity {
        public string Code {get; set;}
        public string Group  {get; set;}
        public string Notes {get; set;}
    }
}
