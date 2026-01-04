using System.Reflection;

namespace MfiManager.Middleware.Data.Helpers {
    public sealed class EntityResolver : IEntityResolver {
        private readonly Dictionary<string, Type> _entities;

        public EntityResolver() {
            _entities = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.Namespace != null &&
                    t.Namespace.StartsWith("MfiManager.Middleware.Data.Entities")) .ToDictionary(t => t.Name,t => t, StringComparer.OrdinalIgnoreCase);
        }

        public Type Resolve(string entityName) {
            if (!_entities.TryGetValue(entityName, out var type))
                throw new InvalidOperationException($"Unknown entity: {entityName}");

            return type;
        }

        public IReadOnlyCollection<Type> GetAllEntities()
            => _entities.Values;
    }

}
