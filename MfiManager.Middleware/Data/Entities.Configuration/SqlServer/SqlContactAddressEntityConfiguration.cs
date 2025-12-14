using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlContactAddressEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ContactAddress> builder) {
            builder.ToTable("TBL_MFI_CPNTACT_ADDRESS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Details).HasColumnName("contact_details").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.For).HasColumnName("contact_type").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.IsPrimary).HasColumnName("primary_address");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Vendor).WithMany(t => t.Addresses).HasForeignKey(t => t.VendorId);
            builder.HasOne(p => p.Supplier).WithMany(s => s.Addresses).HasForeignKey(s => s.SupplierId);
        }
    }
}
