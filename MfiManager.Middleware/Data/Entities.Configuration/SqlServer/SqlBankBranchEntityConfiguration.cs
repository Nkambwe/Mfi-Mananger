using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBankBranchEntityConfiguration {
        public static void Configure(EntityTypeBuilder<BankBranch> builder) {
             builder.ToTable("TBL_MFI_BANK_BRANCH");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.BranchCode).HasColumnName("branch_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.BranchName).HasColumnName("branch_name").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.BranchAddress).HasColumnName("branch_address").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.BranchContact).HasColumnName("contact_name").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.ContactDesignation).HasColumnName("contact_designation").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.PrimaryLine).HasColumnName("primary_line").HasColumnType("NVARCHAR(25)").IsRequired(false);
             builder.Property(p => p.SecondaryLine).HasColumnName("secondary_line").HasColumnType("NVARCHAR(25)").IsRequired();
             builder.Property(p => p.ContactEmail).HasColumnName("contact_email").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.BranchFax).HasColumnName("branch_fax").HasColumnType("NVARCHAR(25)").IsRequired();
             builder.Property(p => p.BankId).HasColumnName("bank_id");
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.Bank).WithMany(o => o.Branches).HasForeignKey(mp => mp.BankId);
             builder.HasMany(m => m.Accounts).WithOne(o => o.BankBranch).HasForeignKey(mp => mp.BankBranchId);
        }
    }
}
