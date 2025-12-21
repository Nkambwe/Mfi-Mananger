using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCustomerContactEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CustomerContact> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_CONTACT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("contact_series").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.ContactName).HasColumnName("contact_name").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Telephone).HasColumnName("telephone").HasColumnType("NVARCHAR(20)");
            builder.Property(p => p.Mobile).HasColumnName("mobile").HasColumnType("NVARCHAR(20)");
            builder.Property(p => p.Email).HasColumnName("email").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Relationship).HasColumnName("relationship").HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.CustomerContacts).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.CustomerContacts).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Business).WithMany(e => e.CustomerContacts).HasForeignKey(e => e.BusinessId);
        }
    }
}
