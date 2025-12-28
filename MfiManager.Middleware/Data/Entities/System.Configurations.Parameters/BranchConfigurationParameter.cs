
namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class BranchConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "LedgerCode", description: "Branch ledger code", paramType: "int")]
        public string LedgerCode { get; set; }
        [ConfigParam(name: "TransactionCode", description: "Branch transaction code id", paramType: "string")]
        public string TransactionCode { get; set; }
    }

}
