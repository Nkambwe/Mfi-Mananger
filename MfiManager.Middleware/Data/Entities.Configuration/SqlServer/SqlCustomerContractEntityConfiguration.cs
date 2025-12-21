using MfiManager.Middleware.Data.Entities.Customer.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCustomerContractEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CustomerContract> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_CONTRACT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Series).HasColumnName("contact_series").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.FileUrl).HasColumnName("file_url").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.FileType).HasColumnName("file_type");
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.BusinessId).HasColumnName("business_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithMany(e => e.CustomerContracts).HasForeignKey(e => e.PersonId);
            builder.HasOne(p => p.Member).WithMany(e => e.CustomerContracts).HasForeignKey(e => e.MemberId);
            builder.HasOne(p => p.Business).WithMany(e => e.CustomerContracts).HasForeignKey(e => e.BusinessId);
            builder.HasOne(p => p.Group).WithMany(e => e.CustomerContracts).HasForeignKey(e => e.GroupId);
        }
    }
}
