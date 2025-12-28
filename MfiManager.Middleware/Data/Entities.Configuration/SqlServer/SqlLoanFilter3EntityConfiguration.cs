using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanFilter3EntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanFilter3> builder) {
            builder.ToTable("TBL_MFI_LOAN_CUSTOM_FILTER_3");
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
            builder.HasMany(bc => bc.IndividualLoans).WithOne(p => p.Filter3).HasForeignKey(bc => bc.Filter3Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.BusinessLoans).WithOne(p => p.Filter3).HasForeignKey(bc => bc.Filter3Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.GroupLoans).WithOne(p => p.Filter3).HasForeignKey(bc => bc.Filter3Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
