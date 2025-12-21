using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTitleEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Title> builder) {
            builder.ToTable("TBL_MFI_TITLE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Name).HasColumnName("title_descr").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted");
            builder.Property(c => c.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(c => c.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(c => c.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(c => c.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(c => c.Individuals).WithOne(e => e.Title).HasForeignKey(e => e.TitleId);
            builder.HasMany(c => c.Members).WithOne(s => s.Title).HasForeignKey(s => s.TitleId);
            builder.HasMany(c => c.Guarantors).WithOne(s => s.Title).HasForeignKey(s => s.TitleId);
            builder.HasMany(c => c.IndividualArchives).WithOne(s => s.Title).HasForeignKey(s => s.TitleId);
        }
    }
}
