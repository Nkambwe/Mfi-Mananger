using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Security {
   public sealed class EncryptionConfig(IEnumerable<EncryptionSetting> settings) {
        private readonly HashSet<string> _encryptedFields = settings
                .Where(s => s.IsEncrypted)
                .Select(s => $"{s.EntityName}.{s.FieldName}")
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        public bool IsEncrypted(string entityName, string fieldName)
            => _encryptedFields.Contains($"{entityName}.{fieldName}");
    }

}
