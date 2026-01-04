namespace MfiManager.Middleware.Data.Services {
    public class EntityAccessService(MfiManagerDbContext db) : IEntityAccessService
    {
        private readonly MfiManagerDbContext _db = db;

        public bool CanRead(long branchId, string entityName)
        {
            return _db.EntityAccesses.Any(e =>
                e.BranchId == branchId &&
                e.EntityName == entityName &&
                e.CanRead);
        }
    }


}
