using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEventntityConfiguration {
        public static void Configure(EntityTypeBuilder<Event> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_EVENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Description).HasColumnName("claimant_number").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.EventDate).HasColumnName("event_date");
            builder.Property(p => p.AdminissionDate).HasColumnName("admission_date").IsRequired(false);
            builder.Property(p => p.DischargeDate).HasColumnName("discharge_date").IsRequired(false);
            builder.Property(p => p.PolicyId).HasColumnName("policy_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.HasOne(p => p.Policy).WithMany(o => o.Events).HasForeignKey(mp => mp.PolicyId);
            builder.HasMany(p => p.Files).WithOne(o => o.Event).HasForeignKey(mp => mp.EventId);
            
        }
    }
}
