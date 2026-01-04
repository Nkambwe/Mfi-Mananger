using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {

    public class InvoicingDefault : BaseEntity {
        /// <summary>
        /// Invoice account in cases of multi-branch sales
        /// </summary>
        public string MultiBranchInvoiceAccount  {get;set; }
        public string InvoicingLedger  {get;set; }
        public string InvoicingAddress  {get;set; }
        public bool PriceIncludesSalesTax  {get;set; }
        public bool PriceIncludesWithHoldingTax  {get;set; }
        public bool PriceIncludesVat  {get;set;}
        public long? TraderId {get;set; }
        public virtual Trader Trader { get;set; }
        public long? SupplierId {get;set; }
        public virtual SupplierInfo Supplier { get;set; }
    }

}
