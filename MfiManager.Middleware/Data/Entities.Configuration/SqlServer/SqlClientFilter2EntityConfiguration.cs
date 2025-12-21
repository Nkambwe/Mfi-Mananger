using MfiManager.Middleware.Data.Entities.Customer.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClientFilter2EntityConfiguration {

        public static void Configure(EntityTypeBuilder<ClientFilter2> builder) {
            builder.ToTable("TBL_MFI_CLIENT_FILTER_2");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("filter_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("filter_notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.Individuals).WithOne(o => o.Filter2).HasForeignKey(mp => mp.Filter2Id);
            builder.HasMany(m => m.Members).WithOne(o => o.ClientFilter2).HasForeignKey(mp => mp.Filter2Id);
            builder.HasMany(m => m.Groups).WithOne(o => o.ClientFilter2).HasForeignKey(mp => mp.Filter2Id);
            builder.HasMany(m => m.Businesses).WithOne(o => o.ClientFilter2).HasForeignKey(mp => mp.Filter2Id);
        }
    }

}
