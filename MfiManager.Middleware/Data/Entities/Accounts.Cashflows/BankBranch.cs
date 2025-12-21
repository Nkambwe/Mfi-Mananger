namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    public class BankBranch : BaseEntity {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchContact { get; set; }
        public string ContactDesignation { get; set; }
        public string ContactEmail { get; set; }
        public string PrimaryLine { get; set; }
        public string SecondaryLine { get; set; }
        public string BranchFax  { get; set; }
        public long BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public ICollection<BankAccount> Accounts {get;set;} = [];

    }
}
