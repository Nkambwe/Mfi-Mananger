using MfiManager.Middleware.Security;

namespace MfiManager.Middleware.Data.Services {

    public sealed class EncryptionConfigProvider(MfiManagerDbContext db) : IEncryptionConfigProvider
    {
        private readonly MfiManagerDbContext _db = db;

            public EncryptionConfig GetConfig(long companyId, long branchId)
            {
                var settings = _db.EncryptionSettings
                    .Where(s =>
                        s.CompanyId == companyId &&
                        (s.BranchId == null || s.BranchId == branchId))
                    .ToList();

                var effective = settings
                    .GroupBy(s => new { s.EntityName, s.FieldName })
                    .Select(g => g.OrderByDescending(x => x.BranchId.HasValue).First());

                return new EncryptionConfig(effective);
            }
    }


}
