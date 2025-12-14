using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlAccountReferenceEntityConfiguration {

        public static void Configure(EntityTypeBuilder<AccountReference> builder) {
            builder.ToTable("TBL_MFI_ACC_REFERENCE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("ref_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Series).HasColumnName("ref_series").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("ref_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Active).HasColumnName("is_active");
            builder.Property(p => p.IsSystem).HasColumnName("is_sysref");
            builder.Property(p => p.Notes).HasColumnName("ref_notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.LedgerAccounts).WithOne(o => o.Reference).HasForeignKey(mp => mp.ReferenceId);
            builder.HasMany(m => m.ReferenceValues).WithOne(o => o.AccountReference).HasForeignKey(mp => mp.ReferenceId);
        }
    }
}
