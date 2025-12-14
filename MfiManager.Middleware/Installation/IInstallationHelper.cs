using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Customer.Filters;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Data.Entities.System.Configurations;
using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Installation {

    public interface IInstallationHelper {

        #region Sample data

        Company GetSampleCompany();
        Branch GetMainBranch(long companyId);
        SystemUser GenerateDefaultUser(long branchId);

        #endregion

        #region Default Data

        IReadOnlyList<FolioType> GetSystemFolios();
        IReadOnlyList<Currency> GetSystemCurrencies();
        IReadOnlyList<Department> GetSystemDepartments();
        IReadOnlyList<CostCenter> GetSystemCostCenters();
        IReadOnlyList<VoucherType> GetSystemVouchers();
        IReadOnlyList<JournalType> GetSystemJournals();
        IReadOnlyList<ChargeItem> GetDefaultCharges();
        IReadOnlyList<District> GetDistricts();
        IReadOnlyList<Parish> GetParishes();
        IReadOnlyList<Village> GetVillages();
        IReadOnlyList<Iban> GetDefaultIban();
        IReadOnlyList<Swift> GetDefaultSwift();
        IReadOnlyList<Title> GetDefaultTitles();
        IReadOnlyList<Profession> GetDefaultProfessions();
        IReadOnlyList<Nationality> GetDefaultNationalities();
        IReadOnlyList<Language> GetDefaultLanguages();
        IReadOnlyList<IssuerAuthority> GetDefaultAuthorities();
        IReadOnlyList<IdentificationType> GetDefaultIdentificationTypes();
        IReadOnlyList<Income> GetDefaultIncomes();
        IReadOnlyList<ReasonCategory> GetDefaultReasons();
        IEnumerable<ClientFilter1> GetClientFilter1();
        IReadOnlyList<ClientFilter2> GetClientFilter2();
        IReadOnlyList<ClientFilter3> GetClientFilter3();
        IReadOnlyList<Education> GetEducationLevels();
        IReadOnlyList<MemberFilter1> GetMemberFilter1();
        IReadOnlyList<MemberFilter2> GetMemberFilter2();
        IReadOnlyList<GroupFilter1> GetGroupFilter1();
        IReadOnlyList<GroupFilter2> GetGroupFilter2();
        IReadOnlyList<BusinessFilter1> GetBusinessFilter1();
        IReadOnlyList<BusinessFilter2> GetBusinessFilter2();
        IReadOnlyList<SeriesNumbers> GetSeries(long branchId);
        IReadOnlyList<AccountReference> GetDefaultReferences();
        IReadOnlyList<SystemConfiguration> GetStatisticsParameters(StatisticParameters parameter);
        IReadOnlyList<SystemConfiguration> GetClientParameters(long? branchId = null);
        IReadOnlyList<SystemConfiguration> GetAccountingParameters(bool multiBranch = false, ChartType chartType = ChartType.UsUk, long? branchId = null);
        (List<LedgerAccountHeader>, AccountsChart) GetChartOfAccounts(ChartTemplate template = ChartTemplate.Default);

        #endregion

        #region Products Configurations
        IReadOnlyList<ProductType> GetProductTypes();
        IReadOnlyList<Product> GetProducts(long type, string series);
        IReadOnlyList<ProductConfiguration> GetSavingParameters(long productId);

        #endregion

    }
}
