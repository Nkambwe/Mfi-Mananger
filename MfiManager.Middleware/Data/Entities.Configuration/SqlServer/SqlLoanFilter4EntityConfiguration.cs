using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanFilter4EntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanFilter4> builder) {
            builder.ToTable("TBL_MFI_LOAN_CUSTOM_FILTER_4");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Activity).HasColumnName("activity").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_account_id");
            builder.HasOne(bc => bc.LedgerAccount).WithMany(p => p.LoanFilter4s).HasForeignKey(bc => bc.LedgerAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.Loans).WithOne(p => p.Filter4).HasForeignKey(bc => bc.Filter4Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
