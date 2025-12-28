using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanAmountClassEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanAmountClass> builder) {
            builder.ToTable("TBL_MFI_LOAN_AMOUNT_CLASS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClassName).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.TargetGroup).HasColumnName("target_group");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Product).WithMany(e => e.LoanAmountClasses).HasForeignKey(e => e.ProductId);
            builder.HasMany(p => p.LoanClassRanges).WithOne(e => e.LoanAmountClass).HasForeignKey(e => e.LoanClassId);
        }
    }
}
