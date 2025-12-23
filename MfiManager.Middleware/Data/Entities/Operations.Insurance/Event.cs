namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance claim event
    /// </summary>
    public class Event : BaseEntity {
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? AdminissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string Notes { get; set; }
        public long PolicyId {get;set;}
        public virtual Policy Policy { get; set; }
        public virtual ICollection<EventFile> Files {get;set;}
    }
}
