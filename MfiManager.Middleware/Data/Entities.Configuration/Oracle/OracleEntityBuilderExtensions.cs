using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.Oracle {
    public static class OracleEntityBuilderExtensions {
        public static void ConfigureAuditFields<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class {
            builder.Property("IsDeleted").IsRequired();
            builder.Property("CreatedOn").IsRequired();
            builder.Property("CreatedBy").HasMaxLength(100).IsRequired();
            builder.Property("ModifiedOn").IsRequired(false);
            builder.Property("ModifiedBy").HasMaxLength(100).IsRequired(false);
        }
    }
}
