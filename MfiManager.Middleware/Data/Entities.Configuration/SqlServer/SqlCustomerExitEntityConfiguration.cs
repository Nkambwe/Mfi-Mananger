using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCustomerExitEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CustomerExit> builder) {
            builder.ToTable("TBL_MFI_CUSTOMER_EXIT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ExitedOn).HasColumnName("exited_on");
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Individual).WithOne(e => e.CustomerExit).HasForeignKey<CustomerExit>(e => e.PersonId).IsRequired(false);
            builder.HasOne(p => p.Member).WithOne(e => e.CustomerExit).HasForeignKey<CustomerExit>(e => e.MemberId).IsRequired(false);
            builder.HasOne(p => p.Group).WithOne(e => e.CustomerExit).HasForeignKey<CustomerExit>(e => e.GroupId).IsRequired(false);
            builder.HasOne(p => p.Business).WithOne(e => e.CustomerExit).HasForeignKey<CustomerExit>(e => e.BusinessId).IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(e => e.CustomerExits).HasForeignKey(e => e.GroupId);
        }
    }
}
