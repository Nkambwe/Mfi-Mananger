namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class StatisticConfiguration {
        [ConfigParam(name: "Individuals", description: "Individual customers statistics", paramType: "int")]
        public string Individuals { get; set; }
        [ConfigParam(name: "Groups", description: "Group customers statistics", paramType: "int")]
        public string Groups { get; set; }
        [ConfigParam(name: "Clusters", description: "Group clusters statistics", paramType: "int")]
        public string Clusters { get; set; }
        [ConfigParam(name: "Members", description: "Group members statistics", paramType: "int")]
        public string Members { get; set; }
        [ConfigParam(name: "Businesses", description: "Businesses customers statistics", paramType: "int")]
        public string Businesses { get; set; }
        [ConfigParam(name: "Guarantors", description: "Loan Guarantors statistics", paramType: "int")]
        public string Guarantors { get; set; }
        [ConfigParam(name: "ExternalHolders", description: "Non-Customer Savings Partners statistics", paramType: "int")]
        public string ExternalHolders { get; set; }
        [ConfigParam(name: "SavingAccounts", description: "Saving Accounts statistics", paramType: "int")]
        public string SavingAccounts { get; set; }
        [ConfigParam(name: "TimedepositAccounts", description: "Timedeposit Accounts statistics", paramType: "int")]
        public string TimedepositAccounts { get; set; }
        [ConfigParam(name: "ShareAccounts", description: "Share Accounts statistics", paramType: "int")]
        public string ShareAccounts { get; set; }
        [ConfigParam(name: "Policies", description: "Insurance Policies statistics", paramType: "int")]
        public string Policies { get; set; }
        [ConfigParam(name: "Loans", description: "Loan accounts statistics", paramType: "int")]
        public string Loans { get; set; }
     }

}
