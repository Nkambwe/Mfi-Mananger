using MfiManager.Middleware.Data.Entities.Operations.Branches;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    /// <summary>
    /// Number series for document eg. Purchase invoices, sales invoices, clients etc.
    /// </summary>
    public class SeriesNumbers : BaseEntity {
        public long? BranchId { get; set; }
        public string Identifier { get; set; }
        public string CustomSeries { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime Starts { get; set; }
        public long StartNumber { get; set; }
        public long EndNumber { get; set; }
        public DateTime? LastUsed { get; set; }
        public long LastNumber { get; set; }
        public bool Default  { get; set; }
        public bool Manual {get;set;}
        public virtual Branch Branch { get; set; }

    }
}
