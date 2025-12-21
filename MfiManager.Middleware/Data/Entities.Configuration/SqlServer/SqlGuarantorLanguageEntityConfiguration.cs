using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlGuarantorLanguageEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<GuarantorLanguage> builder) {
            builder.ToTable("TBL_MFI_GUARANTOR_LANGUAGE");
            builder.HasKey(bc => new { bc.GuarantorId, bc.LanguageId });
            builder.Property(bc => bc.GuarantorId).HasColumnName("guarantor_id").IsRequired();
            builder.Property(bc => bc.LanguageId).HasColumnName("language_id").IsRequired();
            builder.HasOne(bc => bc.Guarantor).WithMany(p => p.Languages).HasForeignKey(bc => bc.LanguageId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Language).WithMany(g => g.Guarantors).HasForeignKey(bc => bc.GuarantorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
