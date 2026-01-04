using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSavingAccountSignatoryEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SavingAccountSignatory> builder) {
            builder.ToTable("TBL_MFI_SAVING_ACCOUNT_SIGNATORY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FirstSignatory).HasColumnName("first_signatory_code").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.FirstSignature).HasColumnName("first_signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.FirstCanSignAlone).HasColumnName("first_can_signAlone");
            builder.Property(p => p.SecondSignatory).HasColumnName("second_signatory_code").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.SecondSignature).HasColumnName("second_signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.SecondCanSignAlone).HasColumnName("second_can_signAlone");
            builder.Property(p => p.ThirdSignatory).HasColumnName("third_signatory_code").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.ThirdSignature).HasColumnName("third_signature").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ThirdCanSignAlone).HasColumnName("third_can_signAlone");
            builder.Property(p => p.SavingAccountId).HasColumnName("sav_account_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.Signatories).HasForeignKey(e => e.SavingAccountId);
        }
    }

}
