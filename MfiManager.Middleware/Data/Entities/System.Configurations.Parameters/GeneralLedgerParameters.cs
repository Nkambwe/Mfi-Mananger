
namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    
    public class GeneralLedgerParameters {
        /// <summary>
        /// Check whether vouchers are allowed
        /// </summary>
        public bool UseVouchers { get; set; }
        /// <summary>
        /// Check whether to activate accounts payable
        /// </summary>
        public bool ActivateAccountsPayable { get; set; }
        /// <summary>
        /// Check whether to activate accounts payable
        /// </summary>
        public bool ActivateAccountsReceivable { get; set; }
        /// <summary>
        /// Check whether to soft delete transactions
        /// </summary>
        public bool SoftDeleteRecords { get; set; } = false;
        /// <summary>
        /// Check whether to activate accounts payable
        /// </summary>
        public bool ArchiveSoftDeleteRecords { get; set; } = false;

    }
}
