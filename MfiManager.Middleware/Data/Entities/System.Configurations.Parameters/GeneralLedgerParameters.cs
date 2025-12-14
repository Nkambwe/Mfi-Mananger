
namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GeneralLedgerParameters : IConfigurationParameter {
        public long CompanyId { get; set; }
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

        public bool SoftDeleteRecords { get; set; } = false;

        public bool ArchiveSoftDeleteRecords { get; set; } = false;

    }
}
