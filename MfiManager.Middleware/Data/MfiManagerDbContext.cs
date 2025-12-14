using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using MfiManager.Middleware.Data.Entities.Accounts.Fees;
using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Configuration.Oracle;
using MfiManager.Middleware.Data.Entities.Configuration.PostgreSql;
using MfiManager.Middleware.Data.Entities.Configuration.SqlServer;
using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Data.Entities.System.Configurations;
using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Data {

    public class MfiManagerDbContext(DbContextOptions<MfiManagerDbContext> options) : DbContext(options) {
        public DbSet<Company> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentUnit> DepartmentUnits { get; set; }
        public DbSet<SystemError> SystemErrors { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<LoginAttempt> Attempts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserActivityLog> ActivityLogs { get; set; }
        public DbSet<UserQuickAction> QuickActions { get; set; }
        public DbSet<MfiEntity> SystemEntities { get; set; }
        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            var provider = Database.ProviderName ?? string.Empty;
            if (provider.Contains("SqlServer", StringComparison.OrdinalIgnoreCase))
                ConfigureSqlServer(modelBuilder);
            else if (provider.Contains("Npgsql", StringComparison.OrdinalIgnoreCase))
                ConfigurePostgreSql(modelBuilder);
            else if (provider.Contains("Oracle", StringComparison.OrdinalIgnoreCase))
                ConfigureOracle(modelBuilder);
        }

        private static void ConfigureOracle(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("MFI_APP");
            modelBuilder.HasSequence<long>("ACTIVITYLOG_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("BRANCH_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("COMPANY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("DEPARTMENT_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("DEPARTMENTUNIT_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ENTITY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ERROR_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ACTION_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ROLE_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ROLEGROUP_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("CONFIG_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ACTIVITY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("USER_SEQ").StartsAt(1).IncrementsBy(1);

            OracleActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            OracleBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            OracleCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            OracleDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            OracleDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            OracleEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            OracleErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            OracleLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            OracleQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            OracleRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            OracleRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            OracleSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            OracleUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            OracleUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());
        }

        private static void ConfigurePostgreSql(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasSequence<long>("activitylog_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("branch_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("company_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("department_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("departmentunit_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("mfientity_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Systemerror_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("loginattempt_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("quickaction_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("role_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("rolegroup_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Sysconfig_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("activity_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Systemuser_seq").StartsAt(1).IncrementsBy(1);

            PsqlActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            PsqlBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            PsqlCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            PsqlDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            PsqlDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            PsqlEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            PsqlErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            PsqlLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            PsqlQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            PsqlRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            PsqlRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            PsqlSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            PsqlUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            PsqlUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());

        }

        private static void ConfigureSqlServer(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
            SqlCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            SqlBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            SqlDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            SqlDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            SqlUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());
            SqlRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            SqlRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            SqlLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            SqlQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            SqlUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            SqlActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            SqlEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            SqlSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            SqlErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            SqlPaymentTermEntityConfiguration.Configure(modelBuilder.Entity<PaymentTerm>());
            SqlPaymentDefaultEntityConfiguration.Configure(modelBuilder.Entity<PaymentDefault>());
            SqlCurrencyEntityConfiguration.Configure(modelBuilder.Entity<Currency>());
            SqlDenominationEntityConfiguration.Configure(modelBuilder.Entity<Denomination>());
            SqlExchangeRateEntityConfiguration.Configure(modelBuilder.Entity<ExchangeRate>());
            SqlBankAccountEntityConfiguration.Configure(modelBuilder.Entity<BankAccount>());
            SqlBankAccountCurrenciesEntityConfiguration.Configure(modelBuilder.Entity<BankAccountCurrencies>());
            SqlSupplierInfoEntityConfiguration.Configure(modelBuilder.Entity<SupplierInfo>());
            SqlSupplierBankAccountEntityConfiguration.Configure(modelBuilder.Entity<SupplierBankAccount>());
            SqlSuppliedBranchEntityConfiguration.Configure(modelBuilder.Entity<SuppliedBranch>());
            SqlHeldContractEntityConfiguration.Configure(modelBuilder.Entity<HeldContract>());
            SqlChequeBookEntityConfiguration.Configure(modelBuilder.Entity<ChequeBook>());
            SqlChequeEntityConfiguration.Configure(modelBuilder.Entity<Cheque>());
            SqlTraderInfoEntityConfiguration.Configure(modelBuilder.Entity<Trader>());
            SqlAccountReferenceEntityConfiguration.Configure(modelBuilder.Entity<AccountReference>());
            SqlAccountReferenceValueEntityConfiguration.Configure(modelBuilder.Entity<AccountReferenceValue>());
            SqlBranchReferenceEntityConfiguration.Configure(modelBuilder.Entity<BranchReference>());
            SqlTraderReferenceEntityConfiguration.Configure(modelBuilder.Entity<TraderReference>());
            SqlSupplierReferenceEntityConfiguration.Configure(modelBuilder.Entity<SupplierReference>());
            SqlLedgerReferencesEntityConfiguration.Configure(modelBuilder.Entity<LedgerReferences>());
            SqlDeliveryTermsEntityConfiguration.Configure(modelBuilder.Entity<DeliveryTerms>());
            SqlDeliveryModeEntityConfiguration.Configure(modelBuilder.Entity<DeliveryMode>());
            SqlContactAddressEntityConfiguration.Configure(modelBuilder.Entity<ContactAddress>());
            SqlBusinessContactEntityConfiguration.Configure(modelBuilder.Entity<BusinessContact>());
            SqlPriceGroupEntityConfiguration.Configure(modelBuilder.Entity<PriceGroup>());
            SqlDiscountGroupEntityConfiguration.Configure(modelBuilder.Entity<DiscountGroup>());
            SqlSupplierGroupEntityConfiguration.Configure(modelBuilder.Entity<SupplierGroup>());
            SqlTraderGroupEntityConfiguration.Configure(modelBuilder.Entity<TraderGroup>());
            SqlSupplierItemGroupEntityConfiguration.Configure(modelBuilder.Entity<SupplierItemGroup>());
            SqlSalesOrderClassificationEntityConfiguration.Configure(modelBuilder.Entity<SalesOrderClassification>());
            SqlSalesOrderDefaultEntityConfiguration.Configure(modelBuilder.Entity<SalesOrderDefault>());
            SqlPurchaseOrderClassificationEntityConfiguration.Configure(modelBuilder.Entity<PurchaseOrderClassification>());
            SqlPurchaseOrderDefaultEntityConfiguration.Configure(modelBuilder.Entity<PurchaseOrderDefault>());
            SqlTraderBankAccountEntityConfiguration.Configure(modelBuilder.Entity<TraderBankAccount>());
            SqlTaxEntityConfiguration.Configure(modelBuilder.Entity<Tax>());
            SqlTaxGroupEntityConfiguration.Configure(modelBuilder.Entity<TaxGroup>());
            SqlTaxableItemEntityConfiguration.Configure(modelBuilder.Entity<TaxableItem>());
            SqlTaxGroupEntityConfiguration.Configure(modelBuilder.Entity<TaxGroup>());
            SqlTraderTaxEntityConfiguration.Configure(modelBuilder.Entity<TraderTax>());
            SqlSupplierTaxEntityConfiguration.Configure(modelBuilder.Entity<SupplierTax>());
            SqlProductTaxGroupEntityConfiguration.Configure(modelBuilder.Entity<ProductTaxGroup>());
            SqlProductEntityConfiguration.Configure(modelBuilder.Entity<Product>());
            SqlProductTypeEntityConfiguration.Configure(modelBuilder.Entity<ProductType>());
            SqlProductConfigurationEntityConfiguration.Configure(modelBuilder.Entity<ProductConfiguration>());
           
            SqlJournalTypeTaxGroupEntityConfiguration.Configure(modelBuilder.Entity<JournalTypeTaxGroup>());
            SqlChargeEntityConfiguration.Configure(modelBuilder.Entity<Charge>());
            SqlChargeItemChargeEntityConfiguration.Configure(modelBuilder.Entity<ChargeItemCharge>());
            SqlChargeItemEntityConfiguration.Configure(modelBuilder.Entity<ChargeItem>());
            SqlChargeStageEntityConfiguration.Configure(modelBuilder.Entity<ChargeStage>());
            SqlChargeGroupEntityConfiguration.Configure(modelBuilder.Entity<ChargeGroup>());
            SqlChargeGroupItemEntityConfiguration.Configure(modelBuilder.Entity<ChargeGroupItem>());
            SqlCardEntityConfiguration.Configure(modelBuilder.Entity<Card>());
            SqlCardLedgerEntityConfiguration.Configure(modelBuilder.Entity<CardLedger>());
            SqlLedgerAccountEntityConfiguration.Configure(modelBuilder.Entity<LedgerAccount>());
            SqlConfigurationParameterEntityConfiguration.Configure(modelBuilder.Entity<ConfigurationParameter>());

            SqlBusinessSectorEntityConfiguration.Configure(modelBuilder.Entity<BusinessSector>());
            SqlDonorEntityConfiguration.Configure(modelBuilder.Entity<Donor>());
            SqlBranchRevolvingFundEntityConfiguration.Configure(modelBuilder.Entity<BranchRevolvingFund>());

            SqlChargeableFeeEntityConfiguration.Configure(modelBuilder.Entity<ChargeableFee>());
            SqlSavingFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<SavingFeeLedger>());
            SqlLoanFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<LoanFeeLedger>());
            SqlInsuranceFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<InsuranceFeeLedger>());
            SqlShareFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<ShareFeeLedger>());
            SqlRegistrationFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<RegistrationFeeLedger>());
            SqlTimedepositFeeLedgerEntityConfiguration.Configure(modelBuilder.Entity<TimedepositFeeLedger>());
            
            SqlLoanProductEntityConfiguration.Configure(modelBuilder.Entity<LoanProduct>());
            SqlVariableRateEntityConfiguration.Configure(modelBuilder.Entity<VariableRate>());
            SqlRevolvingFundEntityConfiguration.Configure(modelBuilder.Entity<RevolvingFund>());
            SqlLoanPenaltyEntityConfiguration.Configure(modelBuilder.Entity<LoanPenalty>()); 
            SqlLoanAgingClassEntityConfiguration.Configure(modelBuilder.Entity<LoanAgingClass>()); 
            SqlLoanFeePaymentLevelEntityConfiguration.Configure(modelBuilder.Entity<LoanFeePaymentLevel>());

            SqlSavingProductEntityConfiguration.Configure(modelBuilder.Entity<SavingProduct>());
            SqlWithdrawClassEntityConfiguration.Configure(modelBuilder.Entity<WithdrawClass>());
           
            SqlShareProductEntityConfiguration.Configure(modelBuilder.Entity<ShareProduct>());
            SqlShareValueEntityConfiguration.Configure(modelBuilder.Entity<ShareValue>());
            SqlShareAccountEntityConfiguration.Configure(modelBuilder.Entity<ShareAccount>());
            SqlShareLedgerEntityConfiguration.Configure(modelBuilder.Entity<ShareTransactionLedger>());
            SqlDividendLedgerEntityConfiguration.Configure(modelBuilder.Entity<DividendTransactionLedger>());
            SqlModifiedShareLedgerEntityConfiguration.Configure(modelBuilder.Entity<ModifiedShareTransactionLedger>());

            SqlInsuranceProductEntityConfiguration.Configure(modelBuilder.Entity<InsuranceProduct>());
            SqlInsuranceProductProviderEntityConfiguration.Configure(modelBuilder.Entity<InsuranceProductProvider>());
            SqlInsuranceProviderEntityConfiguration.Configure(modelBuilder.Entity<Provider>());
            SqlInsurancePolicyEntityConfiguration.Configure(modelBuilder.Entity<Policy>());
            SqlInsuranceClaimEntityConfiguration.Configure(modelBuilder.Entity<InsuranceClaim>());
            SqlClaimantEntityConfiguration.Configure(modelBuilder.Entity<Claimant>());
            SqlClaimReceiptEntityConfiguration.Configure(modelBuilder.Entity<ClaimReceipt>());
            SqlPremiumPaymentLedgerEntityConfiguration.Configure(modelBuilder.Entity<PremiumPaymentLedger>());
            SqlClaimPaymentLedgerEntityConfiguration.Configure(modelBuilder.Entity<ClaimPaymentLedger>());
            SqlCoverageEntityConfiguration.Configure(modelBuilder.Entity<Coverage>());
            SqlCoverageItemEntityConfiguration.Configure(modelBuilder.Entity<CoverageItem>());
            SqlPolicyInsuranceBeneficiaryEntityConfiguration.Configure(modelBuilder.Entity<PolicyInsuranceBeneficiary>());
            SqlInsuranceBeneficiaryEntityConfiguration.Configure(modelBuilder.Entity<InsuranceBeneficiary>());

            SqlTimedepositProductEntityConfiguration.Configure(modelBuilder.Entity<TimedepositProduct>());
            SqlTimedepositRateEntityConfiguration.Configure(modelBuilder.Entity<TimedepositRate>());
            SqlTimedepositAccountEntityConfiguration.Configure(modelBuilder.Entity<TimedepositAccount>());
            SqlModifiedTimedepositAccountEntityConfiguration.Configure(modelBuilder.Entity<ModifiedTimedepositAccount>());
        }
    }

}
