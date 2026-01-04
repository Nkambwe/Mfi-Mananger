using MfiManager.Middleware.Data.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MfiManager.Middleware.Security {

    public class EncryptionInterceptor(IEncryptionService crypto, IEncryptionConfigProvider provider, IRequestContext context) : SaveChangesInterceptor {
        private readonly IEncryptionService _crypto = crypto;
        private readonly IEncryptionConfigProvider _provider = provider;
        private readonly IRequestContext _context = context;

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default) {
            var config = _provider.GetConfig(_context.CompanyId,_context.BranchId);

            foreach (var entry in eventData.Context.ChangeTracker.Entries()) {
                EncryptEntity(entry, config);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void EncryptEntity(EntityEntry entry, EncryptionConfig config) {
            var entityName = entry.Entity.GetType().Name;
            foreach (var prop in entry.Properties) {
                if (!config.IsEncrypted(entityName, prop.Metadata.Name))
                    continue;

                if (prop.CurrentValue is string value && !string.IsNullOrEmpty(value)) {
                    prop.CurrentValue = _crypto.Encrypt(value);
                }
            }
        }
    }

}
