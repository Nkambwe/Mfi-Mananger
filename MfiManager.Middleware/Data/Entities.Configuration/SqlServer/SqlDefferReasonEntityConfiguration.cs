using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDefferReasonEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<DefferReason> builder) {
            builder.ToTable("TBL_MFI_LOAN_DIFFERED_REASON");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Reason).HasColumnName("reason").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(bc => bc.DefferedLoans).WithOne(p => p.Reason).HasForeignKey(bc => bc.ReasonId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
