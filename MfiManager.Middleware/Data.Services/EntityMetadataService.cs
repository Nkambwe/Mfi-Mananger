using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Http.Responses;
using System.Reflection;

namespace MfiManager.Middleware.Data.Services {
    public sealed class EntityMetadataService(IEntityResolver resolver) : IEntityMetadataService {
        private readonly IEntityResolver _resolver = resolver;

        public IEnumerable<EncryptableFieldResponse> GetEncryptableFields(string entityName) {
            var type = _resolver.Resolve(entityName);

            return type.GetProperties()
                .Where(p => p.GetCustomAttribute<EncryptableAttribute>() != null)
                .Select(p => new EncryptableFieldResponse {
                    EntityName = entityName,
                    FieldName = p.Name,
                    DisplayName = p.GetCustomAttribute<EncryptableAttribute>()!.DisplayName
                });
        }
    }

}
