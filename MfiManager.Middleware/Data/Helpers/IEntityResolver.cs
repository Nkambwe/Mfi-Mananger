namespace MfiManager.Middleware.Data.Helpers {
    public interface IEntityResolver
    {
        Type Resolve(string entityName);
        IReadOnlyCollection<Type> GetAllEntities();
    }


}
