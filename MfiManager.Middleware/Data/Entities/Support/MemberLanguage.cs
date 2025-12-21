using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class MemberLanguage {
        public long MemberId { get; set; }
        public long LanguageId { get; set; }
        public virtual Member Member { get; set; }
        public virtual Language Language { get; set; }
    }
}
