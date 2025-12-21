
namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class TransactionDocumentType : BaseEntity {
        public string Code {get;set;}
        public string TypeName {get;set;}
        public virtual ICollection<SeriesNumber> SeriesNumbers {get;set;} = [];
        public virtual ICollection<TransactionDocument> TransactionDocuments {get;set;} = [];
        
    }
}
