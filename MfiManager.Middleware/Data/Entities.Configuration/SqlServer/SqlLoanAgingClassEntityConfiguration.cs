using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanAgingClassEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanAgingClass> builder) {
            builder.ToTable("TBL_MFI_LOAN_AGING_CLASS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Class).HasColumnName("age_class").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.LowerClass).HasColumnName("lower_class").HasPrecision(9,2);
            builder.Property(p => p.UpperClass).HasColumnName("upper_class").HasPrecision(9,2);
            builder.Property(p => p.Active).HasColumnName("is_active");
            builder.Property(p => p.PersonalLoanLedger).HasColumnName("personal_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.GroupLoanLedger).HasColumnName("group_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BusinessLoanLedger).HasColumnName("business_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.AgingClasses).HasForeignKey(mp => mp.ProductId);
        }
    }
}
