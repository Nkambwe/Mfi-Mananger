using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanAmountRangeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanAmountClassRange> builder) {
            builder.ToTable("TBL_MFI_LOAN_AMOUNT_CLASSRANGE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.MinimumAmount).HasColumnName("min_amount").HasPrecision(9,2);
            builder.Property(p => p.MaximumAmount).HasColumnName("max_amount").HasPrecision(9,2);
            builder.Property(p => p.LoanClassId).HasColumnName("lnr_class_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.LoanAmountClass).WithMany(e => e.LoanClassRanges).HasForeignKey(e => e.LoanClassId);
        }
    }
}
