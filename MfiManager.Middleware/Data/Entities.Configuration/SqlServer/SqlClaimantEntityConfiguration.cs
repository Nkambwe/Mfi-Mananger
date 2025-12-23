using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClaimantEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Claimant> builder) {
            builder.ToTable("TBL_MFI_CLAIMANT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClaimantName).HasColumnName("claimant_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.Address).HasColumnName("physical_address").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(p => p.ContactPerson).HasColumnName("contact_person").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Telephone).HasColumnName("phone_number").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Mobile).HasColumnName("mobile_number").HasColumnType("NVARCHAR(20)").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("email_address").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.HasMany(m => m.Claims).WithOne(o => o.Claimant).HasForeignKey(mp => mp.ClaimantId);
            builder.HasMany(m => m.Receipts).WithOne(o => o.Claimant).HasForeignKey(mp => mp.ClaimantId);
        }
    }
}
