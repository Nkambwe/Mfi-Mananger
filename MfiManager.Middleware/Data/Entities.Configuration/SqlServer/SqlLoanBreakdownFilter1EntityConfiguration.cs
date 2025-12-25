using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanBreakdownFilter1EntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanBreakdownFilter1> builder) {
            builder.ToTable("TBL_MFI_LOANBREAKDOWN_CUSTOM_FILTER_1");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(bc => bc.LoanBreakDowns).WithOne(p => p.LoanBreakdownFilter1).HasForeignKey(bc => bc.LoanBreakdownFilter1Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
