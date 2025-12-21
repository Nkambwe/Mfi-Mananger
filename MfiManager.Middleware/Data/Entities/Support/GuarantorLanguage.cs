using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class GuarantorLanguage {
        public long GuarantorId { get; set; }
        public long LanguageId { get; set; }
        public virtual Guarantor Guarantor { get; set; }
        public virtual Language Language { get; set; }
    }

}
