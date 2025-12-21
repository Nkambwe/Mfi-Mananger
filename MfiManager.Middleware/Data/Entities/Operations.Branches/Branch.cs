using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Archieves;
using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Data.Entities.System.Configurations;
using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;

namespace MfiManager.Middleware.Data.Entities.Operations.Branches {

    public class Branch : BaseEntity {
        public long CompanyId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string PostalAddress { get; internal set; }
        public long? AccountsChartId { get; set; }
        public virtual Company Company { get; set; }
        public virtual AccountsChart AccountsChart { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; } = [];
        public virtual ICollection<UnSealedCustomerFile> LockedFiles { get; set; } = [];
        public virtual ICollection<SystemConfiguration> Configurations { get; set; } = [];
        public virtual ICollection<SeriesNumber> SeriesNumbers { get; set; } = [];
        public virtual ICollection<RecurringItem> RecurringItems { get; set; } = [];
        public virtual ICollection<EntityAccess> Entities { get; set; } = [];
        public virtual ICollection<BranchCostCenter> CostCenters { get; set; } = [];
        public virtual ICollection<BranchLedgerAccount> LedgerAccounts { get; set; } = [];
        public virtual ICollection<BranchDepartment> Departments { get; set; } = [];
        public virtual ICollection<BranchReference> References { get; set; } = [];
        public virtual ICollection<BranchRevenueCenter> BranchRevenueCenters { get; set; } = [];
        public virtual ICollection<LabelFormat> LabelFormats { get; set; } = [];
        public virtual ICollection<ConfigurationParameter> ConfigurationParameters { get; set; } = [];
        public virtual ICollection<TimedepositAccount> TimedepositAccounts { get; set; } = [];
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<BranchRevolvingFund> RevolvingFunds {get;set;} = [];
        public virtual ICollection<FinancialYear> FinancialYears {get;set;} = [];
        public virtual ICollection<Group> Groups { get; set; } = [];
        public virtual ICollection<GroupArchive> GroupArchives { get; set; } = [];
        public virtual ICollection<Individual> Individuals { get; set; } = [];
        public virtual ICollection<IndividualArchive> IndividualArchives { get; set; } = [];
        public virtual ICollection<Business> Businesses { get; set; } = [];
        public virtual ICollection<BusinessArchive> BusinessArchives { get; set; } = [];
        public virtual ICollection<DeletedLedger> DeletedLedgers { get; set; } = [];

        public override bool Equals(object obj) {

            if (obj is not Branch)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (Branch)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.BranchCode.Equals(BranchCode) && item.BranchName.Equals(BranchName);
        }
        public override string ToString() => $"{BranchCode}-{BranchName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
