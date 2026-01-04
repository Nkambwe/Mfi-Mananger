using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GeneralLedgerConfigurationParameters : IConfigurationParameter {
        /// <summary>
        /// Check whether vouchers are allowed
        /// </summary>
        [ConfigParam(name: "UseVouchers", description: "Use vouchers in transactions", paramType: "bool")]
        public bool UseVouchers { get; set; }
        /// <summary>
        /// Check whether journals are allowed
        /// </summary>
        [ConfigParam(name: "UseJournals", description: "Use journal in transactions", paramType: "bool")]
        public bool UseJournals { get; set; }
        /// <summary>
        /// Check whether to activate accounts payable
        /// </summary>
        [ConfigParam(name: "ActivateAccountsPayable", description: "Activate accounts payable", paramType: "bool")]
        public bool ActivateAccountsPayable { get; set; }
        /// <summary>
        /// Check whether to activate accounts receivable
        /// </summary>
        [ConfigParam(name: "ActivateAccountsReceivable", description: "Activate accounts receivable", paramType: "bool")]
        public bool ActivateAccountsReceivable { get; set; }
        /// <summary>
        /// Check whether to soft delete records
        /// </summary>
        [ConfigParam(name: "SoftDeleteRecords", description: "Turn on soft delete of records", paramType: "bool")]
        public bool SoftDeleteRecords { get; set; } = false;
        /// <summary>
        /// Check whether to archieve soft delete records
        /// </summary>
        [ConfigParam(name: "ArchiveSoftDeleteRecords", description: "Check wether to soft delete records", paramType: "bool")]
        public bool ArchiveSoftDeleteRecords { get; set; } = false;

    }

}
