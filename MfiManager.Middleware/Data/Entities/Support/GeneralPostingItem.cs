namespace MfiManager.Middleware.Data.Entities.Support {
    public class GeneralPostingItem : BaseEntity {
        public string Code {get;set; }
        public string Series {get;set; }
        public string Description {get;set; }
        public string Notes {get;set; }
        public long TypeId {get; set; }

        public virtual GeneralPosting Group { get; set; }
    }
}
