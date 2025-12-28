namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class StatisticParameters : IConfigurationParameter {
        public int Individuals { get; set; }
        public int Groups { get; set; }
        public int Clusters { get; set; }
        public int Members { get; set; }
        public int Businesses { get; set; }
        public int Guarantors { get; set; }
        public int ExternalHolders { get; set; }
        public int SavingAccounts { get; set; }
        public int TimedepositAccounts { get; set; }
        public int ShareAccounts { get; set; }
        public int Policies { get; set; }
        public int Loans { get; set; }

    }

}
