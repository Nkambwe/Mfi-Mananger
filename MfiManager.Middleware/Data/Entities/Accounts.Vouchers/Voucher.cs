using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {

    /// <summary>
    /// Voucher or journal voucher object. Capture transactions that are not part of the day-today transactions
    /// such as prepayments, depreciation, sale of access, fx revaluation, recurring transactions
    /// </summary>
    public class Voucher  : BaseEntity {
        /// <summary>
        /// Get/Set transaction code
        /// </summary>
        public string TransactionCode { get; set; }
        /// <summary>
        /// Get/Set transaction date
        /// </summary>
        public DateTime PostedOn { get; set; }
        /// <summary>
        /// Get/Set details for the transactions
        /// </summary>
        public string Particulars{ get; set; }
        /// <summary>
        /// Get/Set transaction reference code
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// Get/Set voucher number
        /// </summary>
        public string VoucherNumber{ get; set; }
        /// <summary>
        /// Get/Set customer or supplier code 
        /// </summary>
        public string RelatesTo { get; set; }
        /// <summary>
        /// Cash voucher transaction type reference
        /// </summary>
        public CashLedgerFolio CashRef { get; set; }
        /// <summary>
        /// Get/Set method of payment
        /// </summary>
        public PaymentMethod Payment{ get; set; }
        /// <summary>
        /// Get/Set clearance status
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }
        /// <summary>
        /// Get/Set debit
        /// </summary>
        public decimal Debit { get; set; }
        /// <summary>
        /// Get/Set credit
        /// </summary>
        public decimal Credit{ get; set; }
        /// <summary>
        /// Get/Set amount to be credited as discount received
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Get/Set name of person authorizing payment
        /// </summary>
        public string Authorized { get; set; }
        /// <summary>
        /// Get/Set code for cashier
        /// </summary>
        public string Cashier { get; set; }
        public long TransactionDocumentId { get; set; }
        public long? GeneralJournalTransactionId { get; set; }
        public long? GeneralLedgerTransactionId { get; set; }
        public virtual Journal GeneralJournalTransaction { get; set; }
        public virtual Ledger GeneralLedgerTransaction { get; set; }
        public virtual TransactionDocument TransactionDocument { get; set; }
    }

}
