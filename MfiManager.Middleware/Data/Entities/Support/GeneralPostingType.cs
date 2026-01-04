
namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// General transaction posting groups eg.
    /// Domestic (for domestic transactions), Foreign (for foreign transactions),
    /// Exports (for export transactions), Imports (for import transactions),
    /// </summary>
    public class GeneralPostingType : BaseEntity {
        public string Code {get;set; }
        public string SeriesIdentifier {get;set; }
        public string CustomSeries {get;set; }
        public string Description {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<GeneralPostingItem> GeneralPostingItems {get;set; } =[];
       
    }
}
