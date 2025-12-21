using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class IndividualLanguage {
        public long IndividualId { get; set; }
        public long LanguageId { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual Language Language { get; set; }
    }

}
