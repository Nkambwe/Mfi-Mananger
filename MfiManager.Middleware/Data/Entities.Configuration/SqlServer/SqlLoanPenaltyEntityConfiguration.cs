using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanPenaltyEntityConfiguration {

        public static void Configure(EntityTypeBuilder<LoanPenalty> builder) {
            builder.ToTable("TBL_MFI_LOAN_PENALTY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Minimum).HasColumnName("min_penalty").HasPrecision(9,2);
            builder.Property(p => p.Maximum).HasColumnName("max_penalty").HasPrecision(9,2);
            builder.Property(p => p.Penalty).HasColumnName("penalty").HasPrecision(9,2);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.Penalties).HasForeignKey(mp => mp.ProductId);
        }
    }
}
