using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingAccount> builder) {
            builder.ToTable("TBL_MFI_SAVING_ACCOUNT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.AccountNumber).HasColumnName("account_number").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Opened).HasColumnName("openned_on");
            builder.Property(p => p.AccountType).HasColumnName("account_type");
            builder.Property(p => p.Signatures).HasColumnName("signatures");
            builder.Property(p => p.Dormant).HasColumnName("is_dormant");
            builder.Property(p => p.Frozen).HasColumnName("is_frozen");
            builder.Property(p => p.ClosedOn).HasColumnName("closed_on").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.IndividualId).HasColumnName("individual_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Branch).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.BranchId);
            builder.HasOne(p => p.Product).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.ProductId);
            builder.HasOne(p => p.Individual).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.IndividualId);
            builder.HasOne(p => p.Member).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Group).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.GroupId);
            builder.HasOne(p => p.Business).WithMany(e => e.SavingAccounts).HasForeignKey(e => e.BusinessId);
            builder.HasMany(p => p.SavingPartners).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.Freezes).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.Signatories).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.SavingTransactions).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.InterestEarnings).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.StandingOrders).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.Overdrafts).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.GroupRepaymentTransactions).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.RepaymentTransactions).WithOne(e => e.SavingAccount).HasForeignKey(e => e.SavingAccountId);
        }
    }

}
