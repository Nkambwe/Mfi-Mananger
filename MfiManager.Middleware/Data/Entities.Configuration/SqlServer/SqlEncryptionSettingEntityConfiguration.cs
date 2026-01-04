using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlEncryptionSettingEntityConfiguration {

        public static void Configure(EntityTypeBuilder<EncryptionSetting> builder) {
            builder.ToTable("TBL_MFI_ENTITY_ENCRYPTION");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.EntityName).HasColumnName("entity_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.FieldName).HasColumnName("field_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.IsEncrypted).HasColumnName("is_encryted");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id").IsRequired(false);
            builder.Property(p => p.CompanyId).HasColumnName("company_id");
            builder.HasOne(m => m.Branch).WithMany(o => o.EncryptionSettings).HasForeignKey(mp => mp.BranchId);
            builder.HasOne(m => m.Company).WithMany(o => o.EncryptionSettings).HasForeignKey(mp => mp.CompanyId);
        }
    }

}
