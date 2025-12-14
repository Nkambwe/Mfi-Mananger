namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class FolioType : BaseEntity {
        /// <summary>
        /// Folio type code eg.FIXASS for fixed assets, FIXACC for accumulated depreciation etc
        /// </summary>
        public string Code{get;set;}
        /// <summary>
        /// Folio type description
        /// </summary>
        public string Description{get;set;}
        public virtual ICollection<Folio> Folios {get;set;}=[];
    }
}
