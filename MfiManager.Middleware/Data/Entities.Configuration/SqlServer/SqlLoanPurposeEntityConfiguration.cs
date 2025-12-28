using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanPurposeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanPurpose> builder) {
            builder.ToTable("TBL_MFI_LOAN_PURPOSE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.IndividualLoans).WithOne(e => e.Purpose).HasForeignKey(e => e.PurposeId);
            builder.HasMany(p => p.BusinessLoans).WithOne(e => e.Purpose).HasForeignKey(e => e.PurposeId);
            builder.HasMany(p => p.GroupLoans).WithOne(e => e.Purpose).HasForeignKey(e => e.PurposeId);
        }
    }
}
