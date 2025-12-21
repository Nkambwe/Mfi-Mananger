using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlReasonEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Reason> builder) {
             builder.ToTable("TBL_MFI_REASON");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.SeriesNumber).HasColumnName("series_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(250)").IsRequired();
             builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.ReasonCategory).WithMany(o => o.Reasons).HasForeignKey(mp => mp.ReasonCategoryId);
             builder.HasMany(m => m.Traders).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
             builder.HasMany(m => m.ExitedClients).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
             builder.HasMany(m => m.HeldContracts).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
             builder.HasMany(m => m.Journals).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
             builder.HasMany(m => m.Vouchers).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
             builder.HasMany(m => m.BlackListedCustomers).WithOne(o => o.Reason).HasForeignKey(mp => mp.ReasonId);
        }
    }
}
