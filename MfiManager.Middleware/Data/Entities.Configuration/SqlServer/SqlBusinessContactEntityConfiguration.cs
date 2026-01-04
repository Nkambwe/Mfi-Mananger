using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBusinessContactEntityConfiguration {

        public static void Configure(EntityTypeBuilder<BusinessContact> builder) {
            builder.ToTable("TBL_MFI_BUSINESS_CONTACT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ContactPerson).HasColumnName("contact_person").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Type).HasColumnName("contact_type").IsRequired();
            builder.Property(p => p.PhoneOrEmail).HasColumnName("contact").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsPrimary).HasColumnName("is_primary").IsRequired();
            builder.Property(p => p.VendorId).HasColumnName("vendor_id").IsRequired(false);
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Vendor).WithMany(c => c.Contacts).HasForeignKey(bc => bc.VendorId);
            builder.HasOne(u => u.Supplier).WithMany(s => s.Contacts).HasForeignKey(bc => bc.SupplierId);
        }
    }
}
