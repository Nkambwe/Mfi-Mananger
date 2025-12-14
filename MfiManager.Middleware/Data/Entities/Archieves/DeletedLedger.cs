using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Entities.Archieves {
    public class DeletedLedger : BaseEntity {
        public string TransactionId {get;set;}
        public DateTime PostedOn {get;set;}
        public string Particulars {get;set;}
        public string Folio {get;set;}
        public string LedgerNumber {get;set;}
        public string PostingSeries {get;set;}
        public string Voucher {get;set;}
        public decimal Debit {get;set;}
        public decimal Credit {get;set;}
        public string Currency  {get;set;}
        public decimal ExchangeAmount  {get;set;}
        public string GeneralPosting {get;set;}
        public string BusinessPosting {get;set;}
        public string ChargePosting {get;set;}
        public string Reference1 {get;set;}
        public string Reference2 {get;set;}
        public string Reference3 {get;set;}
        public string Reference4 {get;set;}
        public string Reference5 {get;set;}
        public string Reference6 {get;set;}
        public string TaxCode {get;set;}
        public decimal Tax {get;set;}
        public decimal Tax2 {get;set;}
        public bool Closed {get;set;}
        public DateTime? ClosedOn  {get;set;}
        public string Comment {get;set;}
        public string LedgerId  {get;set;}
        public string Cashier  {get;set;}
        public string DeletedBy {get;set;}
        public virtual Company Company { get; set; }
    }
}
