using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlErrorEntityConfiguration {
        public static void Configure(EntityTypeBuilder<SystemError> builder) {
            builder.ToTable("TBL_MFI_ERROR");
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("id");
            builder.Property(f => f.CompanyId).HasColumnName("company_id").IsRequired();
            builder.Property(f => f.Message).HasColumnName("error_message").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(f => f.Source).HasColumnName("error_source").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(f => f.Severity).HasColumnName("error_severity").HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(f => f.StackTrace).HasColumnName("stack_trace").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(f => f.Status).HasColumnName("error_status").HasColumnType("NVARCHAR(50)").IsRequired(false);
            builder.Property(f => f.IsDeleted).HasColumnName("is_deleted");
            builder.Property(f => f.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(f => f.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(f => f.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(f => f.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);

            builder.HasOne(f => f.Company).WithMany(c => c.SystemErrors).HasForeignKey(f => f.CompanyId);
        }
    }


}
