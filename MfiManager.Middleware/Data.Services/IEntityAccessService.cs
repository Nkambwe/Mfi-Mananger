namespace MfiManager.Middleware.Data.Services {
    public interface IEntityAccessService
    {
        bool CanRead(long branchId, string entityName);
    }


}
