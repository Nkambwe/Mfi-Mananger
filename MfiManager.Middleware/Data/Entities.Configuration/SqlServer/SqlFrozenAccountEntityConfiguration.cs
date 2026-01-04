using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlFrozenAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<FrozenAccount> builder) {
            builder.ToTable("TBL_MFI_SAVING_ACCOUNT_FROZEN");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FrozenOn).HasColumnName("frozen_on").IsRequired();
            builder.Property(p => p.UnFrozenOn).HasColumnName("unfrozen_on").IsRequired(false);
            builder.Property(p => p.FrozenBy).HasColumnName("frozen_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.SavingAccountId).HasColumnName("sav_account_id");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.Freezes).HasForeignKey(e => e.SavingAccountId);
        }
    }

}
