using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    /// <summary>
    /// Cheque book made of a range of cheque numbers relating to a given bank account
    /// </summary>
    public class ChequeBook : BaseEntity {
        public long BankAccountId  { get; set; }
        /// <summary>
        /// Get/Set cheque book serial number
        /// </summary>
        public string SerialNumber  { get; set; }
        /// <summary>
        /// Get/Set first cheque number in this cheque book
        /// </summary>
        public string FirstChequeNumber { get; set; }
        /// <summary>
        /// Get/Set last cheque number
        /// </summary>
        public string LastChequeNumber { get; set; }
        /// <summary>
        /// Get/Set number of cheque leafs in this book
        /// </summary>
        public int NumberOfLeafs  { get; set; }
        /// <summary>
        /// Get/Set last cheque number issued
        /// </summary>
        public string LastIssuedCheque  { get; set; }
        /// <summary>
        /// Get/Set whether cheque book status
        /// </summary>
        public BookStatus Status  { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual ICollection<Cheque> Cheques {get; set; } = [];
    }
}
