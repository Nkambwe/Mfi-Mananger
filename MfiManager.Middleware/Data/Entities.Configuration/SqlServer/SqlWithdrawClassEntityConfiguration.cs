using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlWithdrawClassEntityConfiguration {

        public static void Configure(EntityTypeBuilder<WithdrawClass> builder) {
            builder.ToTable("TBL_MFI_WITHDRAW_CLASS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Minimum).HasColumnName("min_amount").HasPrecision(9,2);
            builder.Property(p => p.Maximum).HasColumnName("max_amount").HasPrecision(9,2);
            builder.Property(p => p.Charge).HasColumnName("charge").HasPrecision(9,2);
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.Percentage).HasColumnName("percentage");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.WithdrawClasses).HasForeignKey(mp => mp.ProductId);
        }
    }

}
